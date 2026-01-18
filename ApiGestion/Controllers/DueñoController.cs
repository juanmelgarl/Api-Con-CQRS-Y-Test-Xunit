using ApiGestion.DTOS.Request;
using ApiGestion.DTOS.Response;
using ApiGestion.Pagination;
using ApiGestion.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ApiGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñoController : ControllerBase
    {
        private readonly IMemoryCache _Cache;
        private readonly IDueñoCommand _command;
        private readonly IDueñoQueryService _Query;
        private readonly ILogger<DueñoController> _logger;
        private const string Cachekey = "listaproducots";
        public DueñoController(IDueñoCommand command, IDueñoQueryService query,IMemoryCache cache, ILogger<DueñoController>logger)
        {
            _command = command;
            _Query = query;
            _Cache = cache;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Dueñoresponse>>> Obtener([FromQuery] PaginationRequest pagination)
        {
            if (!_Cache.TryGetValue(Cachekey, out List<Dueñoresponse> dueño))
            {
                 dueño = await _Query.GetAllAsync(pagination);
                var CacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                _Cache.Set(Cachekey, dueño, CacheOptions);
            }
            _logger.LogInformation("Se obtuvo el Listado de Dueños");
            return Ok(dueño);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] UpdateDTO dto)
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
            _Cache.Remove(Cachekey);
            _logger.LogInformation("Se actualizo la informacion de un dueño");
            return Ok();
        }

        [Authorize]

        [HttpGet("porid")]
        public async Task<ActionResult<Dueñoresponse>> Obtenerporid([FromQuery] int id)
        {
            if (id <= 0)
                return BadRequest();
            if (!_Cache.TryGetValue(Cachekey, out Dueñoresponse people))
            {
                people = await _Query.GetForIdAsync(id);
                if (people == null)
                    return NotFound();
                var cacheoptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
                _Cache.Set(Cachekey, people, cacheoptions);
            }
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
            _Cache.Remove(Cachekey);
            return Ok(Dueño);
        }

    }
}
