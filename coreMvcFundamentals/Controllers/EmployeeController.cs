using coreMvcFundamentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcFundamentals.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "King Kochhar", Age = 23 },
            new Employee() { Id = 2, Name = "John Smith", Age = 30 },
            new Employee() { Id = 3, Name = "King Kochhar", Age = 40 }
        };
        public IActionResult Index()
        {
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employees.Add(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            return View(employee);
        }
        public IActionResult Edit(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var emp = employees.Find(e => e.Id == employee.Id);
            emp.Name = employee.Name;
            emp.Age = employee.Age;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            employees.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}
