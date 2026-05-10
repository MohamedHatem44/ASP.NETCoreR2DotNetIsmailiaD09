
using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class EmployeeManager : IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public List<EmployeeReadVM> GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAllWithDepartment();
            var employeesReadVM = employees.Select(e => new EmployeeReadVM
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                Department = e.Department.Name
            }).ToList();

            return employeesReadVM;
        }
        /*------------------------------------------------------------------*/
        public EmployeeReadVM? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByIdWithDepartment(id);
            if (employee == null)
            {
                return null;
            }

            var employeeReadVM = new EmployeeReadVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Department = employee.Department.Name
            };
            return employeeReadVM;
        }
        /*------------------------------------------------------------------*/
        public void CreateEmployee(EmployeeCreateVM employeeCreateVM)
        {
            throw new NotImplementedException();
        }
        /*------------------------------------------------------------------*/
        public void UpdateEmployee(EmployeeEditVM employeeEditVM)
        {
            throw new NotImplementedException();
        }
        /*------------------------------------------------------------------*/
        public void DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return;
            }
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
        public List<DepartmentReadVM>? GetDepartmentList()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();

            return departments.Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
        /*------------------------------------------------------------------*/
    }
}
