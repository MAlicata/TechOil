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
        [Key]
        [Column("cod_proyecto")]
        public int CodProyecto { get; set; }
        [Column("nombre", Type = "VARCHAR(100)")]
        public string Nombre { get; set; }
        public decimal Direccion { get; set; }
        public int EstadoProyecto { get; set; }

    }
}
