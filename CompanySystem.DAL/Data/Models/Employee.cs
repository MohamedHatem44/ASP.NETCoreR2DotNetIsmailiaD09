namespace CompanySystem.DAL
{
    public class Employee
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        /*------------------------------------------------------------------*/
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        /*------------------------------------------------------------------*/
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        /*------------------------------------------------------------------*/
    }
}
