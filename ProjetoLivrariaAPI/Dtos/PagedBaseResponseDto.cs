using Microsoft.EntityFrameworkCore.Storage;    

namespace ProjetoLivrariaAPI.Dtos {
    public class PagedBaseResponseDto<T> {
        public PagedBaseResponseDto(int totalRegisters, List<T> data) {
            TotalRegisters = totalRegisters;
            Data = data;
           
        }

        public int TotalRegisters { get; private set; }
        public List<T> Data { get; set; }
    }
}
