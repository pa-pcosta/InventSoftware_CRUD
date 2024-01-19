using ControleDeEstoque.InterfaceWindowsForms;
using Dominio;
using InfraestruturaDeDados.MigracaoBancoDeDados;
using InfraestruturaDeDados.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InterfaceWindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = MigracaoConfig.CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                MigracaoConfig.UpdateDatabase(scope.ServiceProvider);
            }

            var builder = CriaHostBuilder();
            var servicesProvider = builder.Build().Services;
            var repositorio = servicesProvider.GetService<IRepositorio>();

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaListagem(repositorio));
        }

        static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IRepositorio, RepositorioLinq2DB>();
            });
        }
    }
}