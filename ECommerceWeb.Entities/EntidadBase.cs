using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class EntidadBase
{
    [Key]
    public int Id { get; set; }

    public bool Estado { get; set; }

    protected EntidadBase()
    {
        Estado = true;
    }
}