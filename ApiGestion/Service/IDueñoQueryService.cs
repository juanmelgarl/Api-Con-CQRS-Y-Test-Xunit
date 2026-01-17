using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Pagination;

namespace ApiGestion.Service
{
    public interface IDueñoQueryService
    {
        Task<List<Dueñoresponse>> GetAllAsync(PaginationRequest pagination);
        Task<Dueñoresponse> GetForIdAsync(int id);
        Task<List<Dueñoresponse>> FiltrarAsync(string nombre,PaginationRequest pagination);
        Task<List<Dueñoresponse>> OrdenarAscAsync(PaginationRequest pagination);
        Task<List<Dueñoresponse>> OrdenarDescAsync(PaginationRequest pagination);
    }
}
