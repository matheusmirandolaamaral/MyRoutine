using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;
using MyRoutine.Models.ViewModels;
using MyRoutine.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyRoutine.Controllers
{
    public class HomeController : Controller
    {
        
                
        private readonly DailyDietService _dailyDietService;

        public HomeController(DailyDietService dailyDietService)
        {
            _dailyDietService = dailyDietService;
        }

        public async Task<IActionResult> Index()
        {
            var dailyDiet = await _dailyDietService.GetByDateAsync(DateTime.Today);

            var viewModel = new HomeViewModel
            {
                DailyDiet = dailyDiet
            };

            return View(viewModel);
        }

        public async Task<IActionResult> SetDiet(int dietId)
        {
            await _dailyDietService.SetDietForTodayAsync(dietId);
            return RedirectToAction(nameof(Index));
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
