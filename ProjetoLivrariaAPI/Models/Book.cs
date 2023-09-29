
namespace ProjetoLivrariaAPI.Models {
    public class Book {

        public Book() { }

        public Book(int id, string name, string author, int publisherId, int release, int quantity, int rented) {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.PublisherId = publisherId;
            this.Release = release;
            this.Quantity = quantity;
            this.Rented = rented;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public int Release { get; set; }

        public int Quantity { get; set; }

        public int Rented { get; set; }

    }
}
