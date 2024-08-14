using Microsoft.AspNetCore.Mvc;

namespace CadastroCurriculo.Controllers;

public class CurricolumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
