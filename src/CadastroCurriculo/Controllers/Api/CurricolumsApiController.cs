using CadastroCurriculo.Models;
using Core;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers.api;

[Route("api/curriculo"), ApiController]
public class CurricolumsApiController : Controller
{
    private readonly ICurricolumService _curricolumService;

    public CurricolumsApiController(ICurricolumService curricolumService)
    {
        _curricolumService = curricolumService;
    }

    [HttpGet("obter-todos-por-usuario")]
    public async Task<IActionResult> GetCurricolumsByUser(
        [FromServices] AuthenticatedUser authenticatedUser,
        [FromQuery] string search, int draw, int start, int length
    )
    {
        var curricolums = await _curricolumService.GetAllByUserId(authenticatedUser.Id);
        var totalRecords = curricolums.Count();
        var result = new DataTableResponse<Curricolum>()
        {
            Draw = draw,
            RecordsTotal = totalRecords,
            RecordsFiltered = totalRecords,
            Data = curricolums.Skip(start).Take(length).ToList()
        };

        return Ok(result);
    }

    [HttpGet("obter-todos")]
    public async Task<IActionResult> GetCurricolums(
        [FromQuery] string search, int draw, int start, int length
    )
    {
        var curricolums = await _curricolumService.GetAll();
        var totalRecords = curricolums.Count();
        var result = new DataTableResponse<Curricolum>()
        {
            Draw = draw,
            RecordsTotal = totalRecords,
            RecordsFiltered = totalRecords,
            Data = curricolums.Skip(start).Take(length).ToList()
        };

        return Ok(result);
    }
}
