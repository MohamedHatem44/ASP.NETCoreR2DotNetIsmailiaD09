namespace CompanySystem.DAL
{
    public class Department : IAuditEntity
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        public required string Name { get; set; }
        /*------------------------------------------------------------------*/
        public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
        /*------------------------------------------------------------------*/
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        /*------------------------------------------------------------------*/
    }
}
