namespace CompanySystem.DAL
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetAllWithDepartment();
        Employee? GetByIdWithDepartment(int EmployeeId);
    }
}
