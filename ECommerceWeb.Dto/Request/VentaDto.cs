namespace ECommerceWeb.Dto.Request
{
    public record VentaDto(float Total, ICollection<VentaDetalleDto> VentaDetalles);

    public record VentaDetalleDto(int ProductoId, int Cantidad, float Precio, float Total);
}
