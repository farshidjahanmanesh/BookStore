using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Domain.Entities;
using BookStore.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Repositories.Read
{
    public class AsyncAuthorReadRepository : AsyncReadRepository<Author>, IAsyncAuthorReadRepository
    {
        private readonly BookStoreContext _ctx;

        public AsyncAuthorReadRepository(BookStoreContext ctx) : base(ctx)
        {
            this._ctx = ctx;
        }
        public async Task<Author> GetAuthorWithBooks(Guid id)
        {
            return await _ctx.Authors.AsNoTracking()
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
