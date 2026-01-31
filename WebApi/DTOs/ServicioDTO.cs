using TechOil.Entities;

namespace TechOil.DTOs
{
    public class ServicioDTO
    {
        public string Descr { get; set; }
        public EstadoServicio EstadoServicio { get; set; }
        public Decimal ValorHora { get; set; }
    }
}
