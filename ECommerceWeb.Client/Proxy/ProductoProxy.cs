using System.Net.Http.Json;
using ECommerceWeb.Dto.Response;

namespace ECommerceWeb.Client.Proxy;

public class ProductoProxy : IProductoProxy
{
    private readonly HttpClient _httpClient;

    public ProductoProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ICollection<ProductoDtoResponse>> ListAsync(string filtro)
    {
        var response = await _httpClient.GetAsync($"api/Productos?filtro={filtro}");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ICollection<ProductoDtoResponse>>();

        if (result != null)
        {
            return result;
        }

        throw new InvalidOperationException(response.ReasonPhrase);
    }

    public async Task<ProductoDtoResponse?> FindByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Productos/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ProductoDtoResponse>();
    }
}