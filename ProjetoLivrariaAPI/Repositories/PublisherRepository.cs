using Microsoft.EntityFrameworkCore;
using ProjetoLivrariaAPI.Data;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Pagination;
using ProjetoLivrariaAPI.Repositories.Intefaces;

namespace ProjetoLivrariaAPI.Repositories
{
    public class PublisherRepository : IPublisherRepository {
        private readonly DataContext _context;

        public PublisherRepository(DataContext context) {
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

        public async Task<PagedBaseReponse<Publisher>> GetAllPublisherPaged(Filter publisherFilter) {
            var publisher = _context.Publishers.AsQueryable();
            if (!string.IsNullOrEmpty(publisherFilter.Search))
            {
                var filter = publisherFilter.Search.ToLower();

                publisher = publisher.Where(p =>
                p.Name.ToLower().Contains(filter) ||
                p.Id.ToString().Contains(publisherFilter.Search) ||
                p.City.ToLower().Contains(filter));
            }
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseReponse<Publisher>, Publisher> (publisher, publisherFilter);
        }
    }
}
