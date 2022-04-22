using BookStore.Core.Domain.Common;
using System;
using System.Text;

namespace BookStore.Core.Domain.Entities
{
    public class Book : Entity<Guid>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
