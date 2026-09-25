using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetBooksByCategory
{
    public class GetBooksByCategoryQuery : IRequest<IReadOnlyList<BookListItemDTO>>
    {
        public Guid CategoryId { get; set; }

        public GetBooksByCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public GetBooksByCategoryQuery()
        {
        }
    }
}
