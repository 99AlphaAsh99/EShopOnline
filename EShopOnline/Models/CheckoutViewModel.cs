using System.ComponentModel.DataAnnotations;

namespace EShopOnline.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
