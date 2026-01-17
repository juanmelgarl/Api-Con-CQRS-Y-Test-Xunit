using ApiGestion.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using BCrypt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiGestion.Service
{
    public class Authservice : IauthService
    {
        private readonly IConfiguration _Configuration;
        private readonly IusuarioRepository _repo;
        public Authservice(IConfiguration configuration, IusuarioRepository repo)
        {
            _Configuration = configuration;
            _repo = repo;
        }
      
        public string GenerarToken(string username, string rol)
        {
            var claims = new[]
            {
                 new Claim(ClaimTypes.NameIdentifier, username),
                 new Claim(ClaimTypes.Role, rol)
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
             issuer:
             _Configuration["Jwt:Issuer"],
             audience: _Configuration["Jwt:Audience"],
             claims: claims,
             expires: DateTime.Now.AddMinutes(
                 int.Parse(_Configuration["Jwt:DurationInMinutes"])
             ),
             signingCredentials: creds
         );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public string Login(string email, string password)
        {
            var usuario = _repo.GetByEmail(email);

            if (usuario == null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            if (!usuario.Activo)
                throw new UnauthorizedAccessException("Usuario no autorizado");

            if (!BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash))
                throw new UnauthorizedAccessException("Credenciales inválidas");

            return GenerarToken(usuario.Email,usuario.Rol);
        }
       
    }
}
       
