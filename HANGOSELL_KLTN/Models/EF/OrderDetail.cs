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

        [Required(ErrorMessage = "Mã đơn hàng không được để trống.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Giá không được để trống.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống.")]
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
