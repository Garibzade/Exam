using GaribExam.DAL;
using GaribExam.Models;
using GaribExam.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaribExam.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize]
    public class EmployeeController : Controller
    {

        private readonly BlogerContext _context;

        public EmployeeController(BlogerContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            return View( await _context.Employees.Select(e=>new GetAdminEmployeeVM 
            { 
                Id = e.Id,
                Gmail = e.Gmail,
                ImageUrl = e.ImageUrl,
                Name = e.Name,
                Position = e.Position

            }).ToListAsync());

        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM vm)
        {
            if (!ModelState.IsValid) 
                return View(vm);

            Employee employee = new Employee
            {
                Name= vm.Name,
                Position= vm.Position,
                Gmail= vm.Gmail,
                ImageUrl= vm.ImageUrl,
                
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null && id < 1)
                return BadRequest();
            Employee employee=await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            UpdateEmployeeVM vm = new UpdateEmployeeVM
            {
                Name = employee.Name,
                Position = employee.Position,
                Gmail= employee.Gmail,
                ImageUrl= employee.ImageUrl,
            };
            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateEmployeeVM vm)
        {
            if (id == null && id < 1)
                return BadRequest();
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            employee.Name = vm.Name;
            employee.Position = vm.Position;
            employee.Gmail = vm.Gmail;
            employee.ImageUrl = vm.ImageUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null && id<1)
                return BadRequest();
            var data = await _context.Employees.FindAsync(id);
            if (data is null)
                return BadRequest();
            _context.Employees.Remove(data);    
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            
        }

    }
}
