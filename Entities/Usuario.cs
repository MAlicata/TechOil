using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechOil.DTOs;

namespace TechOil.Entities
{
    public enum Tipo
    {
        Administrador = 1,
        Consultor = 2
    }
    public class Usuario
    {
        public Usuario(UsuarioDTO dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Clave = dto.Clave;
            Email = dto.Usuario_Email;
        }

        public Usuario(UsuarioDTO dto, int id)
        {
            CodUsuario = id;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Clave = dto.Clave;
            Email = dto.Usuario_Email;
        }

        public Usuario()
        {
            
        }

        [Column("cod_usuario")]
        [Key]
        public int CodUsuario { get; set; }

        [Column("nombre" , TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Column("dni")]
        public int Dni { get; set; }

        [Column("tipo")]
        public Tipo Tipo { get; set; }

        [Column("clave")]
        public string Clave { get; set; }

        [Column("usuario_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

    }
}
