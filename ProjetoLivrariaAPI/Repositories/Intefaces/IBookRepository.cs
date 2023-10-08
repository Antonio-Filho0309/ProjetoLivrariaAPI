
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IBookRepository
    {

        Task<Book> Add (Book book);
        Task Update (Book book) ;
        Task Delete (Book book);

        Task<ICollection<Book>> GetAllBooks(bool includePublisher = false);
        Task<Book> GetBookById(int bookId, bool includePublisher = false);

        Task<Book> GetBookByName(string bookName, bool includePublisher = false);


    }
}
