using System.ComponentModel.DataAnnotations;

namespace CarBuyer.Core.Models
{
    public class DeliveryDetails
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "This doesn't look like a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your first address line")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(100)]
        public string AddressCity { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
        [StringLength(100)]
        public string AddressState { get; set; }
    }
}
