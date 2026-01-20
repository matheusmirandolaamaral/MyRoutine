using Microsoft.AspNetCore.Mvc;
using MyRoutine.Data;
using MyRoutine.Models;

namespace MyRoutine.Controllers
{
    public class MealsController : Controller
    {

        private readonly MyRoutineContext _context;

        public MealsController(MyRoutineContext context)
        {
            _context = context;
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

            return RedirectToAction("Details","Diets", new { id = meal.DietId });
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
            return RedirectToAction("Details", "Diets", new { id = mealDb.DietId });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if(meal == null)
            {
                return NotFound();
            }
            var dietId = meal.DietId;
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","Diets", new {id =  dietId});
        }
    }
}
