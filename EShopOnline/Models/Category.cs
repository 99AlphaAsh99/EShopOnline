using System.ComponentModel.DataAnnotations;

namespace EShopOnline.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}

