using CompanySystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.PL.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly IEmployeeManager _employeeManager;
        /*------------------------------------------------------------------*/
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        /*------------------------------------------------------------------*/
        // Index => List All => Main Action => Landing Page
        [HttpGet]
        public IActionResult Index()
        {
            var employeesReadVM = _employeeManager.GetAllEmployees();
            return View(employeesReadVM);
        }
        /*------------------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeeManager.GetEmployeeById(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        /*------------------------------------------------------------------*/
        // Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            var employeeCreateVM = new EmployeeCreateVM
            {
                Departments = _employeeManager.GetDepartmentList()
            };
            return View(employeeCreateVM);
        }
        /*------------------------------------------------------------------*/
        // Create Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCreateVM employeeCreateVM)
        {
            if (!ModelState.IsValid)
            {
                employeeCreateVM.Departments = _employeeManager.GetDepartmentList();
                return View(employeeCreateVM);
            }

            _employeeManager.CreateEmployee(employeeCreateVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // Edit Employee
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employeeEditVM = _employeeManager.GetEmployeeById(id);
            if (employeeEditVM == null)
            {
                return RedirectToAction("Index");
            }

            return View(employeeEditVM);
        }
        /*------------------------------------------------------------------*/
        // Edit Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeEditVM employeeEditVM)
        {
            var employeeInDb = _employeeManager.GetEmployeeById(employeeEditVM.Id);
            if (employeeInDb == null)
            {
                return RedirectToAction("Index");
            }

           _employeeManager.UpdateEmployee(employeeEditVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // Delete Employee
        public IActionResult Delete(int id)
        {
            _employeeManager.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
