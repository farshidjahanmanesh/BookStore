using BookStore.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Persistence.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(400);
            builder.HasOne(c => c.Author)
                .WithMany(c => c.Books)
                .HasForeignKey(c => c.AuthorId);
        }
    }
}
