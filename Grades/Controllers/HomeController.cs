using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Grades.Models;

namespace Grades.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Obtén la lista predeterminada de materias
        var subjects = Subject.DefaultSubjects;

        // Pasa la lista a la vista
        return View(subjects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}