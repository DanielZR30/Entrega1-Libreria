using Library.Domain.Entities.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(a => a.Biography)
                   .HasMaxLength(1000)
                   .HasDefaultValue(string.Empty);

            builder.HasMany(a => a.Books)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
