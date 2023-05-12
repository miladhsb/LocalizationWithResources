using System.ComponentModel.DataAnnotations;

namespace LocalizationWithResources.Models
{
    public class PersonModel
    {
    
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}
