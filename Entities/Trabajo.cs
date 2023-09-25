using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechOil.DTOs;

namespace TechOil.Entities
{
    public class Trabajo
    {
        public Trabajo()
        {
            
        }
        public Trabajo(TrabajoDTO dto)
        {
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
        }
        public Trabajo(TrabajoDTO dto, int id)
        {
            CodTrabajo = id;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
        }

        [Column("cod_trabajo")]
        [Key]
        public int CodTrabajo { get; set; }

        [Column("fecha")]
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

        [Column("valor_hora", TypeName = "Decimal")]
        public decimal ValorHora { get; set; }

        [Column("costo", TypeName = "DECIMAL")]
        public decimal Costo { get; set; }
        
    }
}
