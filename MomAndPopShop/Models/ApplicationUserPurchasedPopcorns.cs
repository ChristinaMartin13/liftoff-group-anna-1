using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MomAndPopShop.Models
{
    public class ApplicationUserPurchasedPopcorns
    {
        [Key]
        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Popcorn")]

        public int PopcornId { get; set; }
        public Popcorn PurchasedPopcorn { get; set; }
    }
}
