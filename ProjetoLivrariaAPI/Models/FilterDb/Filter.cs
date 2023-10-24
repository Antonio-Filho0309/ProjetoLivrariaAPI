using ProjetoLivrariaAPI.Pagination;

namespace ProjetoLivrariaAPI.Models.FilterDb
{
    public class Filter : PagedBaseRequest
    {
        public string Search { get; set; }
    }
}
