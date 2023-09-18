using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechOil.DTOs;

namespace TechOil.Entities
{
    public enum EstadoServicio
    {
        Activo,
        Desactivado
    }

    public class Servicio
    {
        public Servicio()
        {
            
        }

        public Servicio(ServicioDTO dto)
        {
            Descr = dto.Descr;
            EstadoServicio = dto.EstadoServicio;
            ValorHora = dto.ValorHora;
        }
        public Servicio(ServicioDTO dto, int id)
        {
            CodServicio = id;
            Descr = dto.Descr;
            EstadoServicio = dto.EstadoServicio;
            ValorHora = dto.ValorHora;
        }

        [Column("cod_servicio")]
        [Key]
        public int CodServicio { get; set; }

        [Required]
        [Column("descr", TypeName = "VARCHAR(100)")]
        public string Descr { get; set; }

        [Required]
        [Column("estado_servicio")]
        public EstadoServicio EstadoServicio { get; set; }

        [Required]
        [Column("valor_hora", TypeName = "DECIMAL")]
        public decimal ValorHora { get; set; }
        
    }
}
