using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerceWeb.Dto;

namespace ECommerceWeb.Client.Proxy;

public class CarritoProxy : ICarritoProxy
{
    private readonly ILocalStorageService _localStorageService;
    private readonly ISyncLocalStorageService _syncLocalStorageService;
    private readonly IToastService _toastService;

    public CarritoProxy(ILocalStorageService localStorageService, 
        ISyncLocalStorageService syncLocalStorageService, 
        IToastService toastService)
    {
        _localStorageService = localStorageService;
        _syncLocalStorageService = syncLocalStorageService;
        _toastService = toastService;
    }

    public event Action? ActualizarVista;

    public async Task AgregarCarrito(CarritoDto carrito)
    {
        try
        {
            var cart = await _localStorageService.GetItemAsync<ICollection<CarritoDto>>("carrito")
                 ?? new List<CarritoDto>();

            var producto = cart.FirstOrDefault(x => x.ProductoDto.Id == carrito.ProductoDto.Id);
            if (producto is not null)
            {
                cart.Remove(producto);
            }

            cart.Add(carrito);
            await _localStorageService.SetItemAsync("carrito", cart);

            _toastService.ShowSuccess(producto is not null 
                ? "Producto fue actualizado en el carrito"
                : "Producto fue agregado al carrito");

            ActualizarVista?.Invoke();
        }
        catch (Exception)
        {
            _toastService.ShowError("No se puede agregar al carrito");
        }
    }

    public async Task EliminarCarrito(int idProducto)
    {
        try
        {
            var cart = await _localStorageService.GetItemAsync<ICollection<CarritoDto>>("carrito")
                       ?? new List<CarritoDto>();

            var producto = cart.FirstOrDefault(x => x.ProductoDto.Id == idProducto);
            if (producto is not null)
            {
                cart.Remove(producto);
                await _localStorageService.SetItemAsync("carrito", cart);
                ActualizarVista?.Invoke();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _toastService.ShowError("No se pudo quitar del carrito");
        }
    }

    public int CantidadProductos()
    {
        var carrito = _syncLocalStorageService.GetItem<ICollection<CarritoDto>>("carrito");
        return carrito?.Count ?? 0;
    }

    public async Task<ICollection<CarritoDto>> ObtenerCarrito()
    {
        return await _localStorageService.GetItemAsync<ICollection<CarritoDto>>("carrito") ?? new List<CarritoDto>();
    }

    public async Task LimpiarCarrito()
    {
        await _localStorageService.RemoveItemAsync("carrito");
        ActualizarVista?.Invoke();
    }
}