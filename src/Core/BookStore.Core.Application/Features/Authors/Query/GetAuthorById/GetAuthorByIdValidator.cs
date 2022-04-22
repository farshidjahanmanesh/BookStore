using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Domain.Entities;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Query.GetAuthorById
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        private readonly IAsyncReadRepository<Author> _repo;

        public GetAuthorByIdValidator(IAsyncReadRepository<Author> repo)
        {
            RuleFor(c => c)
                .MustAsync(CheckAuthorExist)
                .WithMessage("نویسنده ای با این آیدی موجود نیست");
            this._repo = repo;
        }
        async Task<bool> CheckAuthorExist(GetAuthorByIdQuery query, CancellationToken token)
        {
            var author = await _repo.GetById<Guid>(query.Id);
            if (author == null)
                return false;
            return true;
        }
    }
}
