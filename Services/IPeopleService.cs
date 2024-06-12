using MvcAssagnment1.Models;
using System.Collections.Generic;

namespace MvcAssagnment1.Services
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAll();
        Person? GetById(int id);
        void Add(Person person);
        void Delete(int id);
        IEnumerable<Person> Search(string query);
    }
}
