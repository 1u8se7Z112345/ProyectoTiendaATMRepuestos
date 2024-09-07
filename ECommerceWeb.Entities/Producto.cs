namespace ECommerceWeb.Entities;

public class Producto : EntidadBase
{
    public string Nombre { get; set; } = null!;

    public float Precio { get; set; }

    public int CategoriaId { get; set; }

    public Categoria Categoria { get; set; } = null!;

    public Marca? Marca { get; set; } 

    public int? MarcaId { get; set; }

    public string? UrlImagen { get; set; }
}
