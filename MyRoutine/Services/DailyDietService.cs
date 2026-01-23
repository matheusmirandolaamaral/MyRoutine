using MyRoutine.Data;

namespace MyRoutine.Services
{
    public class DailyDietService : IDailyDietService
    {
        private readonly MyRoutineContext _context;

        public DailyDietService(MyRoutineContext context)
        {
            _context = context;
        }

        
    }
}
