using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Entities;

public class Cliente : EntidadBase
{

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }
}
