
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoLivrariaAPI.Dtos.Validations;

namespace ProjetoLivrariaAPI.Dtos {
    public class PagedBaseResponseDto<T> {
        public PagedBaseResponseDto(int totalRegisters, int page , int totalPages, List<T> data) {
            TotalRegisters = totalRegisters;
            Page = page;
            TotalPages = totalPages;
            Data = data;

        }

        public int TotalRegisters { get; private set; }
        public int TotalPages { get; private set; }
        public int Page { get; private set; }
        public List<T> Data { get; private set; }

    }
}
