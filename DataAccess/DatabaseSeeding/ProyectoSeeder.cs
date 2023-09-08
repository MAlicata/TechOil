using Microsoft.EntityFrameworkCore;
using TechOil.Entities;

namespace TechOil.DataAccess.DatabaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    CodProyecto = 9,
                    Nombre = "Desarrollo de Api Web",
                    Direccion = "San Miguel de tucuman",
                    EstadoProyecto = EstadoProyecto.Confirmado                    
                });
        }
    }
}
