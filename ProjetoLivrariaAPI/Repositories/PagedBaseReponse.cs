namespace ProjetoLivrariaAPI.Repositories {
    public class PagedBaseReponse<T> {
       public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}
