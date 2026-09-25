using Library.Domain.Entities.Books;
using Library.Domain.Exceptions;

namespace Library.Domain.Entities.Authors
{
    public sealed class Author
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Biography { get; private set; } = string.Empty;

        private readonly List<Book> _books = new();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        private Author()
        {
        }

        public Author(string name, string biography = "")
        {
            ApplyNameRules(name);

            Id = Guid.CreateVersion7();
            Name = name.Trim();
            Biography = biography?.Trim() ?? string.Empty;
        }

        public Author(Guid id, string name, string biography = "")
        {
            if (id == Guid.Empty)
            {
                throw new DomainException("El identificador del autor no puede estar vacío.");
            }

            ApplyNameRules(name);

            Id = id;
            Name = name.Trim();
            Biography = biography?.Trim() ?? string.Empty;
        }

        public void UpdateBiography(string biography)
        {
            Biography = biography?.Trim() ?? string.Empty;
        }

        private static void ApplyNameRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("El nombre del autor es obligatorio.");
            }

            if (name.Trim().Length > 150)
            {
                throw new DomainException("El nombre del autor no puede exceder los 150 caracteres.");
            }
        }
    }
}
