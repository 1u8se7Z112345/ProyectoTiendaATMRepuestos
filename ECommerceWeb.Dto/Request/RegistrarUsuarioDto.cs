using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request;

public class RegistrarUsuarioDto
{
    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Nombre Completo")]
    public string NombreCompleto { get; set; } = default!;

    [Display(Name = "Fecha de Nacimiento")]
    public DateTime FechaNacimiento { get; set; } = DateTime.Today.AddYears(-20);

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Direccion { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    [Display(Name = "Nombre de usuario")]
    public string NombreUsuario { get; set; } = default!;

    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = Constantes.CampoRequerido)]
    public string Password { get; set; } = default!;

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = default!;
}