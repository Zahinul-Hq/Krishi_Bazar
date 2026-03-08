using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KrishiBazaarProject.Models
{
    public class Admins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminID { get; set; }
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
