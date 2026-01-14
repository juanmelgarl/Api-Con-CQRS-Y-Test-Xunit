using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Models;
using ApiGestion.Repository;

namespace ApiGestion.Service
{
    public class DueñoCommandServicec : IDueñoCommand
    {
        private readonly IdueñoRepository _repo;

        public DueñoCommandServicec(IdueñoRepository repo)
        {
            _repo = repo;
        }
        public async Task<Dueñoresponse> CreateAsync(CreateDTO dto)
        {
            var dueño = new Dueño
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Dni = dto.Dni,
                Email = dto.Email,
            };
           await _repo.Add(dueño);
           await _repo.save();
            return new Dueñoresponse
            {
                IDdueño = dueño.Iddueño,
                Direccion = dueño.Direccion,
                Dni = dueño.Dni,
                Email = dueño.Email,
                Nombre = dueño.Nombre,
                Telefono = dto.Telefono,
            };
        }
        public async Task<bool> UpdateAsync(int id,UpdateDTO dto)
        {
            if (id <= 0)
            {
                return false;
            }
            if (dto is null)
            {
                return false; 
            }
         var Dueño =   await _repo.GetForId(id);
            if (Dueño is null)
            {
                return false;
            }
            Dueño.Telefono = dto.Telefono;
            Dueño.Nombre = dto.Nombre;
             Dueño.Email = dto.Email;
              Dueño.Dni = dto.Dni;
            await _repo.Update(Dueño);
         await   _repo.save();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                return false; 
            }
            var Delete = await _repo.GetForId(id);
            if (Delete is null)
            {
                return false; 
            }
            await _repo.Delete(Delete);
            return true;
        }
    }
}
