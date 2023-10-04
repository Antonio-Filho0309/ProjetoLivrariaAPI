using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IUserService {

        Task<ResultService<UserDto>> CreateAsync(UserDto userDto);
    }
}
