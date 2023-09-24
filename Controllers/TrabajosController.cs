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
    public class TrabajosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrabajosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los trabajos
        /// </summary>
        /// <returns>Retorna todos los trabajos</returns>

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetAll()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.GetAll();
            return trabajos;
        }

        /// <summary>
        /// Devuelve un Trabajo
        /// </summary>
        /// <returns>Retorna un trabajo</returns>

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Trabajo>> GetById([FromRoute] int id)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetById(id);
     
            if (trabajo is null)
            {
                return ResponseFactory.CreateErrorResponseR(404, $"Trabajo con el id:{id} no encontrado");
            }
            else
            {
                return ResponseFactory.CreateSuccessResponseR(200, trabajo);
            }
        }

        /// <summary>
        /// Registra el trabajo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Devuelve un trabajo registrado con un statusCode 201</returns>

        [HttpPost]
        [Route("Registrar")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Register(TrabajoDTO dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insert(trabajo);
            await _unitOfWork.Complete();
            
            return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
        }

        /// <summary>
        /// Actualiza un trabajo
        /// </summary>
        /// <returns>Actualizado o 500</returns>

        [HttpPut("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Update([FromRoute] int id, TrabajoDTO dto)
        {
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, id));
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
        /// Elimina un trabajo
        /// </summary>
        /// <returns>Elimina o 500</returns>

        [HttpDelete("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.TrabajoRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
