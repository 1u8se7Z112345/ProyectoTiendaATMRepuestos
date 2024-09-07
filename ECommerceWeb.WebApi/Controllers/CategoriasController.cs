using ECommerceWeb.Dto;
using ECommerceWeb.Dto.Request;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Constantes.RolAdministrador)]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriaRepository repository, ILogger<CategoriasController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Categorias
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var categorias = await _repository.ListMinimalAsync();

            _logger.LogInformation("Se obtuvieron las categorias");

            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _repository.FindByIdAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDtoRequest request)
        {
            var categoria = new Categoria
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion
            };

            var id = await _repository.AddAsync(categoria);

            return CreatedAtAction(nameof(Get), new { id }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CategoriaDtoRequest request)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
            {
                return NotFound();
            }

            entity.Nombre = request.Nombre;
            entity.Descripcion = request.Descripcion;

            await _repository.UpdateAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok();
        }
    }
}
