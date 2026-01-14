using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Models;

namespace ApiGestion.Service
{
    public interface IDueñoCommand
    {
        Task<Dueñoresponse> CreateAsync(CreateDTO dto);
        Task<bool>UpdateAsync(int id,UpdateDTO dto);
        Task<bool>DeleteAsync(int id);
    }
}
