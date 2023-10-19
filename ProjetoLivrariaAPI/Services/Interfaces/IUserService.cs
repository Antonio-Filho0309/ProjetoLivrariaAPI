using Locadora.API.Services;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.FiltersDb;
using ProjetoLivrariaAPI.Repositories;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IUserService  {
        Task<ResultService<ICollection<UserDto>>> Get();
        Task<ResultService<UserDto>> GetById(int id);
        Task<ResultService> Create(CreateUserDto CreateUserDto);
        Task<ResultService> Update(UpdateUserDto updateUserDto);
        Task<ResultService> Delete(int id);

        Task<ResultService<List<UserDto>>> GetPagedAsync(Filter userFilterDb);
       
    }
}
