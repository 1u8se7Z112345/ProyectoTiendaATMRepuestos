using ECommerceWeb.Dto;

namespace ECommerceWeb.Client.Proxy;

public interface ICarritoProxy
{
    event Action? ActualizarVista;

    Task AgregarCarrito(CarritoDto carrito);

    Task EliminarCarrito(int idProducto);

    int CantidadProductos();

    Task<ICollection<CarritoDto>> ObtenerCarrito();

    Task LimpiarCarrito();
}