using ECommerceWeb.DataAccess;
using ECommerceWeb.Repositories.Implementaciones;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerceWeb.WebApi.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Warning)
    .CreateLogger();

//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDb"));
});
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IMarcaRepository, MarcaRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IVentaRepository, VentaRepository>();

builder.Services.AddTransient<IFileUploader, FileUploader>();

// Configuramos ASP.NET Core Identity
builder.Services.AddIdentity<ECommerceIdentity, IdentityRole>(policies =>
    {
        // Politicas de clave
        policies.Password.RequireDigit = false;
        policies.Password.RequireLowercase = false;
        policies.Password.RequireUppercase = true;
        policies.Password.RequireNonAlphanumeric = true;
        policies.Password.RequiredLength = 8;

        // Politicas de Usuario
        policies.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<EcommerceDbContext>()
    .AddDefaultTokenProviders();

// Configuramos el contexto de seguridad del API
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"] ??
                                           throw new InvalidOperationException("No se configuro el SecretKey"));

    // Con estos parametros validamos la autenticidad del token
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Emisor"],
        ValidAudience = builder.Configuration["Jwt:Audiencia"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// Autenticacion (Validacion de identidad)
app.UseAuthentication();

// Autorizacion (Validacion de permisos)
app.UseAuthorization();

//// Esto es un minimal API
app.MapGet("/api/v2/categorias", async (ICategoriaRepository repositorio) => Results.Ok(await repositorio.ListAsync()));

//app.MapGet("/api/categorias/{id:int}", (ICategoriaRepository repositorio, int id) =>
//{
//    var registro = repositorio.FindByIdAsync(id);
//    if (registro is null)
//        return Results.NotFound();

//    return Results.Ok(registro);
//});

//app.MapPost("/api/categorias", (ICategoriaRepository repositorio, Categoria categoria) =>
//{
//    repositorio.AddAsync(categoria);

//    return Results.Created($"/api/categorias/{categoria.Id}", categoria);
//});

//app.MapPut("/api/categorias/{id:int}", (ICategoriaRepository repositorio, int id, Categoria categoria) =>
//{
//    repositorio.UpdateAsync(id, categoria);

//    return Results.Ok();
//});

//app.MapDelete("/api/categorias/{id:int}", (ICategoriaRepository repositorio, int id) =>
//{
//    repositorio.DeleteAsync(id);

//    return Results.Ok();
//});


app.MapControllers();
app.MapFallbackToFile("index.html");

await using var scope = app.Services.CreateAsyncScope();
{
    await InicializadorUsuarios.Crear(scope.ServiceProvider);
}

app.Run();
