namespace ECommerceWeb.Entities.Infos;

public class ProductoInfo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public float Precio { get; set; }
    public int CategoriaId { get; set; }
    public string Categoria { get; set; } = default!;
    public string? Marca { get; set; }
    public string? UrlImagen { get; set; }
}