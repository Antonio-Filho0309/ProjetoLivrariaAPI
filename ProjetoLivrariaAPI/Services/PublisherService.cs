using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class PublisherService : IPublisherService {
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IBookRepository _bookRepository;

        public PublisherService(IMapper mapper, IPublisherRepository publisherRepository , IBookRepository bookRepository) {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
            _bookRepository = bookRepository;
        }
        public async Task<ResultService<ICollection<PublisherDto>>> Get() {
            var publishers = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok(_mapper.Map<ICollection<PublisherDto>>(publishers));
        }

        public async Task<ResultService<PublisherDto>> GetById(int id) {
            var publisher = await _publisherRepository.GetlPublisherById(id);
            if (publisher == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrada");
            return ResultService.Ok(_mapper.Map<PublisherDto>(publisher));


        }

        public async Task<ResultService> Create(CreatePublisherDto createPublisherDto) {
            if (createPublisherDto == null)
                return ResultService.Fail<CreatePublisherDto>("Objeto deve ser informado");

            var result = new PublisherDtoValidator().Validate(createPublisherDto);
            if (!result.IsValid)
                return ResultService.RequestError(result);

            var publisher = _mapper.Map<Publisher>(createPublisherDto);

            var sameName = await _publisherRepository.GetlPublisherByName(createPublisherDto.Name);
            if (sameName != null)
                return ResultService.Fail("Editora já cadastrada !");

            await _publisherRepository.Add(publisher);
            return ResultService.Ok(publisher);
        }

        public async Task<ResultService> Update(UpdatePublisherDto updatePublisherDto) {
            if (updatePublisherDto == null)
                return ResultService.Fail("Editora não encontrada");
            var validation = new UpdatePublisherDtoValidator().Validate(updatePublisherDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);
            var publisher = await _publisherRepository.GetlPublisherById(updatePublisherDto.Id);
            if (publisher == null)
                return ResultService.Fail("Editora não encontrada");
            publisher = _mapper.Map(updatePublisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.Ok("Editora atualizada com sucesso");
        }

        public async Task<ResultService> Delete(int id) {
            var publisher = await _publisherRepository.GetlPublisherById(id);
            if (publisher == null)
                return ResultService.Fail("Editora não encontrada");
            var bookAssociation =  await _bookRepository.GetBookByPublisherId(id);
            if (bookAssociation != null)
                return ResultService.Fail("Erro ao excluir editora: Possui relação com livros");
            await _publisherRepository.Delete(publisher);
            return ResultService.Ok("Editora deletada com sucesso");
        }

        public async Task<ResultService<List<PublisherDto>>> GetPagedAsync(Filter publisherFilter) {
            var user = await _publisherRepository.GetAllPublisherPaged(publisherFilter);
            var result = new PagedBaseResponseDto<PublisherDto>(user.TotalRegisters, _mapper.Map<List<PublisherDto>>(user.Data));

            if (result.Data.Count == 0)
                return ResultService.Fail<List<PublisherDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters);
        }

        public async Task<ResultService<ICollection<PublisherBookDto>>> GetSelect() {
            var publisher = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok(_mapper.Map<ICollection<PublisherBookDto>>(publisher));
        }

    }
}
