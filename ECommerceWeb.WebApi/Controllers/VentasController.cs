using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ECommerceWeb.Dto;

namespace ECommerceWeb.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentasController : ControllerBase
{
    private readonly IVentaRepository _repository;
    private readonly ILogger<VentasController> _logger;
    private readonly IClienteRepository _clienteRepository;

    public VentasController(IVentaRepository repository, ILogger<VentasController> logger, IClienteRepository clienteRepository)
    {
        _repository = repository;
        _logger = logger;
        _clienteRepository = clienteRepository;
    }

    [HttpPost]
    [Authorize(Roles = Constantes.RolCliente)]
    public async Task<IActionResult> Post(VentaDto request)
    {
        var response = new BaseResponse();

        try
        {
            // Buscamos el ID del cliente basado en el correo de la autenticacion
            var email = HttpContext.User.Claims.First(o => o.Type == ClaimTypes.Email).Value;

            var cliente = await _clienteRepository.BuscarPorEmailAsync(email);

            if (cliente is null)
            {
                response.MensajeError = $"El Cliente con el correo {email} no existe!";
                return BadRequest(response);
            }

            var venta = new Venta
            {
                ClienteId = cliente.Id,
                FechaVenta = DateTime.Now,
                TotalVenta = request.Total,
                VentaDetalles = request.VentaDetalles.Select(p => new VentaDetalle()
                {
                    ProductoId = p.ProductoId,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.Precio,
                    Total = p.Total,
                }).ToList()
            };

            await _repository.CrearTransaccionAsync();
            await _repository.AddAsync(venta);

            await _repository.ConfirmarTransaccionAsync();

            _logger.LogInformation("Se creó la venta de forma exitosa");

            response.Exito = true;

            return Ok(response);

        }
        catch (Exception ex)
        {
            response.MensajeError = "Error al crear la venta";
            await _repository.ResetearTransaccionAsync();
            _logger.LogCritical(ex, "{MensajeError} {Message}", response.MensajeError, ex.Message);
            return BadRequest(response);
        }
    }

    [HttpGet("dashboard")]
    [Authorize(Roles = Constantes.RolAdministrador)]
    public async Task<IActionResult> Get()
    {
        var response = await _repository.MostrarDashboard();

        return Ok(response);
    }
}