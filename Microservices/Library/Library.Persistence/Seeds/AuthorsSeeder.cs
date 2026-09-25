using Library.Domain.Entities.Authors;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class AuthorsSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public AuthorsSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 1;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Authors.AnyAsync(cancellationToken))
            {
                return;
            }

            var authors = new List<Author>
            {
                new Author(
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    "Gabriel García Márquez",
                    "Escritor, novelista y periodista colombiano. Ganador del Premio Nobel de Literatura en 1982, máximo exponente del realismo mágico."
                ),
                new Author(
                    Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    "Robert C. Martin (Uncle Bob)",
                    "Ingeniero de software, consultor y autor estadounidense. Defensor pionero de los principios de diseño de software ágil y Clean Code."
                ),
                new Author(
                    Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    "Miguel de Cervantes Saavedra",
                    "Novelista, poeta y dramaturgo español, considerado universalmente como la máxima figura de la literatura en lengua española."
                ),
                new Author(
                    Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    "Antoine de Saint-Exupéry",
                    "Aviador y novelista francés, célebre autor de El Principito y obras reflexivas sobre la condición humana."
                ),
                new Author(
                    Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    "J.R.R. Tolkien",
                    "Filólogo, profesor y escritor británico, creador de las obras fundamentales de fantasía moderna El Hobbit y El Señor de los Anillos."
                )
            };

            await _context.Authors.AddRangeAsync(authors, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
