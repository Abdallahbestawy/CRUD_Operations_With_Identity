using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tran1.Models;
using tran1.Services;
using tran1.ViewModel;

namespace tran1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _deptService;
        public DepartmentController(IDepartmentRepository deptService)
        {
            _deptService = deptService;       
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_deptService.GetDepartments().ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel department)
        {
            _deptService.Create(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            return View(_deptService.GetDepartmentById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel department)
        {
            _deptService.Update(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            return View(_deptService.GetDepartmentById(id));
        }
        public IActionResult Delete(int Id)
        {
            return View(_deptService.GetDepartmentById(Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDepatment(int id)
        {
            _deptService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
