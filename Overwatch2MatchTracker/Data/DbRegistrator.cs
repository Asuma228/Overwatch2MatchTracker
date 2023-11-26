using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Overwatch2MatchTracker.DAL.Context;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<Overwatch2MatchTrackerDB>(opt =>
            {
                var type = Configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определён тип БД");
                    default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                    case "MSSQL":
                        opt.UseSqlServer(Configuration.GetConnectionString(type));
                        break;
                    case "SQLite":
                        opt.UseSqlite(Configuration.GetConnectionString(type));
                        break;
                }
            })
            ;
    }
}
