using TechOil.Entities;

namespace TechOil.DTOs
{
    public class ProyectoDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public EstadoProyecto EstadoProyecto { get; set; }
    }
}
