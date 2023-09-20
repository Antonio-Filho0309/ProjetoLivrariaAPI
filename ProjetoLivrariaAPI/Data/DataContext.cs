using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data {

    //A classe DataContext é a classe responsável em criar nossa conexão e comunicação com o banco de dados. 
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Rental>()
                   .HasKey(R => new { R.UserId, R.BookId });
            builder.Entity<Book>()
                .HasKey(B => new { B.PublisherId });
                
            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Lauro" , "Fortaleza"),
                    new Publisher(2, "Roberto", "Fortaleza"),
                    new Publisher(3, "Ronaldo", "Fortaleza"),
                    new Publisher(4, "Rodrigo" , "Fortaleza"),
                    new Publisher(5, "Alexandre", "Fortaleza"),
                });

            builder.Entity<Book>()
                .HasData(new List<Book>{
                    new Book(1, "Matemática", "Pitágoras" , 1 , 2005 ,13),
                    new Book(2,"Português", "Cristovão Comlombo" , 2 , 2003 ,10),
                    new Book(3,"História", "Jesus Cristo" , 3 , 1999 ,1),
                    new Book(4,"História", "Jesus Cristo" , 3 , 1999 ,1),
                    new Book(5,"Geografia", "Cão" , 3 , 1999 ,1),
                });

            builder.Entity<User>()
                .HasData(new List<User>(){
                    new User(1, "Marta", "Kent", "33225555" , "Bairro ellery"),
                    new User(2, "Paula", "Isabela", "3354288", "Bairro ellery"),
                    new User(3, "Laura", "Antonia", "55668899", "Bairro ellery"),
                    new User(4, "Luiza", "Maria", "6565659" , "Bairro ellery"),
                    new User(5, "Lucas", "Machado", "565685415", "Bairro ellery"),
                    new User(6, "Pedro", "Alvares", "456454545", "Bairro ellery"),
                    new User(7, "Paulo", "José", "9874512", "Bairro ellery")
                });

            builder.Entity<Rental>()
                .HasData(new List<Rental>() {
                    new Rental() {UserId = 1, BookId = 2 },
                    new Rental() {UserId = 1, BookId = 4 },
                    new Rental() {UserId = 1, BookId = 5 },
                    new Rental() {UserId = 2, BookId = 1 },
                    new Rental() {UserId = 2, BookId = 2 },
                    new Rental() {UserId = 2, BookId = 5 },
                    new Rental() {UserId = 3, BookId = 1 },
                    new Rental() {UserId = 3, BookId = 2 },
                    new Rental() {UserId = 3, BookId = 3 },
                    new Rental() {UserId = 4, BookId = 1 },
                    new Rental() {UserId = 4, BookId = 4 },
                    new Rental() {UserId = 4, BookId = 5 },
                    new Rental() {UserId = 5, BookId = 4 },
                    new Rental() {UserId = 5, BookId = 5 },
                    new Rental() {UserId = 6, BookId = 1 },
                    new Rental() {UserId = 6, BookId = 2 },
                    new Rental() {UserId = 6, BookId = 3 },
                    new Rental() {UserId = 6, BookId = 4 },
                    new Rental() {UserId = 7, BookId = 1 },
                    new Rental() {UserId = 7, BookId = 2 },
                    new Rental() {UserId = 7, BookId = 3 },
                    new Rental() {UserId = 7, BookId = 4 },
                    new Rental() {UserId = 7, BookId = 5 }
                });
        }
    }
}
