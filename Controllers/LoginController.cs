using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechOil.DTOs;
using TechOil.Helper;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration) {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Autentica un usuario
        /// </summary>
        /// <returns>Retorna un token de autenticacion</returns>

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto); //esto me responde con un usuario
            if(usuarioCredentials == null) { return Unauthorized("Las credenciales son incorrectas"); }

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);

            var usuario = new UsuarioLoginDto()
            {               
                Email = usuarioCredentials.Email,
                Name = usuarioCredentials.Nombre,                
                Token = token
            };

            //return Ok(token);
            return Ok(usuario);
        }
    }
}
