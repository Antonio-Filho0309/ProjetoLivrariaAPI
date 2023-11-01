using ProjetoLivrariaAPI.Models.Dtos.Book;
using ProjetoLivrariaAPI.Models.Dtos.User;

namespace ProjetoLivrariaAPI.Models.Dtos.Rental
{
    public class RentalDashDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookRentalDto Book { get; set; }

        public int UserId { get; set; }
        public UserRentalDto User { get; set; }
    }
}
