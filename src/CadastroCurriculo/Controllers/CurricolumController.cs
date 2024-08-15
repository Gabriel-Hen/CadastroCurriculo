using Core;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.Models.Requests;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers;

[Route("curriculo")]
public class CurricolumController : Controller
{
    private readonly ICurricolumService _curricolumService;

    public CurricolumController(ICurricolumService curricolumService)
    {
        _curricolumService = curricolumService;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpGet("cadastrar")]
    public IActionResult Create()
    {
        return View(new CurricolumRequest());
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Create(
        [FromForm] CurricolumRequest curricolumRequest,
        [FromServices] AuthenticatedUser authenticatedUser
    )
    {
        if (!ModelState.IsValid)
        {
            return Create();
        }

        try
        {
            var curricolum = await _curricolumService.Create(curricolumRequest, authenticatedUser.Id);
            TempData["Success"] = $"Curriculo: {curricolum.Name} cadastrado com sucesso.";

            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException ex)
        {
            ex.ValidationResult.AddToModelState(ModelState);

            return Create();
        }
    }
}
