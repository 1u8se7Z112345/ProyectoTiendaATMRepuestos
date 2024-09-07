using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Marca : EntidadBase
{
    public string Nombre { get; set; } = default!;
}