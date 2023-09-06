using tran1.Models;
using tran1.ViewModel;

namespace tran1.Services
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetEmployees();
        EmployeeViewModel GetEmployeeId(int Id);
        int Create(IFormFile formFile,EmployeeViewModel employee);
        int update(EmployeeViewModel employee);   
        int Delete(int Id);
    }
}
