using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;
using MyRoutine.Models.ViewModels;
using MyRoutine.Services;

namespace MyRoutine.Controllers
{
    public class MealsController : Controller
    {

        private readonly MyRoutineContext _context;
        private readonly MealService _mealService;

        public MealsController(MyRoutineContext context, MealService mealService)
        {
            _context = context;
            _mealService = mealService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var diet = await _context.Diets.FirstOrDefaultAsync(x => x.Id == id);
            if (diet == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals.Where(x => x.DietId == id).OrderBy(x => x.Type).ToListAsync();
            var totalCalories = await _mealService.SumCalories(id.Value);

            var viewModel = new MealIndexViewModel
            {
                Diet = diet,
                Meals = meals,
                TotalCalories = totalCalories


            };
            return View(viewModel);
        }
        public IActionResult Create(int dietId)
        {
            var meal = new Meal
            {
                DietId = dietId
            };
           return View(meal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Meals", new { id = meal.DietId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var meal = await _context.Meals.FindAsync(id);
            if(meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Meal meal)
        {
            if (!ModelState.IsValid)
            {
                return View(meal);
            }
            var mealDb = await _context.Meals.FindAsync(meal.Id);
            if (mealDb == null)
            {
                return NotFound();
            }
            mealDb.Name = meal.Name;
            mealDb.Description = meal.Description;
            mealDb.Calories = meal.Calories;
            mealDb.Type = meal.Type;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Meals", new { id = mealDb.DietId });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            var dietId = meal.DietId;
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Meals", new { id = dietId });
        }

        



        [HttpPost]
        public async Task<IActionResult> SelectMeal(MealSelectViewModel model)
        {
            var dailyDiet = await _context.DailyDiets.Include(x => x.DailyMeals).FirstOrDefaultAsync(x => x.Id == model.DailyDietId);

            if (dailyDiet == null)
            {
                return NotFound();
            }

            _context.DailyMeals.RemoveRange(dailyDiet.DailyMeals);

            foreach(var mealId in model.SelectMeals)
            {
                dailyDiet.DailyMeals.Add(new DailyMeal
                {
                    MealId = mealId
                });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home", new {dailyDietId = dailyDiet.Id});
        }
    }
}
