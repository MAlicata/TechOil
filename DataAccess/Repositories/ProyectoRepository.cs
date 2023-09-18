using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override async Task<bool> Update(Proyecto updateProyecto)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == updateProyecto.CodProyecto);

            if (proyecto == null) { return false; }

            proyecto.Nombre = updateProyecto.Nombre;
            proyecto.Direccion = updateProyecto.Direccion;
            proyecto.EstadoProyecto = updateProyecto.EstadoProyecto;          

            _context.Proyectos.Update(proyecto);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var proyecto = await _context.Proyectos.Where(x => x.CodProyecto == id).FirstOrDefaultAsync();
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }

            return true;
        }
    }
}
