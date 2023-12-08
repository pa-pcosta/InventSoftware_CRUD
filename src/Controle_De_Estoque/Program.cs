using Controle_De_Estoque.Migracao_Banco_de_Dados;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Controle_De_Estoque
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

            ApplicationConfiguration.Initialize();
            Application.Run(new TelaInicial());
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