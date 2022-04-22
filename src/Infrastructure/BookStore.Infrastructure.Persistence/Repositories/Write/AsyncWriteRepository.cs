using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Common;
using BookStore.Infrastructure.Persistence.Contexts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Repositories.Write
{
    public class AsyncWriteRepository<T> : WriteRepository<T>, IAsyncWriteRepository<T> where T : AuditableEntity
    {
        public AsyncWriteRepository(BookStoreContext ctx) : base(ctx)
        {
        }
        public async virtual Task<T> AddItem(T item)
        {
            var result = await base._ctx.Set<T>().AddAsync(item);
            await base._ctx.SaveChangesAsync();
            return result.Entity;
        }
    }
}
