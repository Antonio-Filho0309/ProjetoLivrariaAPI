using ProjetoLivrariaAPI.Repositories;

namespace ProjetoLivrariaAPI.FiltersDb {
    public class Filter : PagedBaseRequest {
        public string Value { get; set; }
    }
}
