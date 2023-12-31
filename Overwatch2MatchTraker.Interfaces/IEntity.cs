
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Overwatch2MatchTraker.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);
        
        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken Cancel = default);
        
        void Update(T item);
        Task UpdateAsync(T item, CancellationToken Cancel = default);

        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken Cancel = default);
    }

}
