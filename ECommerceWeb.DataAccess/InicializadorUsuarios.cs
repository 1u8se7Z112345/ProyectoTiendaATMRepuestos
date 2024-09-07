using ECommerceWeb.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceWeb.DataAccess;

public static class InicializadorUsuarios
{
    public static async Task Crear(IServiceProvider service)
    {
        // UserManager (repositorio de usuarios)
        var userManager = service.GetRequiredService<UserManager<ECommerceIdentity>>();

        // RoleManager (repositorio de roles)
        var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear roles
        var adminRole = new IdentityRole(Constantes.RolAdministrador);
        var clienteRole = new IdentityRole(Constantes.RolCliente);

        await roleManager.CreateAsync(adminRole);
        await roleManager.CreateAsync(clienteRole);

        // Usuario Administrador
        var adminUser = new ECommerceIdentity
        {
            NombreCompleto = "Administrador del Sistema",
            FechaNacimiento = DateOnly.Parse("1995-08-04"),
            Direccion = "Av.Peru 345 Chiclayo",
            UserName = "admin",
            Email = "admin@atmrepuestos.com",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, "pa$$W0rD@123");
        if (result.Succeeded)
        {
            // Si se crea correctamente el usuario, asignamos el rol de administrador
            await userManager.AddToRoleAsync(adminUser, Constantes.RolAdministrador);
        }
    }
}