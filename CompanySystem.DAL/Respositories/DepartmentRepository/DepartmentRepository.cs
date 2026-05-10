namespace CompanySystem.DAL
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        /*------------------------------------------------------------------*/
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
        /*------------------------------------------------------------------*/
    }
}
