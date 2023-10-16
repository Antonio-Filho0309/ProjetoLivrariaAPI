namespace ProjetoLivrariaAPI.Models {
    public class Rental {

        public Rental() { }

        public Rental(int id, int bookId, int userId, DateTime rentalDate, DateTime previewDate, DateTime returnDate) {
            this.Id = id;
            this.BookId = bookId;
            this.UserId = userId;
            this.RentalDate = rentalDate;
            this.PreviewDate = previewDate;
            this.ReturnDate = returnDate;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime PreviewDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string? Status { get; set; } 
    }
}
