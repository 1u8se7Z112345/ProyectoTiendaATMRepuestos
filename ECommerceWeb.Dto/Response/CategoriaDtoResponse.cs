﻿namespace ECommerceWeb.Dto.Response;

public class CategoriaDtoResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string? Descripcion { get; set; }
}