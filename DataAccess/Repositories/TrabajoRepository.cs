using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Update(Trabajo updateTrabajo)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.CodTrabajo == updateTrabajo.CodTrabajo);

            if (trabajo == null) { return false; }

            trabajo.Fecha = updateTrabajo.Fecha;
            trabajo.CodProyecto = updateTrabajo.CodProyecto;
            trabajo.CodServicio = updateTrabajo.CodServicio;
            trabajo.CantHoras = updateTrabajo.CantHoras;
            trabajo.ValorHora = updateTrabajo.ValorHora;
            trabajo.Costo = updateTrabajo.Costo;        
            
            _context.Trabajos.Update(trabajo);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var trabajo = await _context.Trabajos.Where(x => x.CodTrabajo == id).FirstOrDefaultAsync();
            if (trabajo != null)
            {
                _context.Trabajos.Remove(trabajo);
            }

            return true;
        }
    }
}
