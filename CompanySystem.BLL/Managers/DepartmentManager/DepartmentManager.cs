using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class DepartmentManager : IDepartmentManager
    {
        /*------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        /*------------------------------------------------------------------*/
        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------*/
        public List<DepartmentReadVM> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return departments.Select(d => new DepartmentReadVM
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();    
        }
        /*------------------------------------------------------------------*/
        public DepartmentReadVM? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }

            var departmentVM =  new DepartmentReadVM
            {
                Id = department.Id,
                Name = department.Name,
            };
            return departmentVM;
        }
        /*------------------------------------------------------------------*/
        public void CreateDepartment(DepartmentCreateVM departmentCreateVM)
        {
            var department = new Department
            {
                Name = departmentCreateVM.Name,
            };
            _unitOfWork.DepartmentRepository.Insert(department);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
        public void UpdateDepartment(DepartmentEditVM departmentEditVM)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(departmentEditVM.Id);
            if (department == null)
            {
                return;
            }

            department.Name = departmentEditVM.Name;
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
        public void DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return;
            }
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Save();
        }
        /*------------------------------------------------------------------*/
    }
}
