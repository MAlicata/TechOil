using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechOil.Entities
{
    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
    public class Proyecto
    {
        
        [Column("cod_proyecto")]
        [Key]
        public int CodProyecto { get; set; }

        [Required]
        [Column("nombre", TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }
        [Required]
        [Column("direccion" , TypeName = "VARCHAR(100)")]
        public string Direccion { get; set; }
        [Required]
        [Column("estado_proyecto")]
        public EstadoProyecto EstadoProyecto { get; set; }

    }
}
