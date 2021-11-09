using System.ComponentModel.DataAnnotations;

namespace Cloud_proj.ModelClass
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string userEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        public bool rememberMe { get; set; }

    }
}
