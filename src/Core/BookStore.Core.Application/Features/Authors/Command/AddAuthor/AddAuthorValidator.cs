using BookStore.Core.Application.Contracts.Persistence.Read;
using BookStore.Core.Domain.Entities;
using FluentValidation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorValidator : AbstractValidator<AddAuthorCommand>
    {
        private readonly IAsyncReadRepository<Author> _repo;

        public AddAuthorValidator(IAsyncReadRepository<Author> repo)
        {
            RuleFor(c => c.Age)
                .GreaterThan(18)
                .WithMessage("حداقل سن نویسنده ۱۸ سال است");
            RuleFor(c => c.FName)
                .NotEmpty()
                .WithMessage("نام نباید خالی باشد");
            RuleFor(c => c.LName)
                .NotEmpty()
                .WithMessage("نام خانوادگی نباید خالی باشد");
            RuleFor(c => c)
                .MustAsync(CheckAuthorExist)
                .WithMessage(" نویسنده با این نام موجود است");
            this._repo = repo;
        }

        async Task<bool> CheckAuthorExist(AddAuthorCommand command, CancellationToken token)
        {
            return !(await _repo.GetList()).Any(c => c.FName == command.FName && c.LName == command.LName);
        }
    }
}
