using BookStore.Core.Domain.Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Contracts.Persistence.Read
{
    public interface IAsyncReadRepository<T> where T : AuditableEntity
    {
        Task<T> GetById<TKey>(TKey id) where TKey : struct;
        Task<IEnumerable<T>> GetList();
    }
}
