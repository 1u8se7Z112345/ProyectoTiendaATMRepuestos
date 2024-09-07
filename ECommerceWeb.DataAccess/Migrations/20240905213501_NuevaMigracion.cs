using ECommerceWeb.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;

#nullable disable

namespace ECommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Habilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Marca] ON");

            // Insertar los datos
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (1, N'Honda', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (2, N'Ambrosol', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (3, N'Bosh', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (4, N'Castrol', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (5, N'Federal', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (6, N'Philips', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (7, N'Frestone', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (8, N'Vistony', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (9, N'GoodYear', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (10, N'Rydanz', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Marca] ([Id], [Nombre], [Estado]) VALUES (11, N'Generico', 1)");

            // Deshabilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Marca] OFF");

            // Habilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Categorias] ON");

            // Insertar los datos
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Celulares', N'Celulares de Alta gama', 0)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Televisores', N'Electrodomesticos para el hogar', 0)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Computadoras Portátiles', N'Solo Laptops', 0)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Pinturas', N'Lo mejor en pinturas', 0)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (5, N'Aros', N'Lo mejor en aros', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (6, N'Amortiguadores', N'Lo mejor de amortiguadores', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (7, N'Filtros', N'Lo mejor de filtros', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (8, N'Aceites y Repuestos de Motos', N'Lo mejor en aceites y repuestos', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (9, N'Aceites y grasas', N'Lo mejor en Aceites y grasas', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (10, N'Refrigerantes', N'Lo mejor en refrigerantes', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (11, N'Faros y Focos', N'Lo mejor en faros y focos', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (12, N'Frenos', N'Lo mejor en frenos', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (13, N'Motores', N'Lo mejor en Motores', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (14, N'Llantas', N'Lo mejor en llantas', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (15, N'Generico', N'Productos genéricos', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (16, N'Autoradios', N'Lo mejor en Autoradios', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (17, N'Baterias', N'Lo mejor en baterías', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (18, N'Bobina', N'Lo mejor en bobinas', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (19, N'Bujias', N'Lo mejor en bujías', 1)");
            migrationBuilder.Sql("INSERT [dbo].[Categorias] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (20, N'Focos', N'Lo mejor en focos', 1)");

            // Deshabilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Categorias] OFF");



            // Habilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Productos] ON");

            // Insertar los datos
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (1, N'Llanta GoodYear aro 14', 250, 14, 1, 9, N'/uploads/llanta.jfif')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (2, N'Aceite Motor Castrol', 45, 9, 1, 4, N'/uploads/Aceite_motor_Castrol.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (3, N'Autoradio CD USB AUXILIAR', 60, 16, 1, 11, N'/uploads/Autoradio_CD_USB_AUXILIAR.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (4, N'Bateria Hella CCA 1160', 500, 17, 1, 1, N'/uploads/Bateria_Hella_CCA_1160.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (5, N'bobina encendido nissan logan', 45, 18, 1, 2, N'/uploads/bobina_encendido_nissan_logan.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (6, N'Bujia de encendido', 28, 19, 1, 11, N'/uploads/Bujia_de_encendido.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (7, N'Camara Llanta F457', 182, 14, 1, 1, N'/uploads/Camara_llantas.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (8, N'Foco h11 12v', 47, 20, 1, 10, N'/uploads/Foco_h11_12v.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (9, N'Foco Phillips', 26, 20, 1, 6, N'/uploads/Foco_phillips.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (10, N'Llanta Honda Aro 17', 247, 14, 1, 1, N'/uploads/llanta_2.webp')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (11, N'Neumatico bicicleta', 140, 14, 1, 7, N'/uploads/neumatico_bicicleta.webp')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (12, N'Parlante de 6 coxial', 54, 16, 1, 3, N'/uploads/parlante_de_6_coxial.jpg')");
            migrationBuilder.Sql("INSERT [dbo].[Productos] ([Id], [Nombre], [Precio], [CategoriaId], [Estado], [MarcaId], [UrlImagen]) VALUES (13, N'Llanta GoodYear aro 16 Deportivo', 120, 15, 1, 9, N'/uploads/Llantas_GoodYear_DirectionSport185.webp')");

            // Deshabilitar IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Productos] OFF");

          




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
