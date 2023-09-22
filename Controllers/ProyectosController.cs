using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechOil.DTOs;
using TechOil.Entities;
using TechOil.Infrastructure;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los proyectos
        /// </summary>
        /// <returns>Retorna todos los proyectos</returns>

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();
            return proyectos;
        }

        /// <summary>
        /// Registra el proyecto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Devuelve un proyecto registrado con un statusCode 201</returns>

        [HttpPost]
        [Route("Register")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Register(ProyectoDTO dto)
        {
            var proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insert(proyecto);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con exito!");
        }

        /// <summary>
        /// Actualiza un proyecto
        /// </summary>
        /// <returns>Actualizado o 500</returns>

        [HttpPut("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Update([FromRoute] int id, ProyectoDTO dto)
        {
            var result = await _unitOfWork.ProyectoRepository.Update(new Proyecto(dto, id));
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
        /// Elimina un proyecto
        /// </summary>
        /// <returns>Elimina o 500</returns>
        /// 
        [HttpDelete("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProyectoRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }


    }
}
