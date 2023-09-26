using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data.Intefaces {
    public interface IBookRepository {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Book[] GetAllBooks(bool includePublisher = false);
        Book GetBookById(int bookId, bool includePublisher = false);

        Book GetBookByName(string bookName, bool includePublisher = false);


    }
}
