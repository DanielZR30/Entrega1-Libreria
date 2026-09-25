namespace Library.Application.UseCases.Books.Queries
{
    public class BookListItemDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
