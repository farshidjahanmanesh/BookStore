using AutoMapper;
using System.Text;

namespace BookStore.Core.Application.Contracts
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}
