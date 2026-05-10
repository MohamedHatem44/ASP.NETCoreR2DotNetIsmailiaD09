using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        /*------------------------------------------------------------------*/
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------*/
        public IEnumerable<Employee> GetAllWithDepartment()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }
        /*------------------------------------------------------------------*/
        public Employee? GetByIdWithDepartment(int EmployeeId)
        {
            return _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == EmployeeId);
        }
        /*------------------------------------------------------------------*/
    }
}
