using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess.Repositories.Interfaces;
using TechOil.DTOs;
using TechOil.Entities;
using TechOil.Helper;
using TechOil.Infrastructure;
using TechOil.Services;

namespace TechOil.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public override async Task<bool> Update(Usuario updateUsuario)
        {
           var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.CodUsuario == updateUsuario.CodUsuario);

            if (usuario == null) { return false; }

            usuario.Nombre = updateUsuario.Nombre;
            usuario.Dni = updateUsuario.Dni;
            usuario.Tipo = updateUsuario.Tipo;
            usuario.Clave = updateUsuario.Clave;
            usuario.Email = updateUsuario.Email;

            _context.Usuarios.Update(usuario);
            return true;
        }


        public override async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.CodUsuario == id).FirstOrDefaultAsync();
            if (usuario != null) {
                _context.Usuarios.Remove(usuario);
            }
                       
            return true;
        }
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Password, dto.Email));  
        }

        public async Task<bool> UsuarioExistente(string email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email == email);
        }

    }
}
