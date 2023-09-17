using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override async Task<bool> Update(Servicio updateServicio)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == updateServicio.CodServicio);

            if (servicio == null) { return false; }

            servicio.Descr = updateServicio.Descr;
            servicio.EstadoServicio = updateServicio.EstadoServicio;
            servicio.ValorHora = updateServicio.ValorHora;
            
            _context.Servicios.Update(servicio);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var servicio = await _context.Servicios.Where(x => x.CodServicio == id).FirstOrDefaultAsync();
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            return true;
        }
    }
}
