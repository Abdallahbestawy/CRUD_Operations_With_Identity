using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tran1.Models;

namespace tran1.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(500)]
        public string Name { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
