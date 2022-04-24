using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Domain.Common;
using BookStore.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Repositories.Read
{
    public class AsyncReadRepository<T> : IAsyncReadRepository<T> where T : AuditableEntity
    {
        private readonly BookStoreContext _ctx;

        public AsyncReadRepository(BookStoreContext ctx)
        {
            this._ctx = ctx;
        }
        public virtual async Task<T> GetById<TKey>(TKey id) where TKey : struct
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetList()
        {
            return await _ctx.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
