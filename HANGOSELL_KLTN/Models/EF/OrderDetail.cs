using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã $ơn hàng không $ược $ể trống.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không $ược $ể trống.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Giá không $ược $ể trống.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Số lượng không $ược $ể trống.")]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartDattetime { get; set; } // ngày $awntj hàng

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
