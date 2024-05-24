using System.ComponentModel.DataAnnotations;

namespace GaribExam.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [Required,MinLength(3)]
        public string Name { get; set; }


        [Required, MinLength(5)]
        public string SurName { get; set; }


        [Required, DataType(DataType.EmailAddress)]
        public string Email {get; set;}


        [Required, MaxLength(12)]
        public string Username {get; set;}

        [Required, DataType(DataType.Password)]

        public string Password {get; set;}


        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
