using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.Entities;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuariosController(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
           var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
           
           return usuarios;
        }
    }
}
