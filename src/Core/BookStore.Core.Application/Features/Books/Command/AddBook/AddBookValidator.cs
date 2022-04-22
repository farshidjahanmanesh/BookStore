using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Domain.Entities;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookValidator : AbstractValidator<AddBookCommand>
    {
        private readonly IAsyncReadRepository<Author> _repo;

        public AddBookValidator(IAsyncReadRepository<Author> repo)
        {
            RuleFor(c => c)
                .MustAsync(CheckAuthorExist)
                .WithMessage("نویسنده با این آیدی وجود ندارد");
            RuleFor(c => c.Count)
                .GreaterThan(0)
                .WithMessage("حداقل تعداد کتاب صفر است");
            RuleFor(c => c.Price)
                .GreaterThan(1)
                .WithMessage("حداقل قیمت کتاب ۱ است");
            this._repo = repo;
        }
        async Task<bool> CheckAuthorExist(AddBookCommand command, CancellationToken token)
        {
            var author = await _repo.GetById<Guid>(command.AuthorId);
            if (author == null)
                return false;
            return true;
        }
    }
}
