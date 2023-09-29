namespace ProjetoLivrariaAPI.Dtos.Rental {
    public class CreateRentalDto {

        public int BookId { get; set; }

        public int UserId { get; set; }

        public string? RentalDate { get; set; }

        public string? PreviewDate { get; set; }

    }
}
