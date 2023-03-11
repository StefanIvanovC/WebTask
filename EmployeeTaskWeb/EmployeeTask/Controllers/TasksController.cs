using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTask.Data;
using EmployeeTask.Data.Models;
using Task = EmployeeTask.Data.Models.Task;

namespace EmployeeTask.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Task.Include(t => t.AssignedEmployee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["AssignedEmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,AssignedEmployeeId,IsCompleted")] Task task)
        {
            _context.Add(task);

            var employee = _context.Employees.FirstOrDefault(e => e.Id == task.AssignedEmployeeId);
            employee.Tasks.Add(task);
            await _context.SaveChangesAsync();
            TempData["task"] = "Task is created successfully!";
            ViewData["AssignedEmployeeId"] = new SelectList(_context.Employees, "Id", "Id", task.AssignedEmployeeId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["AssignedEmployeeId"] = new SelectList(_context.Employees, "Id", "Id", task.AssignedEmployeeId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,AssignedEmployeeId,IsCompleted")] Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(task.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            ViewData["AssignedEmployeeId"] = new SelectList(_context.Employees, "Id", "Id", task.AssignedEmployeeId);
            TempData["task"] = "Task is edited successfully!";
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.AssignedEmployee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Task'  is null.");
            }
            var task = await _context.Task.FindAsync(id);
            if (task != null)
            {
                _context.Task.Remove(task);
            }

            await _context.SaveChangesAsync();
            TempData["task"] = "Task is deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
