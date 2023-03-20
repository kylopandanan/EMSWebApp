using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMSWebApp.Data;
using EMSWebApp.Models;
using EMSWebApp.Repository;

namespace EMSWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly EMSDbContext _context;

        public DepartmentsController(EMSDbContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
              return _context.Departments != null ? 
                          View(await _context.Departments.ToListAsync()) :
                          Problem("Entity set 'EMSDbContext.Departments'  is null.");
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'EMSDbContext.Departments'  is null.");
            }
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }

        //********************************************************************INMEMORY

       /* private readonly IEMSRepo _repo;

        public DepartmentsController(IEMSRepo repo)
        {
            this._repo = repo;
        }

        public IActionResult GetAllDepartmentss()
        {
            var departmentlist = _repo.GetAllDepartments();
            return View(departmentlist);
        }
        public IActionResult Details(int departmentId)
        {
            var department = _repo.GetDepartmentById(departmentId);
            return View(department);
        }
        public IActionResult Delete(int departmentId)
        {
            var department = _repo.GetDepartmentById(departmentId);
            return RedirectToAction(controllerName: "Departments", actionName: "GetAllDepartments"); // reload the getall page it self
        }*/

        /* [HttpGet]
         public IActionResult Create()
         {
             return View();
         }
         [HttpPost]
         public IActionResult Create(Employee newEmployee) // model binded this where the views data is accepted 
         {
             if (ModelState.IsValid)
             {
                 var employee = _repo.GetEmployeeById(employeeId);
                 return RedirectToAction("GetAllEmployees");
             }
             ViewData["Message"] = "Data is not valid to create the Employee";
             return View();
         }*/

       /* [HttpGet]
        public IActionResult Update(int departmentId)
        {
            var oldDepartment = _repo.GetDepartmentById(departmentId);
            return View(oldDepartment);
        }
        [HttpPost]
        public IActionResult Update(Department newDepartment)
        {
            var department = _repo.UpdateDepartment(newDepartment.DepartmentId, newDepartment);
            return RedirectToAction("GetAllDepartments");
        }*/
    }
}
