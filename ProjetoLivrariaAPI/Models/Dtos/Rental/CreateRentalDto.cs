namespace ProjetoLivrariaAPI.Models.Dtos.Rental
{
    public class CreateRentalDto
    {

        public int BookId { get; set; }

        public int UserId { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime PreviewDate { get; set; }

    }
}
