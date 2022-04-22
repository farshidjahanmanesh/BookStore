using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Common;
using BookStore.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;

namespace BookStore.Infrastructure.Persistence.Repositories.Write
{
    public class WriteRepository<T> : IWriteRepository<T> where T : AuditableEntity
    {
        protected readonly BookStoreContext _ctx;

        public WriteRepository(BookStoreContext ctx)
        {
            this._ctx = ctx;
        }
        public virtual T RemoveItem(T item)
        {
            var result = _ctx.Set<T>().Remove(item);
            _ctx.SaveChanges();
            return result.Entity;
        }

        public virtual T RemoveItem<TKey>(TKey id) where TKey : struct
        {
            var @object = _ctx.Set<T>().Find(id);
            return this.RemoveItem(@object);
        }

        public virtual T Update(T item)
        {
            var result = _ctx.Set<T>().Update(item);
            _ctx.SaveChanges();
            return result.Entity;
        }
    }
}
