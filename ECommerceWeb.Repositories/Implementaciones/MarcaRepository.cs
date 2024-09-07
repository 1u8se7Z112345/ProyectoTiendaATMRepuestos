using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;

namespace ECommerceWeb.Repositories.Implementaciones;

public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
{
    public MarcaRepository(EcommerceDbContext context) 
        : base(context)
    {
    }
}