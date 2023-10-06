using ProjetoLivrariaAPI.Dtos.Publisher;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IPublisherService {
       Task<ResultService> Create(CreatePublisherDto createPublisherDto);
    }
}
