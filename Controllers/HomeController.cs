using System.Diagnostics;
using CfirstApproch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CfirstApproch.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDBContext employeeDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(EmployeeDBContext employeeDB)
        {
            this.employeeDB=employeeDB;
          
        }
        public async Task<IActionResult>Index()
        {
            var empData=await employeeDB.Employees.ToListAsync();
            return View(empData);
        }
        //CRUD Operation
        public IActionResult Create()  //Create Method
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {

                await employeeDB.Employees.AddAsync(emp);
                await employeeDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        //Edit Method
        public async Task<IActionResult>Edit(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var empData=await employeeDB.Employees.FindAsync(id);
            if (empData == null) {
                return NotFound();
            }

            return View(empData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Employee editEmployee)
        {
            if (id != editEmployee.ID) {

                return NotFound();
            
            }
            if (ModelState.IsValid)
            {
                //If update the employee Data in the database
                employeeDB.Entry(editEmployee).State=EntityState.Modified;  
                await employeeDB.SaveChangesAsync();

                //Redirect to the details action
                return RedirectToAction("Index", "Home");
            }
            return View(editEmployee);
        }
        //Detail
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || employeeDB.Employees == null)
            {
                return NotFound();
            }

            var empData = await employeeDB.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (empData == null)
            {
                return NotFound();
            }

            return View(empData);
        }
        //Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || employeeDB.Employees == null)
            {
                return NotFound();
            }
            var empData = await employeeDB.Employees.FindAsync(id);
            if (empData == null)
            {
                return NotFound();
            }
            return View(empData);
        }
        //Create Method for Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var empData = await employeeDB.Employees.FindAsync(id);
            if (empData == null)
            {
                return NotFound();
            }

            employeeDB.Employees.Remove(empData);
            await employeeDB.SaveChangesAsync();

            // Redirect to the index page.
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
