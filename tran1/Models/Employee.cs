using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tran1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(250)]
       public string FirstName { get; set; }
        [Required, MaxLength(250)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(2500)]
        public string? EmployeePicture { get; set; }
        [Required, MaxLength(14)]
        [RegularExpression(@"^\d+$", ErrorMessage = "must be numeric")]
        [Display(Name = "National ID")]
        public string NationalID { get; set; }
        [Required, MaxLength(11)]
        [Display(Name = "Phone Number")]

        public string Mobile { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
