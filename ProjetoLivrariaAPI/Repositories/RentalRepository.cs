using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using System.Net;

namespace ProjetoLivrariaAPI.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DataContext _context;

        public RentalRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Rental[] GetAllRentals(bool includeUser = false, bool includeBook = false)
        {
            IQueryable<Rental> query = _context.Rentals;

            if (includeUser && includeBook)
            {

                query = query.Include(r => r.User)
                    .Include(r => r.Book);
            }

            query = query.AsNoTracking().OrderBy(r => r.Id);

            return query.ToArray();
        }

        public Rental GetRentalById(int rentalId, bool includeUser = false, bool includeBook = false)
        {
            IQueryable<Rental> query = _context.Rentals;


            if (includeUser && includeBook)
            {

                query = query.Include(r => r.User)
                    .Include(r => r.Book);
            }

            query = query.AsNoTracking().OrderBy(r => r.Id)
                .Where(rental => rental.Id == rentalId);

            return query.FirstOrDefault();
        }


    }
}
