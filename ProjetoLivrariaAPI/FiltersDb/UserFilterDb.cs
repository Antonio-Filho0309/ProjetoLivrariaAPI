using ProjetoLivrariaAPI.Repositories;

namespace ProjetoLivrariaAPI.FiltersDb {
    public class UserFilterDb : PagedBaseRequest {
        public string Name { get; set; }
    }
}
