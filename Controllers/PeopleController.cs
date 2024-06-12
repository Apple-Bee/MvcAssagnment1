using MvcAssagnment1.Services;
using MvcAssagnment1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MvcAssagnment1.Models;

namespace MvcAssagnment1.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index(string searchQuery)
        {
            var people = string.IsNullOrEmpty(searchQuery) ?
                _peopleService.GetAll() :
                _peopleService.Search(searchQuery);

            var viewModel = people.Select(p => new PersonViewModel
            {
                Id = p.Id,
                Name = p.Name,
                City = p.City
            }).ToList();

            return View(viewModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new Person
                {
                    Name = model.Name,
                    City = model.City
                };
                _peopleService.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var person = _peopleService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            var viewModel = new PersonViewModel
            {
                Id = person.Id,
                Name = person.Name,
                City = person.City
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _peopleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
