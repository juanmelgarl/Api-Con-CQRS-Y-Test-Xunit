using ApiGestion.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiGestion.Repository
{
    public class Usuariorepository : IusuarioRepository
    {
        private readonly ClinicaContext _context;

        public Usuariorepository(ClinicaContext context)
        {
            _context = context;
        }
        public Usuarios? GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }
        public async Task<List<Usuarios>> ObtenerTodos()
        {
            return await _context.Usuarios.Where(r => !r.Activo).ToListAsync();
        }

        public async Task Delete(Usuarios usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        
        public Usuarios? GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Add(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        
        public void Update(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}

