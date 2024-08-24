using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Order")]
    public class Order : CommonAbtract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã đơn hàng không được để trống.")]
        [StringLength(50, ErrorMessage = "Mã đơn hàng không được vượt quá 50 ký tự.")]
        public string Code { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Tổng số tiền không được để trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là số dương.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số dương.")]
        public int Quantity { get; set; }

        public string Status { get; set; } /// chờ xác nhận, chờ lấy hàng chờ giao hàng, đã giao, đã huỷ, trả hàng

        public DateTime? StartDatetime { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
