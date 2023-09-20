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
        }
    }
}
