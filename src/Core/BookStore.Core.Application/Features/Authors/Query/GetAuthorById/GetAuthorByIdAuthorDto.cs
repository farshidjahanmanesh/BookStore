using AutoMapper;
using BookStore.Core.Application.Contracts;
using BookStore.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Core.Application.Features.Authors.Query.GetAuthorById
{
    public class GetAuthorByIdAuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public List<GetAuthorByIdBookDto> Books { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAuthorByIdAuthorDto, Author>().ReverseMap();
        }
    }
}
