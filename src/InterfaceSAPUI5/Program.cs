using Dominio;
using InfraestruturaDeDados.MigracaoBancoDeDados;
using InfraestruturaDeDados.Repositorios;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

using (var serviceProvider = MigracaoConfig.CreateServices())
using (var scope = serviceProvider.CreateScope())
{
    MigracaoConfig.UpdateDatabase(scope.ServiceProvider);
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepositorio, RepositorioLinq2DB>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
),

    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings = { [".properties"] = "application/x-msdownload" }
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
