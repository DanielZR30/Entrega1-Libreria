using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IReadOnlyList<BookListItemDTO>>
    {
    }
}
