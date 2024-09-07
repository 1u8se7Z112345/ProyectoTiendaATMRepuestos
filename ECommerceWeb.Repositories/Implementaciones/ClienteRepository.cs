using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class ClienteRepository(EcommerceDbContext context) : RepositoryBase<Cliente>(context), IClienteRepository
{
    public async Task<Cliente?> BuscarPorEmailAsync(string email)
    {
        return await Context.Set<Cliente>().FirstOrDefaultAsync(c => c.Email == email);
    }
}