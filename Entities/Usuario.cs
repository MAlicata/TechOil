using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechOil.Entities
{
    public enum Tipo
    {
        Administrador = 1,
        Consultor = 2
    }
    public class Usuario
    {
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
    }
}
