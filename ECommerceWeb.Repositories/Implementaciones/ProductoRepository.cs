using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Entities.Infos;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
{
    public ProductoRepository(EcommerceDbContext context)
        : base(context)
    {
    }

    public async Task<ICollection<ProductoInfo>> ListAsync(string filtro)
    {
        // SOLO CON SQL SERVER
        //var coleccion = Context.Database.SqlQueryRaw<ProductoInfo>("EXEC uspListarProductos {0}", filtro);

        var coleccion = Context.Set<Producto>()
            .Where(p => p.Nombre.Contains(filtro))
            .Select(x => new ProductoInfo
            {
                Id = x.Id,
                Categoria = x.Categoria.Nombre,
                CategoriaId = x.CategoriaId,
                Nombre = x.Nombre,
                Precio = x.Precio,
                Marca = x.Marca != null ? x.Marca.Nombre : "-",
                UrlImagen = x.UrlImagen
            })
            .AsNoTracking()
            .AsQueryable();

        return await coleccion.ToListAsync();
    }
}