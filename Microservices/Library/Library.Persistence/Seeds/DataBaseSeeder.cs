using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence.Seeds
{
    public static class DataBaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider services, CancellationToken cancellationToken = default)
        {
            using IServiceScope scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            await context.Database.EnsureCreatedAsync(cancellationToken);

            IEnumerable<IDataSeeder> seeders = scope.ServiceProvider
                                                    .GetServices<IDataSeeder>()
                                                    .OrderBy(s => s.Order);

            foreach (IDataSeeder seeder in seeders)
            {
                await seeder.SeedAsync(cancellationToken);
            }
        }
    }
}
