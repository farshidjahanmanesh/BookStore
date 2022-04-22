using BookStore.Core.Domain.Common;
using System.Collections.Generic;

namespace BookStore.Core.Domain.Entities
{
    public class Author : Person
    {
        public ICollection<Book> Books { get; set; }
    }
}
