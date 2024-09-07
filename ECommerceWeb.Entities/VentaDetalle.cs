namespace ECommerceWeb.Entities;

public class VentaDetalle : EntidadBase
{
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = null!;

    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    public float PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public float Total { get; set; }
}
