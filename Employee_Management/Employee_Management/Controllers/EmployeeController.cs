using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Assignment3Context _db;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, Assignment3Context context)
        {
            _logger = logger;
            _db = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> emplist  = _db.Employees;
            IEnumerable<Department> deptlist = _db.Departments.AsEnumerable();
            /* var employeeRecord = (from e in emplist
                                  join d in deptlist on e.DeptId equals d.DeptId
                                  select new EmpDeptViewModel
                                  {
                                     MngrId = e.MngrId,
                                     DeptId = e.DeptId,
                                     DeptName = d.DeptName,
                                     EmpId = e.EmpId,
                                     EmpName = e.EmpName

                                  });*/
            var employee = _db.Employees.Include(c=>c.Dept).AsQueryable();
            return View(employee.ToList());
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
