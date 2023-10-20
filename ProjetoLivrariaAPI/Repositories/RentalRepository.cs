using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Pagination;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using System.Net;

namespace ProjetoLivrariaAPI.Repositories {
    public class RentalRepository : IRentalRepository {
        private readonly DataContext _context;

        public RentalRepository(DataContext context) {
            _context = context;
        }

        public async Task<Rental> Add(Rental rental) {
            _context.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task Update(Rental rental) {
            _context.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Rental>> GetAllRentals() {
            return await _context.Rentals.Include(r => r.User)
                .Include(r => r.Book).ToListAsync();
        }

        public async Task<Rental> GetRentalById(int rentalId) {
            return await _context.Rentals.Include(r => r.Book).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == rentalId);
        }

        public async Task<Rental> GetRentalByUserId(int userId) {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.UserId == userId);
        }

        public async Task<Rental> GetRentalByBookId(int bookId) {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.BookId == bookId);
        }

        public async Task<Rental> GetByUserAndBook(int userId, int bookId) {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
        }

        public async Task<PagedBaseReponse<Rental>> GetAllRentalPaged(Filter rentalFilter) {
            var rental = _context.Rentals.Include(r => r.User).Include(r => r.Book).AsQueryable();
            if (!string.IsNullOrEmpty(rentalFilter.Value))
                rental = rental.Where(r => r.Id.ToString().Contains(rentalFilter.Value) ||
                r.UserId.ToString().Contains(rentalFilter.Value) ||
                r.BookId.ToString().Contains(rentalFilter.Value) ||
                r.User.Name.Contains(rentalFilter.Value) ||
                r.Book.Name.Contains(rentalFilter.Value) ||
                r.ReturnDate.ToString().Contains(rentalFilter.Value) ||
                r.RentalDate.ToString().Contains(rentalFilter.Value) ||
                r.PreviewDate.ToString().Contains(rentalFilter.Value) ||
                r.Status.Contains(rentalFilter.Value));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Rental>, Rental>(rental, rentalFilter);
        }
    }
}
