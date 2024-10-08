using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.DTO
{
    public class CartItem
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public Decimal productPrice { get; set; }
        public string anhsp { get; set; }
        //public int CustomerId { get; set; }

        //[ForeignKey("CustomerId")]
    }
}
