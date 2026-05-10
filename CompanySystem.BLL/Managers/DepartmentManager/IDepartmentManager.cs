namespace CompanySystem.BLL
{
    public interface IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        // Get All Departments
        List<DepartmentReadVM> GetAllDepartments();
        /*------------------------------------------------------------------*/
        // Get Department By Id
        DepartmentReadVM? GetDepartmentById(int id);
        /*------------------------------------------------------------------*/
        // Create New Department
        void CreateDepartment(DepartmentCreateVM departmentCreateVM);
        /*------------------------------------------------------------------*/
        // Update Department
        void UpdateDepartment(DepartmentEditVM departmentEditVM);
        /*------------------------------------------------------------------*/
        // Delete Department
        void DeleteDepartment(int id);
        /*------------------------------------------------------------------*/
    }
}
