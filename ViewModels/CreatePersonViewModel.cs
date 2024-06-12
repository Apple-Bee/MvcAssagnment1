using System.ComponentModel.DataAnnotations;

namespace MvcAssagnment1.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Full Name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City of Residence")]
        public string? City { get; set; }
    }
}
