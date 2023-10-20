using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Pagination;

namespace ProjetoLivrariaAPI.Repositories.Intefaces
{
    public interface IPublisherRepository
    {

        Task<Publisher> Add (Publisher publisher);
        Task Update (Publisher publisher);
        Task Delete (Publisher publisher);

        Task<ICollection<Publisher>> GetAllPublishers();

       Task<Publisher>  GetlPublisherById(int publisherId);

        Task<Publisher> GetlPublisherByName(string publisherName);

        Task<PagedBaseReponse<Publisher>> GetAllPublisherPaged(Filter publisherFilter);

    }
}
