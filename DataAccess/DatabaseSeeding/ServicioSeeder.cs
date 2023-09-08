using Microsoft.EntityFrameworkCore;
using TechOil.Entities;

namespace TechOil.DataAccess.DatabaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    CodServicio = 5,
                    Descr = "Servicio de Marketing",
                    EstadoServicio = EstadoServicio.Activo,
                    ValorHora = 100
                });
        }
    }
}
