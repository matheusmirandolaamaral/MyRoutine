using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRoutine.Models;

namespace MyRoutine.Data
{
    public class MyRoutineContext : DbContext
    {
        public MyRoutineContext (DbContextOptions<MyRoutineContext> options)
            : base(options)
        {
        }

        public DbSet<MyRoutine.Models.Diet> Diet { get; set; } = default!;
    }
}
