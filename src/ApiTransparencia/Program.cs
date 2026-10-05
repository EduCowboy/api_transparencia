var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers
builder.Services.AddControllers();

// Adiciona o OpenAPI/Swagger nativo do .NET para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Aqui você registrará suas injeções de dependência (Services e Repositories) futuramente:
// builder.Services.AddScoped();
// builder.Services.AddScoped();

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia automaticamente os controllers da aplicação
app.MapControllers();

app.Run();