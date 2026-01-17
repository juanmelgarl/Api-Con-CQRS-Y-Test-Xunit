using ApiGestion.Models;

namespace ApiGestion.Repository
{
    public interface IusuarioRepository
    {
       
            Usuarios? GetByEmail(string email);
        Usuarios? GetById(int id);
            void Add(Usuarios usuario);
            void Update(Usuarios usuario);
        Task Delete(Usuarios usuario);
        Task<List<Usuarios>> ObtenerTodos();
    }

}

