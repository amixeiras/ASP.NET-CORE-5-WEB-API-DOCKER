using ASP_NET_CORE_DOCKER_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_DOCKER_API.Services.Implementations
{
    public class PersonService : IPersonInterface
    {
        public Person Create(Person person)
        {
            return new Person { Address = "Rua Joaquim de Melo", FirstName = "Eduardo", Id = 1, Gender = "M", LastName = "Marques" };
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                people.Add(new Person { Address = "Rua Joaquim de Melo", FirstName = "Eduardo", Id = 1, Gender = "M", LastName = "Marques" });
            }
            return people;
        }

        public Person FindById(long id)
        {
            return new Person { Address = "Rua Joaquim de Melo", FirstName = "Eduardo", Id = 1, Gender = "M", LastName = "Marques" };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
