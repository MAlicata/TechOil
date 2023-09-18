using Microsoft.EntityFrameworkCore;
using TechOil.Entities;

namespace TechOil.DataAccess.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Nombre = "Matias",
                    Dni = 12345678,
                    Tipo = Tipo.Administrador,
                    Clave = "1234",
                    Email = "matias@hotmail.com.ar"
                });
        }
    }
}
