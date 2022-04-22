namespace BookStore.Core.Domain.Common
{
    public class Entity<T> : AuditableEntity where T : struct
    {
        public T Id { get; set; }
    }
}
