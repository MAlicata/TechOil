using Microsoft.EntityFrameworkCore;
using TechOil.Entities;

namespace TechOil.DataAccess.DatabaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().HasData(
                new Trabajo
                {
                    CodTrabajo = 2,
                    Fecha = DateTime.Now,
                    CodProyecto = 9,
                    CodServicio = 5,
                    CantHoras = 20,
                    ValorHora = 100,
                    Costo = 2000
                });
        }
    }
}
