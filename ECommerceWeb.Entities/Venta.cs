using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Venta : EntidadBase
{
    public string NumeroFactura { get; set; } = null!;

    public DateTime FechaVenta { get; set; }

    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; } = null!;

    public float TotalVenta { get; set; }
    
    public ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
