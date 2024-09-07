using ECommerceWeb.Dto.Response;

namespace ECommerceWeb.Client.Proxy
{
    public interface IProductoProxy
    {
        Task<ICollection<ProductoDtoResponse>> ListAsync(string filtro);

        Task<ProductoDtoResponse?> FindByIdAsync(int id);
    }
}
