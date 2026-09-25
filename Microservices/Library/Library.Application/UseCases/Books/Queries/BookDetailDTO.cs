namespace Library.Application.UseCases.Books.Queries
{
    public class BookDetailDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public AuthorDTO Author { get; set; } = null!;
        public CategoryDTO Category { get; set; } = null!;
    }

    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
    }

    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
    }
}
