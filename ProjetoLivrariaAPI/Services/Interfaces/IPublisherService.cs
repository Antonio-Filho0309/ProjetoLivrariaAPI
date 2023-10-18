using Locadora.API.Services;
using ProjetoLivrariaAPI.Dtos.Publisher;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IPublisherService {

        Task<ResultService<ICollection<PublisherDto>>> Get();
        Task<ResultService<PublisherDto>> GetById(int id);
        Task<ResultService> Create(CreatePublisherDto createPublisherDto);
        Task<ResultService> Update(UpdatePublisherDto updatePublisherDto);
        Task <ResultService> Delete(int id);
    }
}
