using MvcAssagnment1.Models;
using MvcAssagnment1.Repositories;
using System.Collections.Generic;

namespace MvcAssagnment1.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public IEnumerable<Person> GetAll() => _peopleRepo.GetAll();

        public Person? GetById(int id) => _peopleRepo.GetById(id);

        public void Add(Person person) => _peopleRepo.Add(person);

        public void Delete(int id) => _peopleRepo.Delete(id);

        public IEnumerable<Person> Search(string query) => _peopleRepo.Search(query);
    }
}
