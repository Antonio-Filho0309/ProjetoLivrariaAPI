using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Pagination;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using System.Net;

namespace ProjetoLivrariaAPI.Repositories {
    public class BookRepository : IBookRepository {
        private readonly DataContext _context;

        public BookRepository(DataContext context) {
            _context = context;
        }

        public async Task<Book> Add(Book book) {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Update(Book book) {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book) {
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Book>> GetAllBooks() {
            return await _context.Books.Include(b=> b.Publisher).ToListAsync();
        }

        public async Task<Book> GetBookById(int bookId) {
            return await _context.Books.Include(b=> b.Publisher).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Book> GetBookByName(string bookName) {
            return await _context.Books.FirstOrDefaultAsync(b => b.Name == bookName);
        }

        public async Task<Book> GetBookByPublisherId(int publisherId) {
            return await _context.Books.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.PublisherId == publisherId);
        }

        public async Task<PagedBaseReponse<Book>> GetAllBookPaged(Filter bookFilter) {

            var book = _context.Books.Include(b => b.Publisher).AsQueryable();
            if (!string.IsNullOrEmpty(bookFilter.Value))
                book = book.Where(b => b.Name.Contains(bookFilter.Value) ||
                b.Id.ToString().Contains(bookFilter.Value) ||
                b.Author.Contains(bookFilter.Value) ||
                b.PublisherId.ToString().Contains(bookFilter.Value) ||
                b.Publisher.Name.Contains(bookFilter.Value) ||
                b.Quantity.ToString().Contains(bookFilter.Value) ||
                b.Release.ToString().Contains(bookFilter.Value));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Book>, Book>(book, bookFilter);

        }
    }
}
