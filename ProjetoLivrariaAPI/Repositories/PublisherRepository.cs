using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext _context;

        public PublisherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Add(Publisher publisher) {
            _context.Add(publisher);
           await _context.SaveChangesAsync();
            return publisher;
        }


        public async Task Update(Publisher publisher) {
           _context.Update(publisher);
            await _context.SaveChangesAsync();
           
        }

        public async Task Delete(Publisher publisher) {
           _context.Remove(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Publisher>> GetAllPublishers() {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetlPublisherById(int publisherId) {

            return await _context.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);
        }

        public async Task<Publisher> GetlPublisherByName(string publisherName) {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Name == publisherName);
        }


        //public void Add<T>(T entity) where T : class
        //{
        //    _context.Add(entity);
        //}

        //public void Update<T>(T entity) where T : class
        //{
        //    _context.Update(entity);
        //}

        //public void Delete<T>(T entity) where T : class
        //{
        //    _context.Remove(entity);
        //}

        //public bool SaveChanges()
        //{
        //    return _context.SaveChanges() > 0;
        //}

        //public Publisher[] GetAllPublishers()
        //{
        //    IQueryable<Publisher> query = _context.Publishers;

        //    query = query.AsNoTracking().OrderBy(p => p.Id);

        //    return query.ToArray();

        //}

        //public Publisher GetlPublisherById(int publisherId)
        //{

        //    IQueryable<Publisher> query = _context.Publishers;

        //    query = query.AsNoTracking().OrderBy(p => p.Id)
        //        .Where(p => p.Id == publisherId);

        //    return query.FirstOrDefault();
        //}

        //public Publisher GetlPublisherByName(string publisherName)
        //{
        //    IQueryable<Publisher> query = _context.Publishers;

        //    query = query.AsNoTracking().OrderBy(p => p.Name)
        //        .Where(p => p.Name == publisherName);

        //    return query.FirstOrDefault();


        //}
    }
}
