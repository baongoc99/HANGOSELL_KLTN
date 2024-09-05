using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống.")]
        [StringLength(200, ErrorMessage = "Tiêu đề không được vượt quá 200 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
        [StringLength(50, ErrorMessage = "Mã sản phẩm không được vượt quá 50 ký tự.")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống.")]
        public int ProductCategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [StringLength(2000, ErrorMessage = "Chi tiết không được vượt quá 2000 ký tự.")]
        public string? Detail { get; set; }

        [StringLength(250, ErrorMessage = "Hình ảnh không được vượt quá 250 ký tự.")]
        public string? Image { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá không được âm.")]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá giảm không được âm.")]
        public decimal? PriceSale { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số lượng không được âm.")]
        public int Quantity { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
