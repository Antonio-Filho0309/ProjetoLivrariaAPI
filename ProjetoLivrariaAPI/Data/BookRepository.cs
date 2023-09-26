using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;
using System.Net;

namespace ProjetoLivrariaAPI.Data {
    public class BookRepository : IBookRepository {
        private readonly DataContext _context;

        public BookRepository(DataContext context) {
            _context = context;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public bool SaveChanges() {
            return (_context.SaveChanges() > 0);
        }

        public Book[] GetAllBooks(bool includePublisher = false) {
            IQueryable<Book> query = _context.Books;

            if (includePublisher) {

                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking().OrderBy(b => b.Id);

            return query.ToArray();
        }

        public Book GetBookById(int bookId, bool includePublisher = false) {
            IQueryable<Book> query = _context.Books;

            if (includePublisher) {

                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking().OrderBy(b => b.Id)
                .Where(book => book.Id == bookId);

            return query.FirstOrDefault();

        }

        public Book GetBookByName(string bookName , bool includePublisher = false) {
            IQueryable<Book> query = _context.Books;

            if (includePublisher) {

                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking().OrderBy(b => b.Id)
                .Where(book => book.Name == bookName);

            return query.FirstOrDefault();
        }






    }
}
