using Library.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class CategoriesSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public CategoriesSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 2;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Categories.AnyAsync(cancellationToken))
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category(
                    Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    "Novela y Ficción",
                    "Obras narrativas de ficción literaria, realismo mágico, tramas contemporáneas y universos creativos."
                ),
                new Category(
                    Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    "Tecnología y Software",
                    "Libros técnicos sobre ingeniería de software, arquitectura de sistemas, buenas prácticas de programación y metodologías."
                ),
                new Category(
                    Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    "Clásicos de la Literatura",
                    "Obras maestras universales reconocidas por su impacto histórico y trascendencia en la literatura universal."
                ),
                new Category(
                    Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    "Fantasía Épica",
                    "Novelas de alta fantasía, mitología, batallas heroicas y exploración de mundos imaginarios."
                )
            };

            await _context.Categories.AddRangeAsync(categories, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
