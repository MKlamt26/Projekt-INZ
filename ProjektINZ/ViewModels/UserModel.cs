using System.ComponentModel.DataAnnotations;

namespace ProjektINZ.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Neme is required.")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
