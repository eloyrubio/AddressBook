using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UBSWebApplication.Core.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter the first name.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter the last name.")]
        public string LastName { get; set; }

        [DisplayName("Street")]
        [Required(ErrorMessage = "Please enter the street.")]
        public string Street { get; set; }

        [DisplayName("Zip")]
        [Required(ErrorMessage = "Please enter the zip code.")]
        public string Zip { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Please enter the country.")]
        public string Country { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "Please enter the city.")]
        public string City { get; set; }

        public string Image { get; set; }
    }
}