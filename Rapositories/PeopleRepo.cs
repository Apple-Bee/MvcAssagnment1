using MvcAssagnment1.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcAssagnment1.Repositories
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly List<Person> _people = new List<Person>();

        public IEnumerable<Person> GetAll() => _people;

        public Person? GetById(int id) => _people.FirstOrDefault(p => p.Id == id);

        public void Add(Person person)
        {
            person.Id = _people.Count > 0 ? _people.Max(p => p.Id) + 1 : 1;
            _people.Add(person);
        }

        public void Delete(int id)
        {
            var person = GetById(id);
            if (person != null)
            {
                _people.Remove(person);
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            return _people.Where(p => (p.Name != null && p.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase)) ||
                                      (p.City != null && p.City.Contains(query, System.StringComparison.OrdinalIgnoreCase)));
        }
    }
}
