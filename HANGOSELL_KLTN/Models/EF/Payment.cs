using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Payment")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã $ơn hàng không $ược $ể trống.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Mã nhân viên bán hàng không $ược $ể trống.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Ngày thanh toán không $ược $ể trống.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Số tiền không $ược $ể trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Số tiền phải là số dương.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán không $ược $ể trống.")]
        [StringLength(50, ErrorMessage = "Phương thức thanh toán không $ược vượt quá 50 ký tự.")]
        public string PaymentMethod { get; set; }

        [StringLength(250, ErrorMessage = "Ghi chú không $ược vượt quá 250 ký tự.")]
        public string? Notes { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
