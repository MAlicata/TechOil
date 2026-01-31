using System.Reflection.PortableExecutable;
using TechOil.DataAccess.Repositories;

namespace TechOil.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UsuarioRepository UsuarioRepository { get;}
        public ProyectoRepository ProyectoRepository { get;}
        public ServicioRepository ServicioRepository { get;}
        public TrabajoRepository TrabajoRepository { get;}
        Task<int> Complete();
    }
}
