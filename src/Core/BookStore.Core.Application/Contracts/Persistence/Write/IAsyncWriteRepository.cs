using BookStore.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Contracts.Persistence.Write
{
    public interface IAsyncWriteRepository<T> : IWriteRepository<T> where T : AuditableEntity
    {
        Task<T> AddItem(T item);
        
    }
}
