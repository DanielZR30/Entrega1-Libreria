using Library.Application.Contracts.Repositories;
using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdUseCase : IRequestHandler<GetBookByIdQuery, BookDetailDTO?>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBookByIdUseCase(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<BookDetailDTO?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken = default)
        {
            var book = await _booksRepository.GetByIdWithDetailsAsync(request.Id, cancellationToken);
            return book?.ToDetailDTO();
        }
    }
}
