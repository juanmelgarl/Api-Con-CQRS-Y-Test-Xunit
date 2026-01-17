using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Models;
using ApiGestion.Pagination;
using ApiGestion.Repository;
using Azure;

namespace ApiGestion.Service
{
    public class DueñoQuerySerivce : IDueñoQueryService
    {
        private readonly IdueñoRepository _repo;
        public DueñoQuerySerivce(IdueñoRepository repo)
        {
            _repo = repo;
        }
        private Dueñoresponse Toresponse(Dueño d) => new Dueñoresponse
        {
            IDdueño = d.Iddueño,
            Direccion = d.Direccion,
            Dni = d.Dni,
            Email = d.Email,
            Nombre = d.Nombre,
            Telefono = d.Telefono,
        };
       
        public async Task<List<Dueñoresponse>> GetAllAsync(PaginationRequest pagination)
        {
            return (await _repo.GetAll(pagination)).Select(Toresponse).ToList();
        }
        public async Task<Dueñoresponse> GetForIdAsync(int id)
        {
            return Toresponse(await _repo.GetForId(id));
        }
        public async Task<List<Dueñoresponse>> FiltrarAsync(string nombre,PaginationRequest pagination)
        {
            return (await _repo.Filtrar(nombre, pagination)).Select(Toresponse).ToList();
        }
        public async Task<List<Dueñoresponse>> OrdenarAscAsync(PaginationRequest pagination)
        {
            return (await _repo.OrdenarAsc(pagination)).Select(Toresponse).ToList(); 
        }
        public async Task<List<Dueñoresponse>> OrdenarDescAsync(PaginationRequest pagination)
        {
            return (await _repo.OrdenarDesc(pagination)).Select(Toresponse).ToList();

          
                }
    }
}
