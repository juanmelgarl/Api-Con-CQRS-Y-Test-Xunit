using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Pagination;
using ApiGestion.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñoController : ControllerBase
    {
        private readonly IDueñoCommand _command;
        private readonly IDueñoQueryService _Query;
        public DueñoController(IDueñoCommand command, IDueñoQueryService query)
        {
            _command = command;
            _Query = query;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Dueñoresponse>>> Obtener([FromQuery]PaginationRequest pagination)
        {
            var people = await _Query.GetAllAsync(pagination);
            return Ok(people);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Dueñoresponse>> Actualizar([FromQuery]UpdateDTO dto,int id)
        {
            if (dto is null)
            {
                return BadRequest();
            }
            if (id <= 0)
            {
                return BadRequest();
            }
            var Dueño = await _command.UpdateAsync(id, dto);
            if (!Dueño)
            {
                return NotFound();
            }
            return Ok();
        }

        [Authorize]

        [HttpGet("{id}")]
        public async Task<ActionResult<Dueñoresponse>> Obtenerporid([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var people = await _Query.GetForIdAsync(id);
            if (people == null)
                return NotFound();
            return Ok(people);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Dueñoresponse>> CrearDueño([FromBody] CreateDTO dto)
        {
            if (dto is null)
                {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Dueño = await _command.CreateAsync(dto);
            return Ok(Dueño);
        }

    }
}
