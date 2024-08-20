using AutoMapper;
using Core;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.Models.Requests;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers;

[Route("perfil"), Authorize]
public class ProfileController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public ProfileController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet()]
    public async Task<IActionResult> Index([FromServices] AuthenticatedUser authenticatedUser)
    {
        var user = await _userService.GetById(authenticatedUser.Id);

        var userRequest = _mapper.Map<UpdateUserRequest>(user);
        return View(userRequest);
    }

    public async Task<IActionResult> Index(
        [FromForm] UpdateUserRequest request,
        [FromServices] AuthenticatedUser authenticatedUser
    )
    {
        if (!ModelState.IsValid)
        {
            return await Index(authenticatedUser);
        }

        try
        {
            var user = await _userService.Update(request);

            TempData["Success"] = $"Usuario atualizado com sucesso";

            return RedirectToAction("Index");
        }
        catch (ValidationException ex)
        {
            ex.ValidationResult.AddToModelState(ModelState);

            return await Index(authenticatedUser);
        }
    }
}
