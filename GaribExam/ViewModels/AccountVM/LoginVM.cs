
using System.ComponentModel.DataAnnotations;

namespace GaribExam.ViewModels.AccountVM
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
