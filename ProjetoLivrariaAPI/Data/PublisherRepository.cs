using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data {
    public class PublisherRepository : IPublisherRepository {
        private readonly DataContext _context;

        public PublisherRepository(DataContext context) {
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

        public Publisher[] GetAllPublishers() {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);
            
            return query.ToArray();

        }

        public Publisher GetlPublisherById(int publisherId) {

            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where (p => p.Id == publisherId);

            return query.FirstOrDefault();
        }

        public Publisher GetlPublisherByName(string publisherName) {
           IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Name)
                .Where(p=> p.Name == publisherName);

            return query.FirstOrDefault();

            
        }
    }
}
