using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailDTO?>
    {
        public Guid Id { get; set; }

        public GetBookByIdQuery(Guid id)
        {
            Id = id;
        }

        public GetBookByIdQuery()
        {
        }
    }
}
