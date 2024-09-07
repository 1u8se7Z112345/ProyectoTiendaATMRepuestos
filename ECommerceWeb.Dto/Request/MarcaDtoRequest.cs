using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class MarcaDtoRequest
{
    [StringLength(50, ErrorMessage = Constantes.CampoLargoValidacion)]
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Nombre { get; set; } = default!;
}