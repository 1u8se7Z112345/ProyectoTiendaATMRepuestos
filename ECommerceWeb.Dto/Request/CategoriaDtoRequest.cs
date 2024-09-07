using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class CategoriaDtoRequest
{
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [StringLength(50, ErrorMessage = Constantes.CampoLargoValidacion)]
    public string Nombre { get; set; } = default!;

    public string? Descripcion { get; set; }
}