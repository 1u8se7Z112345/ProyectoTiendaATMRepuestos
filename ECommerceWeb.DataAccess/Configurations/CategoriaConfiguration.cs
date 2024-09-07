using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceWeb.DataAccess.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(p => p.Nombre)
                .HasMaxLength(50);

            // Data seeding
            builder.HasData(new List<Categoria>
            {
                new() { Id = 1, Nombre = "Celulares", Descripcion = "Celulares de Alta gama" },
                new() { Id = 2, Nombre = "Televisores", Descripcion = "Electrodomesticos para el hogar" },
                new() { Id = 3, Nombre = "Computadoras Portátiles", Descripcion = "Solo Laptops" },
            });
        }
    }
}
