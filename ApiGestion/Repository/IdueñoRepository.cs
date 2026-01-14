using ApiGestion.Models;
using ApiGestion.Pagination;

namespace ApiGestion.Repository
{
    public interface IdueñoRepository
    {
        Task<List<Dueño>> GetAll(PaginationRequest pagination);
        Task<Dueño> GetForId(int id);
        Task<List<Dueño>> OrdenarAsc(PaginationRequest pagination);
        Task<List<Dueño>> OrdenarDesc(PaginationRequest pagination);
        Task<List<Dueño>> Filtrar(string nombre,PaginationRequest pagination);
        Task save();
        Task Add(Dueño dueño);
        Task Update(Dueño dueño);
        Task Delete(Dueño dueño);
    }
}
