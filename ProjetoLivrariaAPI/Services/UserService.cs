using AutoMapper;
using ProjetoLivrariaAPI.Data.Intefaces;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Dtos.Validators;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class UserService : IUserService {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UserDto>> CreateAsync(UserDto userDto) {
            if (userDto == null) {
                return ResultService.Fail<UserDto>("Objeto deve ser informado !!");
               
                var result = new UserDtoValidator().Validate(userDto);
                if (!result.IsValid)
                    return ResultService.RequestError<UserDto>("Problemas de validação !", result);

                var person = 
            }
        }
    }
}
