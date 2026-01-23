using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;
using MyRoutine.Models.ViewModels;
using MyRoutine.Services;

namespace MyRoutine.Controllers
{
    public class DietsController : Controller
    {
        private readonly MyRoutineContext _context;
        private readonly MealService _mealService;

        public DietsController(MyRoutineContext context, MealService mealService)
        {
            _context = context;
            _mealService = mealService;
        }

        // GET: Diets
        public async Task<IActionResult> Index(bool selectmode = false)
        {
            var diets = await _context.Diets.ToListAsync();

            var viewModels = new DietSelectViewModel
            {
                SelectMode = selectmode
            };

           
           foreach(var diet in diets)
            {
                var totalCalories = await _mealService.SumCalories(diet.Id);

                viewModels.Diets.Add(new DietIndexViewModel
                {
                    Diet = diet,
                    TotalCalories = totalCalories
                });

            }
           return View(viewModels);
        }

        // GET: Diets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var diet = await  _context.Diets.FirstOrDefaultAsync(x => x.Id == id);
            if (diet == null)
            {
                return NotFound();
            }

            var meals = await _context.Meals.Where(x => x.DietId == id).OrderBy(x => x.Type).ToListAsync();
            var totalCalories = await _mealService.SumCalories(id.Value);

            var viewModel = new DietDetailsViewModel
            {
                Diet = diet,
                Meals = meals,
                TotalCalories = totalCalories
                
                
            };
            return View(viewModel);
        }

        // GET: Diets/Create
        public IActionResult Create()
        {
            var viewModel = new DietFormViewModel()
            {
                Diet = new Diet(),
                Meal = new Meal()
            };
            
            
            return View(viewModel);
        }

        // POST: Diets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Diet diet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Meals", new {dietId = diet.Id});
            }
            return View(diet);
        }

        // GET: Diets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diets.FindAsync(id);
            if (diet == null)
            {
                return NotFound();
            }
            return View(diet);
        }

        // POST: Diets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateInitial,DateFinal")] Diet diet)
        {
            if (id != diet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietExists(diet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diet);
        }

        // GET: Diets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diet = await _context.Diets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diet == null)
            {
                return NotFound();
            }

            return View(diet);
        }

        // POST: Diets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet != null)
            {
                _context.Diets.Remove(diet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietExists(int id)
        {
            return _context.Diets.Any(e => e.Id == id);
        }
    }
}
