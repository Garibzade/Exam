using System.ComponentModel.DataAnnotations;

namespace GaribExam.ViewModels.EmployeeVM
{
    public class UpdateEmployeeVM
    {
       
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(24)]

        public string Position { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Gmail { get; set; }
    }
}
