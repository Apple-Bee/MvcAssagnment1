using System.ComponentModel.DataAnnotations;

namespace MvcAssagnment1.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string? Name { get; set; }

        [Display(Name = "City of Residence")]
        public string? City { get; set; }
    }
}


