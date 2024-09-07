using ECommerceWeb.Entities;

namespace ECommerceWeb.Repositories.Interfaces
{
    // Aqui haremos un CRUD (CREATE, READ, UPDATE, DELETE)

    public interface IRepositoryBase<TEntidad>
        where TEntidad : EntidadBase // <----- Esto es un constraint (regla)
    {
        Task<ICollection<TEntidad>> ListAsync();

        Task<ICollection<TEntidad>> ListAsync(Func<TEntidad, bool> predicado);

        Task<TEntidad?> FindByIdAsync(int id);

        Task<int> AddAsync(TEntidad entidad);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
