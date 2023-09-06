using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tran1.Models;
using tran1.Services;
using tran1.ViewModel;

namespace tran1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeservice;
        private readonly IDepartmentRepository _departmentservice;
        public EmployeeController(IEmployeeRepository employeeservice, IDepartmentRepository departmentservice)
        {
            _employeeservice = employeeservice;
            _departmentservice = departmentservice;
        }
        public IActionResult Index()
        {
            return View(_employeeservice.GetEmployees().ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Dept = _departmentservice.GetDepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            ViewBag.Dept = _departmentservice.GetDepartments();
            _employeeservice.Create(employee.formFile, employee);
            return RedirectToAction(nameof(Index));
           
        }
        public IActionResult Details(int Id)
        {
            var employee=_employeeservice.GetEmployeeId(Id);
            return View(employee);
        }
        public IActionResult Edit(int Id)
        {
            ViewBag.Dept = _departmentservice.GetDepartments();
            return View(_employeeservice.GetEmployeeId(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employee)
        {

            _employeeservice.update(employee);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            return View(_employeeservice.GetEmployeeId(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeservice.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
