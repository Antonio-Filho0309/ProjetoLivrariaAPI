using Microsoft.EntityFrameworkCore.Storage;

namespace ProjetoLivrariaAPI.Dtos {
    public class PagedBaseResponseDto<T> {
        public PagedBaseResponseDto(int totalRegister, List<T> data) {
            TotalRegister = totalRegister;
            Data = data;
           
        }

        public int TotalRegister { get; private set; }
        public List<T> Data { get; set; }
    }
}
