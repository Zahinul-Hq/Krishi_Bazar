using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KrishiBazaar.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OrderDetailsID { get; set; }

        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Orders Order { get; set; }

        public string BuyerID { get; set; }
        [ForeignKey("BuyerID")]
        public Users Buyer { get; set; }


    }
}
