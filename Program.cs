using Microsoft.EntityFrameworkCore;
using OperacoesService.Data;
using OperacoesService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemory"));

builder.Services.AddScoped<IOperacoesRepository, OperacoesRepository>();
builder.Services.AddScoped<IContasRepository, ContasRepository>();
builder.Services.AddHttpClient<IContasServiceClient, HttpContasServiceClient>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
