using Library.Domain.Entities.Books;

namespace Library.Application.UseCases.Books.Queries
{
    public static class BookMapperExtensions
    {
        public static BookListItemDTO ToListItemDTO(this Book book)
        {
            return new BookListItemDTO
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                Author = book.Author?.Name ?? "Desconocido",
                Category = book.Category?.Name ?? "Sin categoría"
            };
        }

        public static BookDetailDTO ToDetailDTO(this Book book)
        {
            return new BookDetailDTO
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                Description = book.Description,
                CreatedAt = book.CreatedAt,
                Author = new AuthorDTO
                {
                    Id = book.AuthorId,
                    Name = book.Author?.Name ?? "Desconocido",
                    Biography = book.Author?.Biography ?? string.Empty
                },
                Category = new CategoryDTO
                {
                    Id = book.CategoryId,
                    Name = book.Category?.Name ?? "Sin categoría",
                    Description = book.Category?.Description ?? string.Empty
                }
            };
        }
    }
}
