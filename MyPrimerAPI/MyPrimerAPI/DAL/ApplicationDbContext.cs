using Microsoft.EntityFrameworkCore;
using MyPrimerAPI.DAL.Models;

namespace MyPrimerAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // seccion para definir los DbSet (tablas) de la base de datos
        public DbSet<Category> Categories { get; set; }

        // DbSet para la entidad Movie
        public DbSet<Movie> Movies { get; set; }
    }
}
