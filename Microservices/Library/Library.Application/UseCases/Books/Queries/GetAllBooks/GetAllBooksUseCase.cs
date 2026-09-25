using Library.Application.Contracts.Repositories;
using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetAllBooks
{
    public class GetAllBooksUseCase : IRequestHandler<GetAllBooksQuery, IReadOnlyList<BookListItemDTO>>
    {
        private readonly IBooksRepository _booksRepository;

        public GetAllBooksUseCase(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<IReadOnlyList<BookListItemDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken = default)
        {
            var books = await _booksRepository.GetAllWithDetailsAsync(cancellationToken);
            return books.Select(b => b.ToListItemDTO()).ToList();
        }
    }
}
