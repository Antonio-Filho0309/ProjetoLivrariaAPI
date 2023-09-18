namespace ProjetoLivrariaAPI.Models {
    public class Rentals {

        public Rentals() { }

        public Rentals(int id, string booksId, string usersId, int rentalDate, int previewDate) {
            this.Id = id;
            this.BookId = booksId;
            this.UserId = usersId;
            this.RentalDate = rentalDate;
            this.PreviewDate = previewDate;
        }

        public int Id { get; set; }
        public string BookId { get; set; }
        public Books Book { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }

        public int RentalDate { get; set; }

        public int PreviewDate { get; set; }
    }
}
