using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;
using MyRoutine.Models.ViewModels;
using MyRoutine.Services;
using System.Diagnostics;

namespace MyRoutine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyRoutineContext _context;
        private readonly MealService _mealService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
}
