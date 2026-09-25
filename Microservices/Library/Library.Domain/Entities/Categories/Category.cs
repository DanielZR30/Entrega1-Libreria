using Library.Domain.Entities.Books;
using Library.Domain.Exceptions;

namespace Library.Domain.Entities.Categories
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = string.Empty;

        private readonly List<Book> _books = new();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        private Category()
        {
        }

        public Category(string name, string description = "")
        {
            ApplyNameRules(name);

            Id = Guid.CreateVersion7();
            Name = name.Trim();
            Description = description?.Trim() ?? string.Empty;
        }

        public Category(Guid id, string name, string description = "")
        {
            if (id == Guid.Empty)
            {
                throw new DomainException("El identificador de la categoría no puede estar vacío.");
            }

            ApplyNameRules(name);

            Id = id;
            Name = name.Trim();
            Description = description?.Trim() ?? string.Empty;
        }

        private static void ApplyNameRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("El nombre de la categoría es obligatorio.");
            }

            if (name.Trim().Length > 100)
            {
                throw new DomainException("El nombre de la categoría no puede exceder los 100 caracteres.");
            }
        }
    }
}
