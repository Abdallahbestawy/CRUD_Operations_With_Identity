using tran1.Models;
using tran1.ViewModel;

namespace tran1.Services
{
    public interface IDepartmentRepository
    {
        List<DepartmentViewModel> GetDepartments();
        int Create(DepartmentViewModel department);
        DepartmentViewModel GetDepartmentById(int Id);
        int Update(DepartmentViewModel department);
        int Delete(int DeptId);
    }
}
