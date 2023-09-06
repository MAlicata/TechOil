using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechOil.Entities
{
    public enum EstadoServicio
    {
        Activo,
        Desactivado
    }

    public class Servicio
    {
        [Column("cod_servicio")]
        [Key]
        public int CodServicio { get; set; }

        [Required]
        [Column("descr", TypeName = "VARCHAR(100)")]
        public string Descr { get; set; }

        [Required]
        [Column("estado_servicio")]
        public bool EstadoServicio { get; set; }

        [Required]
        [Column("valor_hora")]
        public decimal ValorHora { get; set; }
        
    }
}
