using Microsoft.EntityFrameworkCore;

namespace TrackBudget.Models
{
    public class TrackBudgetDbContext : DbContext
    {
        public TrackBudgetDbContext(DbContextOptions<TrackBudgetDbContext> options) : base(options) { 

        }

        public DbSet<Expense> expenses { get; set; }
    }
}
