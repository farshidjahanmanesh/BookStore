using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Application.Contracts
{
    public interface IUserDataService
    {
        public bool IsAuthenticated { get; set; }
        public Guid UserId { get; set; }//todo: must set when add identity
        public string CurrentURL { get; set; }
    }
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}
