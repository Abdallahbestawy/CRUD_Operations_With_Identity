
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using tran1.Models;

namespace tran1.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string FirstName { get; set; }
        [Required, StringLength(250)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(2500)]
        public string? EmployeePicture { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID Must Be 14 Numbers")]
        [RegularExpression(@"^\d+$", ErrorMessage = "must be numeric")]
        [Required(ErrorMessage = "Please Enter Your National Id")]
        [Display(Name = "National ID")]
        public string NationalID { get; set; }
       [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number Must Be 11 Numbers")]
        [RegularExpression(@"^\d+$", ErrorMessage = "must be numeric")]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [Display(Name = "Phone Number")]
        public string Mobile { get; set; }
        [NotMapped]
        [Display(Name = "EmployeePicture")]
        public IFormFile? formFile { get; set; }
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department")]
        public Department Departments { get; set; }
    }
}
