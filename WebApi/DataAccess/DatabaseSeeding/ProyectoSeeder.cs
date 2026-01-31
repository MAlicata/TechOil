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
                    Nombre = "Planta de Gas - Zona 1",
                    Direccion = "San Miguel de Tucuman",
                    EstadoProyecto = EstadoProyecto.Confirmado                    
                });
        }
    }
}
