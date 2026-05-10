using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class EmployeeCreateVM
    {
        /*------------------------------------------------------------------*/
        #region Get From Form
        [MinLength(3)]
        [MaxLength(20)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [Range(20, 50)]
        public int Age { get; set; }

        [Required]
        [Range(1000, 5000)]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        #endregion
        /*------------------------------------------------------------------*/
        #region Send To Form
        public List<DepartmentReadVM>? Departments { get; set; }
        #endregion
        /*------------------------------------------------------------------*/
    }
}
