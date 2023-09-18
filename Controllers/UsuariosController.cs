using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
           var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
           
           return usuarios;
        }


        [HttpPost]
        [Route("Register")]
        //[Authorize]
        public async Task<IActionResult> Register(UsuarioDTO dto)
        {
            var usuario = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, UsuarioDTO dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
