using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Dtos {

    //Criar Livro;
    public class CreateBookDto {
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public int Release { get; set; }
        public int Quantity { get; set; }
    }

    //Atualizar 
    public class UpdateBookDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public int Release { get; set; }
        public int Quantity { get; set; }
    }
}
