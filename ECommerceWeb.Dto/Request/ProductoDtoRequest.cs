using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Dto.Request
{
    public class ProductoDtoRequest
    {
        [Required(ErrorMessage = Constantes.CampoRequerido)]
        [StringLength(100, ErrorMessage = Constantes.CampoLargoValidacion)]
        public string Nombre { get; set; } = default!;

        [Range(1, 100000, ErrorMessage = Constantes.RangoMaximo)]
        public float Precio { get; set; }

        public int CategoriaId { get; set; }
        public int? MarcaId { get; set; }

        public string? Base64Imagen { get; set; }
        public string? NombreArchivo { get; set; }
        public string? UrlImagen { get; set; }
    }
}
