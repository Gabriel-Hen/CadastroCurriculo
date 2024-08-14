using Core;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers.api;

[Route("curriculo-api")]
public class CurricolumsApiController : Controller
{
    private readonly ICurricolumService _curricolumService;

    public CurricolumsApiController(ICurricolumService curricolumService)
    {
        _curricolumService = curricolumService;
    }
    [HttpGet("{userId}/obter-todos")]
    public async Task<IActionResult> GetCurricolums(int userId)
    {
        var curricolums = _curricolumService.GetAll(userId);
        return Ok(curricolums);
    }
}
