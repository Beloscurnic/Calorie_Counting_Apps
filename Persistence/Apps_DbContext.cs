using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Entity_Type_Configurations;

namespace Persistence
{
    public class Apps_DbContext : DbContext, I_DbContext
    {
        public DbSet<Domain_Example> Domain_Examples { get; set; }

        public Apps_DbContext(DbContextOptions<Apps_DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Domain_Example_Configuration());
            base.OnModelCreating(builder);
        }
    }
}
