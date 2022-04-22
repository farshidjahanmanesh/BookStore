using BookStore.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Contracts.Persistence.Read
{
    public interface IAsyncAuthorReadRepository : IAsyncReadRepository<Author>
    {
        Task<Author> GetAuthorWithBooks(Guid id);
    }
}
