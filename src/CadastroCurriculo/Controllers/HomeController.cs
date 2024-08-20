using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Services;
using Core.Entities;
using Core.Exceptions;
using CadastroCurriculo.Authorization;
using Core.Models.Requests;
using FluentValidation.AspNetCore;
using System.Globalization;

namespace CadastroCurriculo.Controllers;
[AllowAnonymous]
public class HomeController : Controller
{
    private readonly ICurricolumService _curricolumService;

    public HomeController(ICurricolumService curricolumService)
    {
        _curricolumService = curricolumService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var curricolums = await _curricolumService.GetAll();
        decimal average = 0;
        if (curricolums.Any())
        {
            average = curricolums.Sum(x => x.SalaryExpectation) / curricolums.Count();
        }

        ViewData["average"] = average;
        ViewData["averageAsString"] = average.ToString("N", CultureInfo.CurrentCulture);

        return View("Index");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost("login"), ValidateAntiForgeryToken]
    public async Task<IActionResult> LogIn(
        [FromServices] IUserService userService,
        [FromForm] AuthenticationRequest request
    )
    {
        if (!ModelState.IsValid)
        {
            return Login();
        }

        var usuario = await GetUserAsync(userService, request);

        if (usuario == null)
        {
            ModelState.AddModelError("login", "Usuário ou senha inválida");
            return Login();
        }

        var claimPrincipal = ClaimsPrincipalFactory.Create(usuario);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = request.KeepLoggedIn,
            ExpiresUtc = DateTime.UtcNow.AddHours(20),
            RedirectUri = "/"
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimPrincipal,
            authProperties
        );

        return RedirectToAction("Index", "Curricolum");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("criar-conta")]
    public IActionResult CreateAccount()
    {
        return View(new CreateAccountRequest());
    }

    [HttpPost("criar-conta"), ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAccount(
        [FromForm] CreateAccountRequest createAccountRequest,
        [FromServices] IUserService userService
    )
    {
        if (!ModelState.IsValid)
        {
            return CreateAccount();
        }

        try
        {
            var user = await userService.Create(createAccountRequest);

            TempData["Success"] = "Cadastro de conta realizado com sucesso";

            var claimPrincipal = ClaimsPrincipalFactory.Create(user);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(20),
                RedirectUri = "/"
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimPrincipal,
                authProperties
            );

        }
        catch (ValidationException ex)
        {
            ex.ValidationResult.AddToModelState(ModelState);

            return CreateAccount();
        }

        return RedirectToAction("Index", "Curricolum");
    }

    private static async Task<User> GetUserAsync(IUserService userService, AuthenticationRequest authentication)
    {
        try
        {
            return await userService.GetByEmailPassword(authentication.Email, authentication.Password);
        }
        catch (NotFoundException)
        {
            return null;
        }
    }
}
