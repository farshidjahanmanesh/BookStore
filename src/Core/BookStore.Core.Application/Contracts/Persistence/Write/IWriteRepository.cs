using BookStore.Core.Domain.Common;

namespace BookStore.Core.Application.Contracts.Persistence.Write
{
    public interface IWriteRepository<T> where T : AuditableEntity
    {
        T RemoveItem(T item);
        T RemoveItem<TKey>(TKey id) where TKey : struct;
        T Update(T item);
    }
}
