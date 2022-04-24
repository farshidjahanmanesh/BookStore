using BookStore.Core.Domain.Common;
using System;

namespace BookStore.Core.Domain.Common
{
    public abstract class Person : Entity<Guid>
    {
        protected Person(string fName, string lName,int age) : base()
        {
            this.FName = fName;
            this.LName = lName;
            this.Age = age;
        }
        public string FName { get; protected set; }
        public string LName { get; protected set; }
        public int Age { get; protected set; }
    }
}
