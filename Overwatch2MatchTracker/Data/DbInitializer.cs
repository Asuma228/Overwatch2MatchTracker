using MathCore.Functions.Differentiable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Overwatch2MatchTracker.DAL.Context;
using Overwatch2MatchTracker.DAL.Entities;
using Overwatch2MatchTracker.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.Data
{
    internal class DbInitializer
    {
        private readonly Overwatch2MatchTrackerDB _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(Overwatch2MatchTrackerDB db, ILogger<DbInitializer> Logger) 
        {
            _db = db;
            _logger = Logger;
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация БД...");

            _logger.LogInformation("Удаление существующей БД...");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);

            _logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync();
            _logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Games.AnyAsync()) return;
            await InitializeHeroes();
            await InitializeMaps();
            await InitializeGroupSizes();
            await InitializeModes();
            _logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);

        }

        private Hero[] _Hero;
        private async Task InitializeHeroes()
        {
            
            
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация списка героев...");

            _Hero = new Hero[39];
            _Hero[1] = new Hero { Name = "Ana" };
            _Hero[2] = new Hero { Name = "Ashe" };
            _Hero[3] = new Hero { Name = "Baptiste" };
            _Hero[4] = new Hero { Name = "Bastion" };
            _Hero[5] = new Hero { Name = "Brigitte" };
            _Hero[6] = new Hero { Name = "Cassidy" };
            _Hero[7] = new Hero { Name = "D.Va" };
            _Hero[8] = new Hero { Name = "Doomfist" };
            _Hero[9] = new Hero { Name = "Echo" };
            _Hero[10] = new Hero { Name = "Genji" };
            _Hero[11] = new Hero { Name = "Hanzo" };
            _Hero[12] = new Hero { Name = "Illari" };
            _Hero[13] = new Hero { Name = "Junker Queen" };
            _Hero[14] = new Hero { Name = "Junkrat" };
            _Hero[15] = new Hero { Name = "Kiriko" };
            _Hero[16] = new Hero { Name = "Lifeweaver" };
            _Hero[17] = new Hero { Name = "Lucio" };
            _Hero[18] = new Hero { Name = "Mauga" };
            _Hero[19] = new Hero { Name = "Mei" };
            _Hero[20] = new Hero { Name = "Mercy" };
            _Hero[21] = new Hero { Name = "Moira" };
            _Hero[22] = new Hero { Name = "Orisa" };
            _Hero[23] = new Hero { Name = "Pharah" };
            _Hero[24] = new Hero { Name = "Rammatra" };
            _Hero[25] = new Hero { Name = "Reaper" };
            _Hero[26] = new Hero { Name = "Reinhardt" };
            _Hero[27] = new Hero { Name = "Roadhog" };
            _Hero[28] = new Hero { Name = "Sigma" };
            _Hero[29] = new Hero { Name = "Sojourn" };
            _Hero[30] = new Hero { Name = "Soldier:76" };
            _Hero[31] = new Hero { Name = "Sombra" };
            _Hero[32] = new Hero { Name = "Symmetra" };
            _Hero[33] = new Hero { Name = "Torbjörn" };
            _Hero[34] = new Hero { Name = "Tracer" };
            _Hero[35] = new Hero { Name = "Widowmaker" };
            _Hero[36] = new Hero { Name = "Winston" };
            _Hero[37] = new Hero { Name = "Wrecking Ball" };
            _Hero[38] = new Hero { Name = "Zarya" };
            _Hero[0] = new Hero { Name = "Zenyatta" };
            await _db.Heroes.AddRangeAsync(_Hero);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация списка героев выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private Map[] _Maps;
        private async Task InitializeMaps()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация списка карт...");

            _Maps = new Map[27];
            _Maps[1] = new Map { Name = "Antarctic Peninsula" };
            _Maps[2] = new Map { Name = "Busan" };
            _Maps[3] = new Map { Name = "Ilios" };
            _Maps[4] = new Map { Name = "Lijiang Tower" };
            _Maps[5] = new Map { Name = "Nepal" };
            _Maps[6] = new Map { Name = "Oasis" };
            _Maps[7] = new Map { Name = "Samoa" };
            _Maps[8] = new Map { Name = "Circuit Royal" };
            _Maps[9] = new Map { Name = "Dorado" };
            _Maps[10] = new Map { Name = "Havana" };
            _Maps[11] = new Map { Name = "Junkertown" };
            _Maps[12] = new Map { Name = "Rialto" };
            _Maps[13] = new Map { Name = "Route 66" };
            _Maps[14] = new Map { Name = "Shambali Monastery" };
            _Maps[15] = new Map { Name = "Watchpoint: Gibraltar" };
            _Maps[16] = new Map { Name = "New Junk City" };
            _Maps[17] = new Map { Name = "Suravasa" };
            _Maps[18] = new Map { Name = "Blizzard World" };
            _Maps[19] = new Map { Name = "Eichenwalde" };
            _Maps[20] = new Map { Name = "Hollywood" };
            _Maps[21] = new Map { Name = "King's Row" };
            _Maps[22] = new Map { Name = "Midtown" };
            _Maps[23] = new Map { Name = "Numbani" };
            _Maps[24] = new Map { Name = "Paraiso" };
            _Maps[25] = new Map { Name = "Colosseo" };
            _Maps[26] = new Map { Name = "Esperança" };
            _Maps[0] = new Map { Name = "New Queen Street" };
            await _db.Maps.AddRangeAsync(_Maps);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация списка карт выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private GroupSize[] _GroupSizes;
        private async Task InitializeGroupSizes()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация размеров групп...");

            _GroupSizes = new GroupSize[5];
            _GroupSizes[1] = new GroupSize { Name = "Solo" };
            _GroupSizes[2] = new GroupSize { Name = "Duo" };
            _GroupSizes[3] = new GroupSize { Name = "Trio" };
            _GroupSizes[4] = new GroupSize { Name = "Quartet" };
            _GroupSizes[0] = new GroupSize { Name = "Quintet" };
            await _db.GroupSizes.AddRangeAsync(_GroupSizes);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация размеров групп выполнена за {0} мс", timer.ElapsedMilliseconds);

        }

        private Mode[] _Modes;
        private async Task InitializeModes()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация режимов игры...");

            _Modes = new Mode[7];
            _Modes[1] = new Mode { Name = "RQ: Tank" };
            _Modes[2] = new Mode { Name = "RQ: Damage" };
            _Modes[3] = new Mode { Name = "RQ: Support" };
            _Modes[4] = new Mode { Name = "Open Queue" };
            _Modes[5] = new Mode { Name = "Mystery Heroes" };
            _Modes[6] = new Mode { Name = "Team Queue"};
            _Modes[0] = new Mode { Name = "Deathmatch" };
            await _db.Modes.AddRangeAsync(_Modes);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Инициализация режимов игры выполнена за {0} мс", timer.ElapsedMilliseconds);
        }
    }
}
