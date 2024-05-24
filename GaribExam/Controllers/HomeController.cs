
using GaribExam.DAL;
using GaribExam.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaribExam.Controllers
{
    public class HomeController(BlogerContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.Select(opt=>new GetEmployeeVM
            {
                Name = opt.Name,
                Gmail = opt.Gmail,
                Id = opt.Id,    
                ImageUrl = opt.ImageUrl,
                Position = opt.Position,
            }).ToListAsync());
        }
    }
}
