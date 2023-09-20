namespace ProjetoLivrariaAPI.Models {
    public class Rental {

        public Rental() { }

        public Rental(int id, string booksId, string usersId, int rentalDate, int previewDate) {
            this.Id = id;
            this.BookId = booksId;
            this.UserId = usersId;
            this.RentalDate = rentalDate;
            this.PreviewDate = previewDate;
        }

        public int Id { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int RentalDate { get; set; }

        public int PreviewDate { get; set; }
    }
}
