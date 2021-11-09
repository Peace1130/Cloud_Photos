using System.ComponentModel.DataAnnotations;

namespace Cloud_proj.ModelClass
{
    public class RegisterClass
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(userPassword), ErrorMessage = "The passwords do not match. Please try again")]
        public string confirmPass { get; set; }
    }
}
