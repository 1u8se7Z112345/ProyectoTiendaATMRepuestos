using ECommerceWeb.Dto.Request;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly IMarcaRepository _repository;

    public MarcasController(IMarcaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var marcas = await _repository.ListAsync();

        return Ok(marcas);
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
    public async Task<IActionResult> Post(MarcaDtoRequest request)
    {
        var marca = new Marca
        {
            Nombre = request.Nombre,
        };

        var id = await _repository.AddAsync(marca);

        return CreatedAtAction(nameof(Get), new { id }, marca);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, MarcaDtoRequest request)
    {
        var entity = await _repository.FindByIdAsync(id);
        if (entity is null)
        {
            return NotFound();
        }

        entity.Nombre = request.Nombre;

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