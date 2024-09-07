using ECommerceWeb.Dto.Response;

namespace ECommerceWeb.Dto;

public class CarritoDto
{
    public ProductoDtoResponse ProductoDto { get; set; } = default!;

    public int Cantidad { get; set; }
    public float Precio { get; set; }
    public float Total { get; set; }
}