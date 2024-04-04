using Microsoft.AspNetCore.Mvc;
using MVC_osobe.Models;

namespace MVC_osobe.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student() 
            {
                Id = 1,
                Ime="Mirko",
                Prezime="Filipović",
                Dob=51
            };

            return View(student);
        }
    }
}
