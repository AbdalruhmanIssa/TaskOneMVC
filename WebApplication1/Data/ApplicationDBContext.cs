using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Categorey>Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=asp10_mvc;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
