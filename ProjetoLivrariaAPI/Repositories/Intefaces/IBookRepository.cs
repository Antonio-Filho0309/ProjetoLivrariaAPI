
using ProjetoLivrariaAPI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IBookRepository
    {

        Task<Book> Add (Book book);
        Task Update (Book book) ;
        Task Delete (Book book);

        Task<ICollection<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
        Task<Book> GetBookByName(string bookName );


    }
}
