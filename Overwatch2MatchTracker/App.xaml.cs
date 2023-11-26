using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Overwatch2MatchTracker.Data;
using Overwatch2MatchTracker.Services;
using Overwatch2MatchTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Overwatch2MatchTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static IHost __Host;
        private static IHost Host => __Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("DataBase"))
            .AddServices()
            .AddViewModels()
            ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            using(var scope = Services.CreateScope())
                await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (var host = Host)
            base.OnExit(e);
            await Host.StopAsync();
        }
    }
}
