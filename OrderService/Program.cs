using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

// Swagger + Controller
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrazione del servizio
builder.Services.AddSingleton<IOrderService, OrderService.Services.OrderService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
