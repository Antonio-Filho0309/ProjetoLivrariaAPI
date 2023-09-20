namespace ProjetoLivrariaAPI.Models {
    public class Rental {

        public Rental() { }

        public Rental(int id, int bookId, int userId, int rentalDate, int previewDate, string status) {
            this.Id = id;
            this.BookId = bookId;
            this.UserId = userId;
            this.RentalDate = rentalDate;
            this.PreviewDate = previewDate;
            this.Status = status;
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RentalDate { get; set; }

        public int PreviewDate { get; set; }

        public string Status   {get; set;}
    }
}
