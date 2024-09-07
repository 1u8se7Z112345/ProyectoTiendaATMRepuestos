using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntegracionSp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE uspDashboard 
                    AS
                    BEGIN

	                    SELECT 
		                    ISNULL(SUM(V.TotalVenta),0) TotalVenta,
		                    COUNT(V.Id) CantidadVentas,
		                    (SELECT COUNT(*) FROM Clientes) CantidadClientes,
		                    (SELECT COUNT(*) FROM Productos) CantidadProductos
	                    FROM Ventas V (NOLOCK)
	                    WHERE V.Estado = 1
	                       
                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE uspDashboard");
        }
    }
}
