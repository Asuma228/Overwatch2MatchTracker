using Microsoft.Extensions.DependencyInjection;
using Overwatch2MatchTracker.DAL.Entities;
using Overwatch2MatchTracker.DAL.Entities.Base;
using Overwatch2MatchTraker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Game>,            GamesRepository>()
            .AddTransient<IRepository<GroupSize>,       DbRepository<GroupSize>>()
            .AddTransient<IRepository<Hero>,            DbRepository<Hero>>()
            .AddTransient<IRepository<Map>,             DbRepository<Map>>()
            .AddTransient<IRepository<MatchResult>,     DbRepository<MatchResult>>()
            .AddTransient<IRepository<Mode>,            DbRepository<Mode>>()
            .AddTransient<IRepository<SpecificPlayer>,  DbRepository<SpecificPlayer>>()
            ;

    }
}
