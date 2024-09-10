using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services {
    public interface IPersonService {
        Person Create(Person person);
        
        Person Update(Person person);

        void Delete(long id);

        Person GetById(long id);
        List<Person> FindAll();
    }
}
