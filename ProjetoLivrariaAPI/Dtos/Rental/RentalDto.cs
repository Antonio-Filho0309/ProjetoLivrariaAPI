using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Dtos.Rental {
    public class RentalDto {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookRentalDto Book { get; set; }

        public int UserId { get; set; }
        public UserRentalDto User { get; set; }

        public string RentalDate { get; set; }

        public string PreviewDate { get; set; }

        public string ReturnDate { get; set; }

        public string Status { get; set; }
    }
}
