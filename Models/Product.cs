using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KrishiBazaarProject.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public string? FarmerID { get; set; }
        [ForeignKey("FarmerID")]
        public Users User { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public decimal PricePerUnit { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        public string Photos { get; set; }
        public DateTime UploadDate { get; set; }
        public ICollection<RatingAndReview> Reviews { get; set; } = new List<RatingAndReview>();
        public ICollection<Orders> Orders { get; set; }
    }

}
