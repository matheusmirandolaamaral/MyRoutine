using Microsoft.AspNetCore.Mvc;
using MyRoutine.Models;

namespace MyRoutine.Controllers
{
    public class MealsController : Controller
    {
        public IActionResult Create(int dietId)
        {
            var meal = new Meal
            {
                DietId = dietId
            };
           return View(meal);
        }
    }
}
