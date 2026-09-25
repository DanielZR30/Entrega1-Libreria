using Library.Application.Contracts.Repositories;
using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetBooksByCategory
{
    public class GetBooksByCategoryUseCase : IRequestHandler<GetBooksByCategoryQuery, IReadOnlyList<BookListItemDTO>>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBooksByCategoryUseCase(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IReadOnlyList<BookListItemDTO>> Handle(GetBooksByCategoryQuery request, CancellationToken cancellationToken = default)
        {
            var books = await _booksRepository.GetByCategoryIdWithDetailsAsync(request.CategoryId, cancellationToken);
            return books.Select(b => b.ToListItemDTO()).ToList();
        }
    }
}
