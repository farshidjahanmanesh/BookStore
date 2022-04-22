using AutoMapper;
using BookStore.Core.Application.Contracts;
using BookStore.Core.Domain.Entities;
using System;

namespace BookStore.Core.Application.Features.Books.Command.AddBook
{
    public class AddBookBookDto : IMapFrom<Book>
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Guid AuthorId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddBookBookDto, Book>()
                .ForMember(c => c.Id, d => d.MapFrom(m => m.BookId)).ReverseMap();
        }
    }
}
