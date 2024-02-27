using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Persistence.Configuration;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans").HasKey(p => p.Id);

        builder.HasOne(p => p.User)
            .WithMany(p => p.LoansUser).HasForeignKey(p => p.IdUser);
        
        builder.HasOne(p => p.Book)
            .WithMany(p => p.BooksLoan).HasForeignKey(p => p.IdBook);
        
    }
}