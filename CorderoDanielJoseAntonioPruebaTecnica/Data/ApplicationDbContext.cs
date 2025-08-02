using CorderoDanielJoseAntonioPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace CorderoDanielJoseAntonioPruebaTecnica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Productos { get; set; }

    }
}
