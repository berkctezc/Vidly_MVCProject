using System.ComponentModel.DataAnnotations;

namespace Vidly_MVCProject.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}