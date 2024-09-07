using ECommerceWeb.DataAccess;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECommerceWeb.Repositories.Implementaciones;

public class VentaRepository : RepositoryBase<Venta>, IVentaRepository
{
    public VentaRepository(EcommerceDbContext context) : base(context)
    {
    }

    public override async Task<int> AddAsync(Venta entidad)
    {
        var cantidad = await Context.Set<Venta>().CountAsync();

        entidad.NumeroFactura = $"F001-{cantidad + 1:000000}";

        await Context.AddAsync(entidad);

        return entidad.Id;
    }

    public async Task CrearTransaccionAsync()
    {
        await Context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
    }

    public async Task ConfirmarTransaccionAsync()
    {
        await Context.Database.CommitTransactionAsync();
        await Context.SaveChangesAsync();
    }

    public async Task ResetearTransaccionAsync()
    {
        await Context.Database.RollbackTransactionAsync();
    }

    public async Task<Dashboard> MostrarDashboard()
    {
        var query = Context.Database.SqlQueryRaw<Dashboard>("EXEC uspDashboard");

        var collection = await query.ToListAsync();

        return collection.First();
    }
}