using Library.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(b => b.Isbn)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(b => b.Isbn)
                   .IsUnique();

            builder.Property(b => b.PublicationYear)
                   .IsRequired();

            builder.Property(b => b.Description)
                   .HasMaxLength(2000)
                   .HasDefaultValue(string.Empty);

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Books)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
