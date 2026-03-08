using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrishiBazaarProject.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostalCode { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Upazila { get; set; }
        [Required]
        public string Thana { get; set; }
        [Required]
        public string RoadDetails { get; set; }

        public ICollection<Users> Users { get; set; } = new List<Users>();
        public ICollection<PrimaryHub> PrimaryHubs { get; set; } = new List<PrimaryHub>();
        public ICollection<SecondaryHub> SecondaryHubs { get; set; } = new List<SecondaryHub>();
        public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}
