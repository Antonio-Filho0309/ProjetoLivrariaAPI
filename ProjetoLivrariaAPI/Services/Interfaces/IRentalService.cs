using Locadora.API.Services;
using ProjetoLivrariaAPI.Models.Dtos.Rental;
using ProjetoLivrariaAPI.Models.FilterDb;

namespace ProjetoLivrariaAPI.Services.Interfaces
{
    public interface IRentalService {
        Task<ResultService<ICollection<RentalDto>>> Get();
        Task<ResultService<RentalDto>> GetById(int id);
        Task<ResultService> Create(CreateRentalDto createRentalDto);
        Task<ResultService> Update(UpdateRentalDto updateRentalDto);
        Task<ResultService<List<RentalDto>>> GetPagedAsync(Filter rentalFilter);

        Task<ResultService<List<RentalDashDto>>> GetDash();
    }
}
