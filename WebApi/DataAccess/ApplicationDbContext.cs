using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.DatabaseSeeding;
using TechOil.Entities;

namespace TechOil.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new TrabajoSeeder(),
                new ServicioSeeder(),
                new ProyectoSeeder()
            };
            foreach(var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
