using Microsoft.EntityFrameworkCore;
using Overwatch2MatchTracker.DAL.Context;
using Overwatch2MatchTracker.DAL.Entities;
using Overwatch2MatchTracker.DAL.Entities.Base;
using Overwatch2MatchTraker.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.DAL
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly Overwatch2MatchTrackerDB _db;
        private readonly DbSet<T> _Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(Overwatch2MatchTrackerDB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken Cancel) => await Items
            .SingleOrDefaultAsync(item => item.Id == id, Cancel)
            .ConfigureAwait(false);

        public void Remove(int id)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
               await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken Cancel)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }

    class GamesRepository : DbRepository<Game>
    {
        public override IQueryable<Game> Items
        {
            get
            {
                return base.Items
                    .Include(item => item.Mode)
                    .Include(item => item.Heroes)
                    .Include(item => item.Map)
                    .Include(item => item.SpecificPlayers)
                    .Include(item => item.GroupSize)
                    .Include(item => item.MatchResult)
                    ;
            }
        }

        public GamesRepository(Overwatch2MatchTrackerDB db) : base(db) { }
    }
}
