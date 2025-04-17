using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<RabbitMQConsumer>();

// Adiciona suporte a controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia controllers
app.MapControllers();

app.Run();
