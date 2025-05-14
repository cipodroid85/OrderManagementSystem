using ProductService.Services;
using ProductService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Aggiunta dei servizi al contenitore DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrazione del servizio prodotto
builder.Services.AddSingleton<IProductService, ProductService.Services.ProductService>();

var app = builder.Build();

// Attivazione Swagger sempre (dev + Docker)
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
