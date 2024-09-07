using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using ECommerceWeb.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repository;
    private readonly ILogger<ProductosController> _logger;
    private readonly IFileUploader _fileUploader;

    public ProductosController(IProductoRepository repository, ILogger<ProductosController> logger, IFileUploader fileUploader)
    {
        _repository = repository;
        _logger = logger;
        _fileUploader = fileUploader;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? filtro)
    {
        var coleccion = await _repository.ListAsync(filtro ?? string.Empty);

        var response = coleccion.Select(p => new ProductoDtoResponse
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio,
            CategoriaId = p.CategoriaId,
            Categoria = p.Categoria,
            Marca = p.Marca,
            UrlImagen = p.UrlImagen
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _repository.FindByIdAsync(id);

        if (entity is null)
            return NotFound();

        return Ok(new ProductoDtoResponse
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Precio = entity.Precio,
            CategoriaId = entity.CategoriaId,
            Categoria = entity.Categoria?.Nombre ?? string.Empty,
            MarcaId = entity.MarcaId,
            Marca = entity.Marca?.Nombre,
            UrlImagen = entity.UrlImagen
        });
    }

    [HttpPost]
    public async Task< IActionResult> Post(ProductoDtoRequest request)
    {
        var entity = new Producto
        {
            Nombre = request.Nombre,
            Precio = request.Precio,
            CategoriaId = request.CategoriaId,
            MarcaId = request.MarcaId
        };

        entity.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);

        await _repository.AddAsync(entity);

        return Created($"api/productos/{entity.Id}", entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, ProductoDtoRequest request)
    {
        var registro = await _repository.FindByIdAsync(id);
        if (registro is null)
            return NotFound();

        registro.Nombre = request.Nombre;
        registro.Precio = request.Precio;
        registro.CategoriaId = request.CategoriaId;
        registro.MarcaId = request.MarcaId;

        if (!string.IsNullOrEmpty(request.Base64Imagen))
        {
            registro.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
        }

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