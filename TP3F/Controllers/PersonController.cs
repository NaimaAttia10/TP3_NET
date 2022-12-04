using Microsoft.AspNetCore.Mvc;
using System;
using TP3F.Models;

namespace TP3F.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id:int}")]
        public IActionResult index(int id)
        {
            Personal_info personal_info = new Personal_info();

            return View(personal_info.GetPerson(id));
        }
        [Route("Person/")]
        public IActionResult all()
        {
            Personal_info personal_info = new Personal_info();

            return View(personal_info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult search(String first_name, String country)
        {
            Personal_info personal_info = new Personal_info();
            List<Person> personal__info = personal_info.GetAllPerson();
            foreach (Person person in personal__info)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect(person.id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}

