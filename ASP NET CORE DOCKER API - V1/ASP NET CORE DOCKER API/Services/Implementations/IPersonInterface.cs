using ASP_NET_CORE_DOCKER_API.Model;
using System.Collections.Generic;

namespace ASP_NET_CORE_DOCKER_API.Services.Implementations
{
    public interface IPersonInterface
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
