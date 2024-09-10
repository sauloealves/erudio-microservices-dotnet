using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations {
    public class PersonServiceImplementation :IPersonService {
        public Person Create(Person person) {
            return person;
        }

        public void Delete(long id) {
        }

        public List<Person> FindAll() {
            return new List<Person> { new Person() { Id = 1, Address = "endereco", FirstName = "firstname", Gender = "M", LastName = "Lastname"
            } };
        }

        public Person GetById(long id) {
            return new Person { Id = 1, Address = "endereco", FirstName = "firstname", Gender = "M", LastName = "Lastname"
            };
        }

        public Person Update(Person person) {
            return new Person();
        }
    }
}
