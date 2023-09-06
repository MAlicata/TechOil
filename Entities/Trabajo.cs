using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechOil.Entities
{
    public class Trabajo
    {
      
        [Column("cod_trabajo")]
        [Key]
        public int CodTrabajo { get; set; }

        [Column("cod_trabajo")]
        public DateTime Fecha { get; set; }

        [Column("cod_proyecto")]
        [ForeignKey("Proyecto")]
        public int CodProyecto { get; set; } //clave foranea
        public Proyecto Proyecto { get; set; } //Navegación a la entidad Proyecto 

        [Column("cod_servicio")]
        [ForeignKey("Servicio")]
        public int CodServicio { get; set; } //clave foranea
        public Servicio Servicio { get; set; } //Navegacíon a la entiedad Servicio

        [Column("cant_horas")]
        public int CantHoras { get; set; }

        [Column("valor_hora")]
        public decimal ValorHora { get; set; }

        [Column("costo")]
        public decimal Costo { get; set; }
        
    }
}
