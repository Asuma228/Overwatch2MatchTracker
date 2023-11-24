using Microsoft.Extensions.DependencyInjection;
using Overwatch2MatchTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.Services
{
    static class SericesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
