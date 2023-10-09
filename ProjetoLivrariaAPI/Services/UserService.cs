using AutoMapper;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Dtos.Validations;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Repositories.Intefaces;
using ProjetoLivrariaAPI.Services.Interfaces;

namespace ProjetoLivrariaAPI.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository , IRentalRepository rentalRepository) {
            _mapper = mapper;
            _userRepository = userRepository;
            _rentalRepository = rentalRepository;
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
                return ResultService.RequestError<CreateUserDto>("Problemas de Validação", result);

            var emailExist = await _userRepository.GetUserByEmail(createUserDto.Email);
            if (emailExist != null)
                return ResultService.Fail<User>("Email já cadastrado");

            var user = _mapper.Map<User>(createUserDto);

            await _userRepository.Add(user);
            return ResultService.ok(user);
        }

        public async Task<ResultService> Update(UpdateUserDto updateUserDto) {
            if (updateUserDto == null)
                return ResultService.Fail("Usuário deve ser informado");

            var validation =   new UpdateUserDtoValidator().Validate(updateUserDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos" , validation);
            var user = await _userRepository.GetUserById(updateUserDto.Id);
            if (user == null)
                return ResultService.Fail("Pessoa não encontrada");
            user = _mapper.Map(updateUserDto, user);

            await _userRepository.Update(user);

            return ResultService.ok("Usuário Atualizado com sucesso");
           
        }

        public async Task<ResultService> Delete(int id) {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return ResultService.Fail("Usuário não encontrado");
            var RentalAssociation = await _rentalRepository.GetRentalByUserId(id);
            if (RentalAssociation != null)
                return ResultService.Fail<User>("Erro ao excluir usuário: Possui relação com alugueis");
            await _userRepository.Delete(user);
            return ResultService.ok("Usuário Deletado com sucesso");
        }
    }
}
