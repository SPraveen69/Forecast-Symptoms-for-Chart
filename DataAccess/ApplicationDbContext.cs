using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<SymptomData> symptom_data { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SymptomData>().HasNoKey();
        }
    }
}
