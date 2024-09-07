using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones
{
    public class RepositoryBase<TEntidad> : IRepositoryBase<TEntidad>
        where TEntidad : EntidadBase
    {
        protected readonly DbContext Context;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<ICollection<TEntidad>> ListAsync()
        {
            return await Context
                .Set<TEntidad>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntidad>> ListAsync(Func<TEntidad, bool> predicado)
        {
            var collection = await Context.Set<TEntidad>()
                .Where(predicado)
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync();

            return collection;
        }

        public async Task<TEntidad?> FindByIdAsync(int id)
        {
            return await Context.Set<TEntidad>()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<int> AddAsync(TEntidad entidad)
        {
            await Context.Set<TEntidad>().AddAsync(entidad); // Esto lo agrega a la coleccion del DbSet
            await Context.SaveChangesAsync(); // Esto confirma el guardado del registro

            return entidad.Id;
        }

        public async Task UpdateAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Buscamos dentro de nuestra coleccion el ID que recibimos como argumento.
            var entidadExistente = await FindByIdAsync(id);
            if (entidadExistente is not null)
            {
                entidadExistente.Estado = false;
                await Context.SaveChangesAsync();
            }
        }
     
    }
}
