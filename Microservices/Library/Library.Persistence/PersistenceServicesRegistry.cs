using Library.Application.Contracts.Persistence;
using Library.Application.Contracts.Repositories;
using Library.Persistence.Repositories;
using Library.Persistence.Seeds;
using Library.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LibraryConnection")
                ?? configuration.GetConnectionString("MyConnection")
                ?? "Server=(localdb)\\mssqllocaldb;Database=LibraryCatalogDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // Unit of Work
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();

            // Repositories
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            // Seeders
            services.AddScoped<IDataSeeder, AuthorsSeeder>();
            services.AddScoped<IDataSeeder, CategoriesSeeder>();
            services.AddScoped<IDataSeeder, BooksSeeder>();

            return services;
        }
    }
}
