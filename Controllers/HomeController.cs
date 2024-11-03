using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RegistroPreparadurias.Models;
using RegistroPreparadurias.Models.Preparadores;

namespace RegistroPreparadurias.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly Supabase.Client _supabase;

    public HomeController(ILogger<HomeController> logger, Supabase.Client supabase)
    {
        _logger = logger;
        _supabase = supabase;
    }

    public async Task<IActionResult> Index()
    {
        var _preparadores = await _supabase.From<Preparadores>().Get();

        var preparadores = _preparadores.Models;

        foreach(var preparador in preparadores)
        {
            Console.WriteLine(preparador.Nombre);
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
