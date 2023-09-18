using TechOil.Entities;

namespace TechOil.DTOs
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public Tipo Tipo { get; set; }
        public string Clave { get; set; }
        public string Usuario_Email { get; set; }



    }
}
