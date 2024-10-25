using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_OrderDetailCustomer")]
    public class OrderDetailCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Số lượng không $ược $ể trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng không $ược âm.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Tổng giá không $ược $ể trống.")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng giá không $ược âm.")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không $ược $ể trống.")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
