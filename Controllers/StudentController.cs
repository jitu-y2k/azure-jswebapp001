using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext _context;

        public StudentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList<Student>();
            return View(students);
        }

        [HttpGet]
        public IActionResult NewStudent()
        {
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View("NewStudent", student);
            }

            _context.Students.Add(student);

            _context.SaveChanges();

            return RedirectToAction("GetStudents");
        }
    }
}
