using ControleDeEstoque;
using ControleDeEstoque.Dominio;
using ControleDeEstoque.InfraestruturaDeDados.MigracaoBancoDeDados;
using ControleDeEstoque.InfraestruturaDeDados.Repositorios;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace InterfaceDeUsuario
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
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
                services.AddScoped<IRepositorio, RepositorioSqlServer>();
            });
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(ConfigurationManager.ConnectionStrings["SQL_Server_Controle_De_Estoque"].ConnectionString)
                    .ScanIn(typeof(_20231207105700_AdicionarTabelaTapecaria).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}