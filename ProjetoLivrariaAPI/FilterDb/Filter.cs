using ProjetoLivrariaAPI.Pagination;

namespace ProjetoLivrariaAPI.FiltersDb
{
    public class Filter : PagedBaseRequest {
        public string Search { get; set; }
    }
}
