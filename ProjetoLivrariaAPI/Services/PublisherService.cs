using AutoMapper;
using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.Publisher;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;
using ProjetoLivrariaAPI.Models.Dtos.Book;

namespace ProjetoLivrariaAPI.Services
{
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
                return ResultService.NotFound<PublisherDto>("Editora não encontrada");
            return ResultService.Ok(_mapper.Map<PublisherDto>(publisher));


        }

        public async Task<ResultService> Create(CreatePublisherDto createPublisherDto) {
            if (createPublisherDto == null)
                return ResultService.BadRequest("Objeto deve ser informado");

            var result = new PublisherDtoValidator().Validate(createPublisherDto);
            if (!result.IsValid)
                return ResultService.BadRequest(result);

            var publisher = _mapper.Map<Publisher>(createPublisherDto);

            var sameName = await _publisherRepository.GetlPublisherByName(createPublisherDto.Name);
            if (sameName != null)
                return ResultService.BadRequest("Editora já cadastrada .");

            await _publisherRepository.Add(publisher);
            return ResultService.Ok("Editora Criada com Sucesso");
        }

        public async Task<ResultService> Update(UpdatePublisherDto updatePublisherDto) {
            if (updatePublisherDto == null)
                return ResultService.NotFound("Editora não encontrada");
            var validation = new UpdatePublisherDtoValidator().Validate(updatePublisherDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);
            var publisher = await _publisherRepository.GetlPublisherById(updatePublisherDto.Id);
            if (publisher == null)

                return ResultService.NotFound("Editora não encontrada");

            if(updatePublisherDto.Name != publisher.Name)
            {
                var sameName = await _publisherRepository.GetlPublisherByName(updatePublisherDto.Name);
                if (sameName != null)
                    return ResultService.BadRequest("Editora já cadastrada .");
            }
            publisher = _mapper.Map(updatePublisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.Ok("Editora atualizada com Sucesso");
        }

        public async Task<ResultService> Delete(int id) {
            var publisher = await _publisherRepository.GetlPublisherById(id);
            if (publisher == null)
                return ResultService.NotFound("Editora não encontrada");
            var bookAssociation =  await _bookRepository.GetBookByPublisherId(id);
            if (bookAssociation != null)
                return ResultService.BadRequest("Possui associação com livros");
            await _publisherRepository.Delete(publisher);
            return ResultService.Ok("Editora deletada com Sucesso");
        }

        public async Task<ResultService<List<PublisherDto>>> GetPagedAsync(Filter publisherFilter) {
            var publisher = await _publisherRepository.GetAllPublisherPaged(publisherFilter);
            var result = new PagedBaseResponseDto<PublisherDto>(publisher.TotalRegisters, publisher.TotalPages, publisher.PageNumber, _mapper.Map<List<PublisherDto>>(publisher.Data));

            if (result.Data.Count == 0)
                return ResultService.NotFound<List<PublisherDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.PageNumber);
        }

        public async Task<ResultService<ICollection<PublisherBookDto>>> GetSelect() {
            var publisher = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok(_mapper.Map<ICollection<PublisherBookDto>>(publisher));
        }

        public async  Task<ResultService<List<PublisherDashDto>>> GetDash()
        {
                var publishers  = await _publisherRepository.GetAllPublishers();
                return ResultService.Ok(_mapper.Map<List<PublisherDashDto>>(publishers)); 
        }
    }
}
