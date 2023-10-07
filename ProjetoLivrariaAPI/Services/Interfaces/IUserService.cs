using ProjetoLivrariaAPI.Dtos.User;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IUserService  {
        Task<ResultService<ICollection<UserDto>>> Get();
        Task<ResultService<UserDto>> GetById(int id);
        Task<ResultService> Create(CreateUserDto CreateUserDto);
        Task<ResultService> Update(UpdateUserDto updateUserDto);
        Task<ResultService> Delete(int id);

       
    }
}
