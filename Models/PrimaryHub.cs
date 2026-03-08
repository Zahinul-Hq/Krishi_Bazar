using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KrishiBazaarProject.Models
{
    public class PrimaryHub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryHubID { get; set; }

        public int? LocationID { get; set; }
        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<SecondaryHub> SecondaryHubs { get; set; } = new List<SecondaryHub>();
    }
}
