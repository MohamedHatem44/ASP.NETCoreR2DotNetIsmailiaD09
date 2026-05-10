namespace CompanySystem.BLL
{
    public class EmployeeEditVM
    {
        /*------------------------------------------------------------------*/
        #region Get From Form
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        #endregion
        /*------------------------------------------------------------------*/
        #region Send To Form
        //public List<SelectListItem>? Departments { get; set; }
        #endregion
        /*------------------------------------------------------------------*/
    }
}
