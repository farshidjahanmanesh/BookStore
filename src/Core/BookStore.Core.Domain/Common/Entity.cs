namespace BookStore.Core.Domain.Common
{
    public class Entity<T> : AuditableEntity where T : struct
    {
        protected Entity()
        {

        }
        public T Id { get; protected set; }
    }
}
