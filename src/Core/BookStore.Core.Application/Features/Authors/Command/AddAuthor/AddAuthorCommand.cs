using MediatR;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorCommand : IRequest<AddAuthorAuthorDto>
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
    }
}
