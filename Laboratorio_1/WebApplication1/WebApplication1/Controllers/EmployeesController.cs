using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            IEnumerable<Employee> coLEmployees = _context.Employees;
            return View(coLEmployees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

           
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Record added Successfully!";
                   
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeefromdb = _context.Employees.Find(id);

            if (employeefromdb == null)
            {
                return NotFound();
            }

            return View(employeefromdb);

        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["Resultok"] = "Data Updated Successfally!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id <=0)
            {
                return NotFound();
            }
            var employeefromdb = _context.Employees.Find(id);

            if (employeefromdb == null)
            {
                return NotFound();
            }
 
            return View(employeefromdb);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var employeefromdb = _context.Employees.Find(id);
                if (employeefromdb == null)
                {
                    return NotFound();
                }

                _context.Employees.Remove(employeefromdb);
                _context.SaveChanges();
                TempData["Resultok"] = "Data Deleted Successfully!";
                return RedirectToAction("Index");
            }

            catch
            {
                return View(); //eapob
            }
        }
    }
}
