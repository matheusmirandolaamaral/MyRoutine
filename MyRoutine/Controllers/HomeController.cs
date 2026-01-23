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
        private readonly MealService _mealService;

        public HomeController(DailyDietService dailyDietService, MealService mealService)
        {
            _dailyDietService = dailyDietService;
            _mealService = mealService;
        }

        public async Task<IActionResult> Index()
        {
            var dailyDiet = await _dailyDietService.GetByDateAsync(DateTime.Today);

            int? totalCalories = null;
            int mealsCont = 0;

            if (dailyDiet != null)
            {
                totalCalories = await _mealService.SumCalories(dailyDiet.DietId);
                mealsCont = await _mealService.CountMelas(dailyDiet.DietId) ?? 0  ;
            }

            var viewModel = new HomeViewModel
            {
                DailyDiet = dailyDiet,
                TotalCalories = totalCalories,
                CountMeals = mealsCont

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
