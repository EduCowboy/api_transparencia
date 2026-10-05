using ApiTransparencia.Domain.Interfaces;
using ApiTransparencia.Repositories;
using ApiTransparencia.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers
builder.Services.AddControllers();

// Registra o Repository (com HttpClient) e o Service
builder.Services.AddHttpClient();
builder.Services.AddScoped<IDeputadosRepository, DeputadosRepository>();
builder.Services.AddScoped<IDeputadosService, DeputadosService>();

// Adiciona os serviços do Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activa o Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Isto cria a interface gráfica em /swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();