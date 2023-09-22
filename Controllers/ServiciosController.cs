﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TechOil.DTOs;
using TechOil.Entities;
using TechOil.Infrastructure;
using TechOil.Services;

namespace TechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ServiciosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Devuelve todos los servicios
        /// </summary>
        /// <returns>Retorna todos los servicios</returns>

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();
            return servicios;
        }

        /// <summary>
        /// Devuelve todos los servicios activos
        /// </summary>
        /// <returns>Retorna todos los servicios activos</returns>

        [HttpGet("activos")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAllActivo()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAllActivo();
            return Ok(servicios);
        }

        /// <summary>
        /// Registra el servicio
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Devuelve un servicio registrado con un statusCode 201</returns>

        [HttpPost]
        [Route("Register")]
        [Authorize(Policy = "1")]

        public async Task<IActionResult> Register(ServicioDTO dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insert(servicio);
            await _unitOfWork.Complete();
           
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
        }

        /// <summary>
        /// Actualiza un servicio
        /// </summary>
        /// <returns>Actualizado o 500</returns>

        [HttpPut("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Update([FromRoute] int id, ServicioDTO dto)
        {
            var result = await _unitOfWork.ServicioRepository.Update(new Servicio(dto, id));
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
        /// Elimina un servicio
        /// </summary>
        /// <returns>Elimina o 500</returns>

        [HttpDelete("{id}")]
        [Authorize(Policy = "1")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServicioRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }

    }
}
