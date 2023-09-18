
namespace ProjetoLivrariaAPI.Models {
    public class Books {

        public Books() { }

        public Books(int id, string name, string author, int publisherId, int release, int quantity) {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.PublisherId = publisherId;
            this.Release = release;
            this.Quantity = quantity;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public int Release { get; set; }

        public int Quantity { get; set; }

    }
}
