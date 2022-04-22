using AutoMapper;
using BookStore.Core.Application.Contracts;
using BookStore.Core.Domain.Entities;
using System;

namespace BookStore.Core.Application.Features.Authors.Command.AddAuthor
{
    public class AddAuthorAuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddAuthorAuthorDto, Author>()
                .ReverseMap();
        }
    }
}
