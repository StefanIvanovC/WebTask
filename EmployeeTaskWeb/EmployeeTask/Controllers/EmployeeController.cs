using EmployeeTask.Data;
using EmployeeTask.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = dbContext.Employees;
            return View(employeeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(employee);
                dbContext.SaveChanges();
                TempData["employee"] = "Employee is created successfully!";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Update(employee);
                dbContext.SaveChanges();
                TempData["employee"] = "Employee is edited successfully!";
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            dbContext.Remove(employee);
            dbContext.SaveChanges();
            TempData["employee"] = "Employee is deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
