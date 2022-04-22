using BookStore.Core.Domain.Common;
using System.Collections.Generic;

namespace BookStore.Core.Domain.Entities
{
    public class Purchaser : Person
    {
        public ICollection<Basket> Baskets { get; set; }
    }
}
