using Microsoft.EntityFrameworkCore;
using TechOil.Entities;
using TechOil.Helper;

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
                    Clave = PasswordEncryptHelper.EncryptPassword("1234", "matias@hotmail.com.ar"),
                    Email = "matias@hotmail.com.ar"
                });
        }
    }
}
