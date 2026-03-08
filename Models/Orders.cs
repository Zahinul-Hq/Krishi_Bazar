using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KrishiBazaarProject.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        public int? ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public String? BuyerID { get; set; }
        [ForeignKey("BuyerID")]
        public Users User { get; set; }

        [Required]
        public int QuantityToBuy { get; set; }
        public int TotalPrice { get; set; }

        public bool IsPaid { get; set; }
        public bool IsDelivered { get; set; }

        public bool IsReviewed { get; set; }

        public DateTime OrderDate { get; set; }

        public Delivery Delivery { get; set; }
        public Transactions Transaction { get; set; }




    }

}
