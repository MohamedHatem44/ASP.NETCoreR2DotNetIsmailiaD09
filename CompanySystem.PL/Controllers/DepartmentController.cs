using CompanySystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.PL.Controllers
{
    public class DepartmentController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly IDepartmentManager _departmentManager;
        /*------------------------------------------------------------------*/
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        /*------------------------------------------------------------------*/
        // Get All Departments
        [HttpGet]
        public IActionResult Index()
        {
            var departmentsReadVM = _departmentManager.GetAllDepartments();
            return View(departmentsReadVM);
        }
        /*------------------------------------------------------------------*/
        // View Details 
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentManager.GetDepartmentById(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
        /*------------------------------------------------------------------*/
        // Create New Department
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        // Create New Department
        [HttpPost]
        public IActionResult Create(DepartmentCreateVM departmentCreateVM)
        {
            _departmentManager.CreateDepartment(departmentCreateVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // Edit Department
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var departmentEditVM = _departmentManager.GetDepartmentById(id);
            if (departmentEditVM == null)
            {
                return RedirectToAction("Index");
            }

            return View(departmentEditVM);
        }
        /*------------------------------------------------------------------*/
        // Edit Department
        [HttpPost]
        public IActionResult Edit(DepartmentEditVM departmentEditVM)
        {
            _departmentManager.UpdateDepartment(departmentEditVM);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // Delete Department
        public IActionResult Delete(int id)
        {
            var department = _departmentManager.GetDepartmentById(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }
            _departmentManager.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
