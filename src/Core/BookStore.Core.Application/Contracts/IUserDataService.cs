using System;

namespace BookStore.Core.Application.Contracts
{
    public interface IUserDataService
    {
        public bool IsAuthenticated { get; set; }
        public Guid UserId { get; set; }//todo: must set when add identity
        public string CurrentURL { get; set; }
    }
}
