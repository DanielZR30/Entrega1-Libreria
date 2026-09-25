using Library.Application.UseCases.Books.Queries;
using Library.Application.UseCases.Books.Queries.GetAllBooks;
using Library.Application.UseCases.Books.Queries.GetBookById;
using Library.Application.UseCases.Books.Queries.GetBooksByCategory;
using Library.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediator, SimpleMediator>();

            // Query Handlers
            services.AddScoped<IRequestHandler<GetAllBooksQuery, IReadOnlyList<BookListItemDTO>>, GetAllBooksUseCase>();
            services.AddScoped<IRequestHandler<GetBookByIdQuery, BookDetailDTO?>, GetBookByIdUseCase>();
            services.AddScoped<IRequestHandler<GetBooksByCategoryQuery, IReadOnlyList<BookListItemDTO>>, GetBooksByCategoryUseCase>();

            return services;
        }
    }
}
