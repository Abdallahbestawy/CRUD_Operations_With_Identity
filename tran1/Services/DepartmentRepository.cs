using AutoMapper;
using tran1.Models;
using tran1.ViewModel;

namespace tran1.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Department> _genericservice;
        public DepartmentRepository(IMapper mapper, IGenericRepository<Department> genericservice)
        {
            _mapper = mapper;
            _genericservice = genericservice;
        }
        public List<DepartmentViewModel> GetDepartments()
        {
            var depts = _genericservice.GetAll();
            return _mapper.Map<List<DepartmentViewModel>>(depts);
        }
        public DepartmentViewModel GetDepartmentById(int Id)
        {
            var dept= _genericservice.GetById(Id);
            return _mapper.Map<DepartmentViewModel>(dept);
        }
        public int Create(DepartmentViewModel department)
        {
            var dept=_mapper.Map<Department>(department);
            _genericservice.Create(dept);
            _genericservice.SaveChange();
            //int raw = _context.SaveChanges();
            return dept.Id;
        }

        public int Delete(int Id)
        {
            var dept=_genericservice.GetById(Id);
            _genericservice.Delete(dept);
            _genericservice.SaveChange();
            //int raw = _context.SaveChanges();
            return 1;
        }

        public int Update(DepartmentViewModel department)
        {
            //var olddept = _context.Departments.Where(_d => _d.Id == DeptId).FirstOrDefault();
            //olddept.Name = department.Name;
           var dept= _mapper.Map<Department>(department);
            _genericservice.Update(dept);
            _genericservice.SaveChange();
            //int raw = _context.SaveChanges();
            return department.Id;
        }
    }
}
