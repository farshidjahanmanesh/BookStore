using BookStore.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Persistence.Configurations
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.LName)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
