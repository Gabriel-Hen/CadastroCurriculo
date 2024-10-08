﻿using AutoMapper;
using Core;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.Models.Requests;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers;

[Route("curriculo"), Authorize]
public class CurricolumController : Controller
{
    private readonly ICurricolumService _curricolumService;
    private readonly IMapper _mapper;

    public CurricolumController(ICurricolumService curricolumService, IMapper mapper)
    {
        _curricolumService = curricolumService;
        _mapper = mapper;
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

    [HttpPost("cadastrar"), ValidateAntiForgeryToken]
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

    [HttpGet("{id}/editar")]
    public async Task<IActionResult> Update(int Id)
    {
        var curricolum = await _curricolumService.GetById(Id);
        var curricolumRequest = _mapper.Map<CurricolumUpdateRequest>(curricolum);

        return View(curricolumRequest);
    }

    [HttpPost("{id}/editar"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(
        int Id,
        [FromForm] CurricolumUpdateRequest request,
        [FromServices] AuthenticatedUser authenticatedUser
    )
    {
        if (!ModelState.IsValid)
        {
            return await Update(Id);
        }

        try
        {
            var curricolum = await _curricolumService.Update(authenticatedUser.Id, request);

            TempData["Success"] = $"Curriculo {curricolum.Name} alterado com sucesso";
            return RedirectToAction(nameof(Index));

        }
        catch (ValidationException ex)
        {
            ex.ValidationResult.AddToModelState (ModelState);

            return await Update(Id);
        }
    }

    [HttpPost("{id}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _curricolumService.Delete(id);

            TempData["Success"] = "Curriculo deletado com sucesso.";
        }
        catch (ValidationException ex) 
        {
            TempData["Erros"] = ex.GetErrorMessages();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("experiencia-profisional")]
    public IActionResult _Experience(int index) 
    {
        ViewData["id"] = false;
        ViewData.TemplateInfo.HtmlFieldPrefix = $"ProfessionalExperiences[{index}]";
        return PartialView(new ProfessionalExperienceRequest());
    }

    [HttpGet("curso")]
    public IActionResult _Course(int index)
    {
        ViewData["id"] = false;
        ViewData.TemplateInfo.HtmlFieldPrefix = $"Courses[{index}]";
        return PartialView(new CourseRequest());
    }
}
