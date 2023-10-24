using ProjetoLivrariaAPI.Models.Dtos.Publisher;

namespace ProjetoLivrariaAPI.Models.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int PublisherId { get; set; }

        public PublisherBookDto Publisher { get; set; }

        public int Release { get; set; }

        public int Quantity { get; set; }

        public int Rented { get; set; }
    }
}
