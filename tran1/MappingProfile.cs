using AutoMapper;
using tran1.Models;
using tran1.ViewModel;

namespace tran1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();
            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => new Department
                {
                    Id = src.DepartmentId,
                    Name = src.Departments.Name
                }));
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => new DepartmentViewModel
                {
                    Id = src.Departments.Id,
                    Name = src.Departments.Name
                }));
        }
    }
}




