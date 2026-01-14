using ApiGestion.Models;
using ApiGestion.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.Repository
{
    public class DueñoREpository : IdueñoRepository
    {
        private readonly ClinicaContext _dbcontext;

        public DueñoREpository(ClinicaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Dueño>> GetAll(PaginationRequest pagination)
        {
            return await _dbcontext.Dueños
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
        public async Task save()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<Dueño?> GetForId(int id)
        {
            return await _dbcontext.Dueños.FirstOrDefaultAsync(c => c.Iddueño == id);
        }
        public async Task Save()
        {
           await _dbcontext.SaveChangesAsync();
        }
        public async Task Delete(Dueño dueño)
        {
             _dbcontext.Dueños.Remove(dueño);
        }
        public async Task Update(Dueño dueño)
        {
            _dbcontext.Dueños.Update(dueño);
        }
        public async Task Add(Dueño dueño)
        {
            _dbcontext.Dueños.Add(dueño);
        }
        public async Task<List<Dueño>> Filtrar(string nombre,PaginationRequest pagination)
        {
            return await _dbcontext.Dueños.Where(c => c.Nombre.Contains(nombre))
                .Skip((pagination.PageNumber - 1 ) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
        public async Task<List<Dueño>> OrdenarAsc(PaginationRequest pagination)
        {
            return await _dbcontext.Dueños.OrderBy(c => c.Iddueño)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
        public async Task<List<Dueño>> OrdenarDesc(PaginationRequest pagination)
        {
            return await _dbcontext.Dueños.OrderByDescending(c => c.Nombre)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }

    }
}
