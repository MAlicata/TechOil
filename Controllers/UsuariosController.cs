using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
using TechOil.Entities;
using TechOil.Helper;
using TechOil.Infrastructure;
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

        /// <summary>
        /// Devuelve todos los usuarios
        /// </summary>
        /// <returns>Retorna todos los usuarios</returns>

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
           var usuarios = await _unitOfWork.UsuarioRepository.GetAll();           
           return ResponseFactory.CreateSuccessResponse(200, usuarios);
        }
                
        /// <summary>
        /// Devuelve un Usuario
        /// </summary>
        /// <returns>Retorna un usuario</returns>

        [HttpGet("getById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> GetById([FromRoute] int id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(id);

            if (usuario is null)
            {
                return ResponseFactory.CreateErrorResponseR(404, $"Usuario con el id:{id} no encontrado");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponseR(200, usuario);
            }
        }

        /// <summary>
        /// Registra el usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Devuelve un usuario registrado con un statusCode 201</returns>


        [HttpPost]
        [Route("Register")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Register(UsuarioDTO dto)
        {
            if (await _unitOfWork.UsuarioRepository.UsuarioExistente(dto.Usuario_Email)) return ResponseFactory.CreateErrorResponse(409, $"Existe un usuario con el mail: {dto.Usuario_Email}");
            
            var usuario = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insert(usuario);
         
            await _unitOfWork.Complete();

            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <returns>Actualizado o 500</returns>

        [HttpPut("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Update([FromRoute] int id, UsuarioDTO dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }            
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <returns>Elimina o 500</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UsuarioRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }                
                       
        }

        
    }
}
