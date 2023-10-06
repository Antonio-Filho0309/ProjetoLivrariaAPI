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

        public PublisherService(IMapper mapper , IPublisherRepository publisherRepository) {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
        }

        public async Task<ResultService> Create(CreatePublisherDto createPublisherDto) {
            if (createPublisherDto == null)
                return ResultService.Fail<CreatePublisherDto>("Objeto deve ser informado");

            var result = new PublisherDtoValidator().Validate(createPublisherDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreatePublisherDto>("Problemas de Validade", result);

            var publisher = _mapper.Map<Publisher>(createPublisherDto);

            await _publisherRepository.Add(publisher);
            return ResultService.ok(publisher);
        }
    }
}
