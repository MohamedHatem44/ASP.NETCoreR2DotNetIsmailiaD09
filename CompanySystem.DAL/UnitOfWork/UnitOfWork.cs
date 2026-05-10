namespace CompanySystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }
        /*------------------------------------------------------------------*/
        public UnitOfWork
            (
                AppDbContext context,
                IEmployeeRepository employeeRepository,
                IDepartmentRepository departmentRepository
            )
        {
            _context = context;
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }
        /*------------------------------------------------------------------*/
        public void Save()
        {
            _context.SaveChanges();
        }
        /*------------------------------------------------------------------*/
    }
}
