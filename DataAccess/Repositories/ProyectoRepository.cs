using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.Entities;

namespace TechOil.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
