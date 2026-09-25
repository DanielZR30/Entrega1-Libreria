using Library.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class BooksSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public BooksSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 3;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Books.AnyAsync(cancellationToken))
            {
                return;
            }

            var gaboId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var uncleBobId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var cervantesId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var saintExuperyId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var tolkienId = Guid.Parse("55555555-5555-5555-5555-555555555555");

            var ficcionId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var techId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var clasicosId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var fantasiaId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

            var books = new List<Book>
            {
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    "Cien años de soledad",
                    "978-0307474728",
                    1967,
                    "La historia épica de la familia Buendía a lo largo de siete generaciones en el mítico pueblo de Macondo, obra cumbre del realismo mágico.",
                    gaboId,
                    ficcionId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    "El amor en los tiempos del cólera",
                    "978-0307389732",
                    1985,
                    "Una inolvidable historia de devoción y amor perdurable entre Florentino Ariza y Fermina Daza que se prolonga por más de medio siglo.",
                    gaboId,
                    ficcionId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    "Clean Code: A Handbook of Agile Software Craftsmanship",
                    "978-0132350884",
                    2008,
                    "Guía fundamental de buenas prácticas para desarrolladores. Enseña cómo escribir código legible, mantenible y robusto mediante principios sólidos.",
                    uncleBobId,
                    techId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    "The Clean Coder: A Code of Conduct for Professional Programmers",
                    "978-0137081073",
                    2011,
                    "Consejos pragmáticos sobre profesionalismo, ética, estimaciones, refactorización y comunicación para ingenieros de software.",
                    uncleBobId,
                    techId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    "Don Quijote de la Mancha",
                    "978-8420412146",
                    1605,
                    "La cumbre de la narrativa española que relata las aventuras del hidalgo Alonso Quijano y su fiel escudero Sancho Panza en búsqueda de la justicia y el honor.",
                    cervantesId,
                    clasicosId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    "El Principito",
                    "978-0156013987",
                    1943,
                    "Cuento poético y filosófico sobre la amistad, el amor y el sentido de la vida, visto a través de los ojos de un pequeño príncipe proveniente de otro asteroide.",
                    saintExuperyId,
                    clasicosId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    "El Señor de los Anillos: La Comunidad del Anillo",
                    "978-8445071793",
                    1954,
                    "El inicio del viaje trascendental de Frodo Bolsón y sus compañeros a través de la Tierra Media para destruir el Anillo Único en el Monte del Destino.",
                    tolkienId,
                    fantasiaId
                ),
                new Book(
                    Guid.Parse("10000000-0000-0000-0000-000000000008"),
                    "El Hobbit",
                    "978-8445071410",
                    1937,
                    "La expedición inesperada del hobbit Bilbo Bolsón con un grupo de enanos y el mago Gandalf para recuperar el tesoro custodiado por el dragón Smaug.",
                    tolkienId,
                    fantasiaId
                )
            };

            await _context.Books.AddRangeAsync(books, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
