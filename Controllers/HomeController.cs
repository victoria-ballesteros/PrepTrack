using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RegistroPreparadurias.Models;

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

        ViewBag.Preparadores = preparadores;

        return View();
    }

    public async Task<IActionResult> Registro()
    {
        var _preparadores = await _supabase.From<Preparadores>().Get();

        var preparadores = _preparadores.Models;

        ViewBag.Preparadores = preparadores;

        var _materias = await _supabase.From<Materias>().Get();

        var materias = _materias.Models;

        ViewBag.Materias = materias;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(Registro registro)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ErrorMessage = "Por favor, corrija los errores en el formulario antes de continuar.";
            return RedirectToAction("Index");
        }

        var _estudiante = await _supabase.From<Estudiantes>().Where(u => u.Cedula == registro.Cedula).Get();

        if (_estudiante.Models.Count < 1)
        {
            Estudiantes estudiante = new()
            {
                Cedula = registro.Cedula
            };

            _estudiante = await _supabase.From<Estudiantes>().Insert(estudiante);

            if (_estudiante.ResponseMessage == null || !_estudiante.ResponseMessage.IsSuccessStatusCode || _estudiante.Model == null)
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            Console.WriteLine("Javier es un estúpido");
        }

        Asistencias asistencia = new()
        {
            CedulaEstudiante = registro.Cedula,
            NombrePreparador = registro.Preparador,
            NombreMateria = registro.NombreMateria,
            Seccion = registro.Seccion
        };

        var response = _supabase.From<Asistencias>().Insert(asistencia);

        return RedirectToAction("Registro");
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
