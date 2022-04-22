using AutoMapper;
using BookStore.Core.Application.Contracts.Persistence.Write;
using BookStore.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResponse>
    {
        private readonly IAsyncWriteRepository<Book> _repo;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IAsyncWriteRepository<Book> repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        public async Task<AddBookResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var response = new AddBookResponse();
            var @object = _mapper.Map<Book>(request);
            var book = await _repo.AddItem(@object);
            response.Book = _mapper.Map<AddBookBookDto>(book);
            return response;
        }
    }
}
