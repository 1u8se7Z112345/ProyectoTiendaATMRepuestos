using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.Property(p => p.FechaVenta)
            .HasColumnType("DATE");

        builder.Property(p => p.NumeroFactura)
            .HasMaxLength(20);
    }
}