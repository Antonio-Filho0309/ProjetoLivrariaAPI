using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoLivrariaAPI.Models.Dtos.User;
using ProjetoLivrariaAPI.Models.FilterDb;
using ProjetoLivrariaAPI.Repositories;

namespace ProjetoLivrariaAPI.Services.Interfaces
{
    public interface IUserService  {
        Task<ResultService<ICollection<UserDto>>> Get();
        Task<ResultService<UserDto>> GetById(int id);
        Task<ResultService> Create(CreateUserDto CreateUserDto);
        Task<ResultService> Update(UpdateUserDto updateUserDto);
        Task<ResultService> Delete(int id);

        Task<ResultService<ICollection<UserRentalDto>>> GetSelect();

        Task<ResultService<List<UserDto>>> GetPagedAsync(Filter userFilter);
       
    }
}
