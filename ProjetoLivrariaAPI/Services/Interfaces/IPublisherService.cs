using ProjetoLivrariaAPI.Dtos.Publisher;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IPublisherService {

        Task<ResultService<ICollection<PublisherDto>>> Get();
        Task<ResultService<PublisherDto>> GetById(int id);
        Task<ResultService> Create(CreatePublisherDto createPublisherDto);
    }
}
