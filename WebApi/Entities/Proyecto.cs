using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechOil.DTOs;

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
        public Proyecto()
        {
            
        }

        public Proyecto(ProyectoDTO dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            EstadoProyecto = dto.EstadoProyecto;
        }

        public Proyecto(ProyectoDTO dto, int id)
        {
            CodProyecto = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            EstadoProyecto = dto.EstadoProyecto;
        }

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
