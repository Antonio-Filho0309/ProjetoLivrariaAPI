using ProjetoLivrariaAPI.Dtos.Rental;

namespace ProjetoLivrariaAPI.Services.Interfaces {
    public interface IRentalService {
        Task<ResultService<ICollection<RentalDto>>> Get();
        Task<ResultService<RentalDto>> GetById(int id);
        Task<ResultService> Create(CreateRentalDto createRentalDto);
        Task<ResultService> Update(UpdateRentalDto updateRentalDto);
        Task<ResultService> Delete(int id);
    }
}
