using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tran1.Models;
using tran1.ViewModel;

namespace tran1.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IGenericRepository<Employee> _genericservice;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _department;
        public EmployeeRepository(IMapper mapper, IGenericRepository<Employee> genericservice,IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _genericservice = genericservice;
            _department = departmentRepository;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            List<Employee> employees = _genericservice.GetAll().ToList();
            foreach (var item in employees)
            {
                var dept = _department.GetDepartmentById(item.DepartmentId);
                var departmen = _mapper.Map<Department>(dept);
                item.Departments = departmen;
            }
            var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);

            return employeeViewModels;
        }





        public EmployeeViewModel GetEmployeeId(int Id)
        {
             Employee employee = _genericservice.GetById(Id);
            var dept = _department.GetDepartmentById(employee.DepartmentId);
            var departmen = _mapper.Map<Department>(dept);
            employee.Departments = departmen;
            var emp=_mapper.Map<EmployeeViewModel>(employee);
            return emp;
        }
        public int Create(IFormFile formFile, EmployeeViewModel employee)
        {
            if (formFile != null && formFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(employee.formFile.FileName);
                string relativePath = Path.Combine("EmployeeImage", fileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                employee.EmployeePicture = relativePath;
                var emp=_mapper.Map<Employee>(employee);
                //_context.Employees.Add(emp);
                //int raw = _context.SaveChanges();
                _genericservice.Create(emp);
                _genericservice.SaveChange();
                return employee.Id;
            }
            return -1;
        }

        public int Delete(int Id)
        {
            var employee = _genericservice.GetById(Id);
            _genericservice.Delete(employee);
            _genericservice.SaveChange();
            //_context.Employees.Remove(employee);
            //int raw = _context.SaveChanges();
            return 1;
        }

    

        public int update(EmployeeViewModel employee)
        {
            //var oldemployee = _context.Employees.Where(_d => _d.Id == Id).FirstOrDefault();
            //oldemployee.Email=employee.Email;   
            //oldemployee.FirstName=employee.FirstName;
            //oldemployee.LastName=employee.LastName;
            //oldemployee.DepartmentId=employee.DepartmentId;
           
            var emp=_mapper.Map<Employee>(employee);
            //employee.EmployeePicture = emp.EmployeePicture;
            _genericservice.Update(emp);
            _genericservice.SaveChange();
            //int raw = _context.SaveChanges();
            return employee.Id;
        }
    }
}
