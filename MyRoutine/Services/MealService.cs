using Microsoft.EntityFrameworkCore;
using MyRoutine.Data;
using MyRoutine.Models;
using System.Linq;

namespace MyRoutine.Services
{
    public class MealService
    {
        private readonly MyRoutineContext _context;
        
        public MealService(MyRoutineContext context)
        {
            _context = context;
        }

        public async Task<int?> SumCalories(int dietId)
        {
            return await _context.Meals.Where(x => x.DietId == dietId).SumAsync(x => x.Calories);
        }
        

        
    }
}
