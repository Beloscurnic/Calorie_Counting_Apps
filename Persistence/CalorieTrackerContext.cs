using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class CalorieTrackerContext : DbContext
    {
        public CalorieTrackerContext(DbContextOptions<CalorieTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<CalorieIntake> CalorieIntakes { get; set; }
    }
}
