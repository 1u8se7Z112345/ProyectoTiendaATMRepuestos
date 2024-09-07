using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EcommerceDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Categoria>> ListMinimalAsync()
        {
            return await Context.Set<Categoria>()
                .Where(p => p.Estado)
                .AsNoTracking()
                .Select(x => new Categoria
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion
                })
                .ToListAsync();
        }
    }
}
