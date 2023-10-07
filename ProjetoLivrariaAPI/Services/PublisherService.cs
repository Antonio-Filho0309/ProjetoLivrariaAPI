using AutoMapper;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class PublisherService : IPublisherService {
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IMapper mapper, IPublisherRepository publisherRepository) {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
        }
        public async Task<ResultService<ICollection<PublisherDto>>> Get() {
            var publishers = await _publisherRepository.GetAllPublishers();
            return ResultService.ok(_mapper.Map<ICollection<PublisherDto>>(publishers));
        }

        public async Task<ResultService<PublisherDto>> GetById(int id) {
            var publisher = await _publisherRepository.GetlPublisherById(id);
            if (publisher == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrada");
            return ResultService.ok(_mapper.Map<PublisherDto>(publisher));


        }

        public async Task<ResultService> Create(CreatePublisherDto createPublisherDto) {
            if (createPublisherDto == null)
                return ResultService.Fail<CreatePublisherDto>("Objeto deve ser informado");

            var result = new PublisherDtoValidator().Validate(createPublisherDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreatePublisherDto>("Problemas de Validação", result);

            var publisher = _mapper.Map<Publisher>(createPublisherDto);

            await _publisherRepository.Add(publisher);
            return ResultService.ok(publisher);
        }

        public async Task<ResultService> Update(UpdatePublisherDto updatePublisherDto) {
            if (updatePublisherDto == null)
                return ResultService.Fail("Editora não encontrada");
            var validation = new UpdatePublisherDtoValidator().Validate(updatePublisherDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com validação de campos", validation);
            var publisher = await _publisherRepository.GetlPublisherById(updatePublisherDto.Id);
            if (publisher == null)
                return ResultService.Fail("Editora não encontrada");
            publisher = _mapper.Map(updatePublisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.ok("Editora atualizada com sucesso");
        }

        public async Task<ResultService> Delete(int id) {
            var publisher = await _publisherRepository.GetlPublisherById(id);
            if (publisher == null)
                return ResultService.Fail("Editora não encontrada");
            await _publisherRepository.Delete(publisher);
            return ResultService.ok("Editora deletada com sucesso");
        }
    }
}
