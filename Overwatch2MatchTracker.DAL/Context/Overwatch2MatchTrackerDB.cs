using Microsoft.EntityFrameworkCore;
using Overwatch2MatchTracker.DAL.Entities;
using Overwatch2MatchTracker.DAL.Entities.Base;

namespace Overwatch2MatchTracker.DAL.Context
{
    public class Overwatch2MatchTrackerDB : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GroupSize> GroupSizes { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<SpecificPlayer> SpecificPlayers { get; set; }

        public Overwatch2MatchTrackerDB(DbContextOptions<Overwatch2MatchTrackerDB> options) : base (options) { }
    }

}
