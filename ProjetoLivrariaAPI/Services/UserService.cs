using AutoMapper;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository) {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResultService<ICollection<UserDto>>> Get() {
            var users = await _userRepository.GetAllUsers();
            return ResultService.ok(_mapper.Map<ICollection<UserDto>>(users));
        }

        public async  Task<ResultService<UserDto>> GetById(int id) {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return ResultService.Fail<UserDto>("Usuário não encontrado !");
            return ResultService.ok(_mapper.Map<UserDto>(user));
        }

        public async Task<ResultService> Create(CreateUserDto createUserDto) {
            if (createUserDto == null)
                return ResultService.Fail<CreateUserDto>("Objeto deve ser informado");

            var result = new UserDtoValidator().Validate(createUserDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateUserDto>("Problemas de Validade", result);

            var user = _mapper.Map<User>(createUserDto);

            await _userRepository.Add(user);
            return ResultService.ok(user);
        }

       
    }
}
