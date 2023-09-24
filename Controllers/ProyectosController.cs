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
        /// Devuelve un proyecto
        /// </summary>
        /// <returns>Retorna un proyecto</returns>

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Proyecto>> GetById([FromRoute] int id)
        {
            var proyecto = await _unitOfWork.ProyectoRepository.GetById(id);
            if(proyecto is null)
            {
                return ResponseFactory.CreateErrorResponseR(404, $"Proyecto con el id:{id} no encontrado");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponseR(200, proyecto);
            }            
        }

        /// <summary>
        /// Devuelve todos los proyectos en estado terminado
        /// </summary>
        /// <returns>Retorna todos los proyectos terminado</returns>

        [HttpGet("terminado")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAllTerminado()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAllTerminado();
            if (proyectos is null)
            {
                return ResponseFactory.CreateErrorResponseR(403, "Error recurso no encontrado");                
            }
            else
            {
                return ResponseFactory.CreateSuccessResponseR(200, proyectos);
            }
            
        }

        /// <summary>
        /// Devuelve todos los proyectos en estado confirmado
        /// </summary>
        /// <returns>Retorna todos los proyectos confirmados</returns>

        [HttpGet("confirmado")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAllConfirmado()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAllConfirmado();
            return Ok(proyectos);
        }


        /// <summary>
        /// Devuelve todos los proyectos en estado pendiente
        /// </summary>
        /// <returns>Retorna todos los proyectos pendientes</returns>

        [HttpGet("pendiente")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAllPendiente()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAllPendiente();
            return Ok(proyectos);
        }

        /// <summary>
        /// Registra el proyecto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Devuelve un proyecto registrado con un statusCode 201</returns>

        [HttpPost]
        [Route("Registrar")]
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
