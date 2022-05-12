using System.Collections.Generic;

namespace BookStore.Core.Application.Contracts
{
    public interface IBaseResponse
    {
        public bool Status { get; set; }
        public object Result { get; set; }
    }
}
