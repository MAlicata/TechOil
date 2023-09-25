using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechOil.Entities;
namespace TechOil.Helper
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration; //por la inyeccion de dependencia, extrae la clave valor del appsetting
        public TokenJwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.CodUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.Tipo.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
