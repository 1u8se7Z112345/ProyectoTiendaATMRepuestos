using Microsoft.AspNetCore.Identity;

namespace ECommerceWeb.DataAccess
{
    public class ECommerceIdentity : IdentityUser
    {
        public string NombreCompleto { get; set; } = default!;

        public DateOnly FechaNacimiento { get; set; }

        public string Direccion { get; set; } = default!;
    }
}
