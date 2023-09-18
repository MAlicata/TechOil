using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TechOil.DTOs;
using TechOil.Entities;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiciosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
        var servicios = await _unitOfWork.ServicioRepository.GetAll();

            return servicios;
        }

        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAllActivo()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAllActivo();

            return Ok(servicios);
        }

        [HttpPost]
        [Route("Register")]
        //[Authorize]
        public async Task<IActionResult> Register(ServicioDTO dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, ServicioDTO dto)
        {
            var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.Delete(id);

            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
