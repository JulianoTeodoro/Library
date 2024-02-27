using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Persistence.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>

{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books")
            .HasKey(p => p.Id);

        builder.Property(p => p.Author).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        builder.Property(p => p.ISBN).HasMaxLength(13).IsRequired();

    }
}