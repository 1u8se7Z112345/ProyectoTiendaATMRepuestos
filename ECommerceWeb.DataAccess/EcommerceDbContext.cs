using System.Reflection;
using ECommerceWeb.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.DataAccess;

public class EcommerceDbContext : IdentityDbContext<ECommerceIdentity>
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; } = default!;
    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Producto> Productos { get; set; } = default!;
    public DbSet<Venta> Ventas { get; set; } = default!;
    public DbSet<VentaDetalle> VentaDetalles { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // aplicamos una configuracion personalizada de entidades
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Marca>()
            .HasQueryFilter(p => p.Estado);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        // Aqui le digo que todas las propiedades de entidades que sean string solo deben
        // tener 100 caracteres como maximo.
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }
}
