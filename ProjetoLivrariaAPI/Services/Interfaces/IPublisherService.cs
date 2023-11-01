using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos.Publisher;
using ProjetoLivrariaAPI.Models.FilterDb;

namespace ProjetoLivrariaAPI.Services.Interfaces
{
    public interface IPublisherService {

        Task<ResultService<ICollection<PublisherDto>>> Get();
        Task<ResultService<PublisherDto>> GetById(int id);
        Task<ResultService> Create(CreatePublisherDto createPublisherDto);
        Task<ResultService> Update(UpdatePublisherDto updatePublisherDto);

        Task<ResultService<ICollection<PublisherBookDto>>> GetSelect();
        Task <ResultService> Delete(int id);

        Task<ResultService<List<PublisherDto>>> GetPagedAsync(Filter publisherFilter);

        Task<ResultService<List<PublisherDashDto>>> GetDash();
    }
}
