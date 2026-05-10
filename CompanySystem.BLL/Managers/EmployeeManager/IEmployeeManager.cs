namespace CompanySystem.BLL
{
    public interface IEmployeeManager
    {
        /*------------------------------------------------------------------*/
        // Get All Employees
        List<EmployeeReadVM> GetAllEmployees();
        /*------------------------------------------------------------------*/
        // Get Employee By Id
        EmployeeReadVM? GetEmployeeById(int id);
        /*------------------------------------------------------------------*/
        // Create New Employee
        void CreateEmployee(EmployeeCreateVM employeeCreateVM);
        /*------------------------------------------------------------------*/
        // Update Employee
        void UpdateEmployee(EmployeeEditVM employeeEditVM);
        /*------------------------------------------------------------------*/
        // Delete Employee
        void DeleteEmployee(int id);
        /*------------------------------------------------------------------*/
        List<DepartmentReadVM>? GetDepartmentList();
        /*------------------------------------------------------------------*/
    }
}
