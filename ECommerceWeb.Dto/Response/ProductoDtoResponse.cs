namespace ECommerceWeb.Dto.Response;

public class ProductoDtoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public float Precio { get; set; }
    public int CategoriaId { get; set; }
    public string Categoria { get; set; } = default!;
    public int? MarcaId { get; set; }
    public string? Marca { get; set; }
    public string? UrlImagen { get; set; }
}