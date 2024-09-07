using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class LoginDtoRequest
{
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Usuario { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Password { get; set; } = default!;
}