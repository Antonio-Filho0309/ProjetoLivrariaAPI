namespace ProjetoLivrariaAPI.Models {
    public class Rental {

        public Rental() { }

        public Rental(int id, int bookId, int userId, string rentalDate, string previewDate, string?returnDate) {
            this.Id = id;
            this.BookId = bookId;
            this.UserId = userId;
            this.RentalDate = rentalDate;
            this.PreviewDate = previewDate;
            this.ReturnDate = returnDate;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? RentalDate { get; set; }

        public string? PreviewDate { get; set; }

        public string? ReturnDate { get; set; }

        public string? Status   {get; set;}
    }
}
