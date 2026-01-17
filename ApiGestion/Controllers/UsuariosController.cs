using ApiGestion.Controllers;
using ApiGestion.DTOS.Request;
using ApiGestion.Migrations;
using ApiGestion.Models;
using ApiGestion.Repository;
using ApiGestion.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly IusuarioRepository _repo;


    public UsuarioController(IusuarioRepository repo, IDueñoQueryService service)
    {
        _repo = repo;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CrearUsuario(LoginDTO dto)
    {
        var existe = _repo.GetByEmail(dto.EMAIL);
        if (existe != null)
            return BadRequest("El email ya está registrado");

        var usuario = new Usuarios
        {
            Email = dto.EMAIL,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PASSWORD),
            Rol = "User",
            Activo = false,
             FechaCreacion = DateTime.Now,
              Nombre = "Usuario"
        };

        _repo.Add(usuario);
        return Ok("Usuario creado, pendiente de aprobación");
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerPendientes()
    {
       
        var usuarios = await _repo.ObtenerTodos();

        var resultado = usuarios.Select(u => new  LoginPendientesDTO
        {
            Id = u.Id,
            Email = u.Email,
            Activo = u.Activo
        }).ToList();
 
        return Ok(resultado);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Eliminarusuario(int id)
    {
        var usuario = _repo.GetById(id);
        if (usuario is null)
        {
            return NotFound();
        }
        await _repo.Delete(usuario);
        return NoContent();

     
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/aprobar")]
    public IActionResult AprobarUsuario(int id)
    {
        var usuario = _repo.GetById(id);
        if (usuario == null)
            return NotFound();

        usuario.Activo = true;
        _repo.Update(usuario);

        return Ok("Usuario aprobado");
    }

}
