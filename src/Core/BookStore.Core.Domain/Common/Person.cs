using BookStore.Core.Domain.Common;
using System;

namespace BookStore.Core.Domain.Common
{
    public abstract class Person : Entity<Guid>
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
    }
}
