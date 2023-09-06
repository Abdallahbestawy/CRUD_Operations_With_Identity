using System.ComponentModel.DataAnnotations;

namespace tran1.ViewModel
{
    public class LoignViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
