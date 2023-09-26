using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Data.Intefaces {
    public interface IPublisherRepository {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Publisher[] GetAllPublishers();
        Publisher GetlPublisherById(int publisherId);

        Publisher GetlPublisherByName(string publisherName);


    }
}
