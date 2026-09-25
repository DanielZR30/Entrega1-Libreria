using Library.Domain.Entities.Authors;
using Library.Domain.Entities.Categories;
using Library.Domain.Exceptions;

namespace Library.Domain.Entities.Books
{
    public sealed class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = null!;
        public string Isbn { get; private set; } = null!;
        public int PublicationYear { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; } = null!;
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

        private Book()
        {
        }

        public Book(string title,
                    string isbn,
                    int publicationYear,
                    string description,
                    Guid authorId,
                    Guid categoryId)
        {
            ApplyTitleRules(title);
            ApplyIsbnRules(isbn);
            ApplyPublicationYearRules(publicationYear);
            ApplyAuthorRules(authorId);
            ApplyCategoryRules(categoryId);

            Id = Guid.CreateVersion7();
            Title = title.Trim();
            Isbn = NormalizeIsbn(isbn);
            PublicationYear = publicationYear;
            Description = description?.Trim() ?? string.Empty;
            AuthorId = authorId;
            CategoryId = categoryId;
            CreatedAt = DateTime.UtcNow;
        }

        public Book(Guid id,
                    string title,
                    string isbn,
                    int publicationYear,
                    string description,
                    Guid authorId,
                    Guid categoryId,
                    DateTime? createdAt = null)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException("El identificador del libro no puede estar vacío.");
            }

            ApplyTitleRules(title);
            ApplyIsbnRules(isbn);
            ApplyPublicationYearRules(publicationYear);
            ApplyAuthorRules(authorId);
            ApplyCategoryRules(categoryId);

            Id = id;
            Title = title.Trim();
            Isbn = NormalizeIsbn(isbn);
            PublicationYear = publicationYear;
            Description = description?.Trim() ?? string.Empty;
            AuthorId = authorId;
            CategoryId = categoryId;
            CreatedAt = createdAt ?? DateTime.UtcNow;
        }

        private static void ApplyTitleRules(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("El título del libro es obligatorio.");
            }

            if (title.Trim().Length > 250)
            {
                throw new DomainException("El título del libro no puede exceder los 250 caracteres.");
            }
        }

        private static void ApplyIsbnRules(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new DomainException("El ISBN del libro es obligatorio.");
            }

            string clean = isbn.Replace("-", "").Replace(" ", "").Trim();
            if (clean.Length < 10 || clean.Length > 17)
            {
                throw new DomainException("El formato del ISBN no es válido. Debe tener entre 10 y 17 caracteres.");
            }
        }

        private static void ApplyPublicationYearRules(int publicationYear)
        {
            int currentYear = DateTime.UtcNow.Year;
            if (publicationYear < 0 || publicationYear > currentYear + 1)
            {
                throw new DomainException($"El año de publicación debe ser válido (entre 0 y {currentYear + 1}).");
            }
        }

        private static void ApplyAuthorRules(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new DomainException("Debe asignar un autor válido al libro.");
            }
        }

        private static void ApplyCategoryRules(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new DomainException("Debe asignar una categoría válida al libro.");
            }
        }

        private static string NormalizeIsbn(string isbn)
        {
            return isbn.Trim().ToUpperInvariant();
        }
    }
}
