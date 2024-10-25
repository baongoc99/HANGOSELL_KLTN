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

        [Required(ErrorMessage = "Tiêu $ề không $ược $ể trống.")]
        [StringLength(200, ErrorMessage = "Tiêu $ề không $ược vượt quá 200 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không $ược $ể trống.")]
        [StringLength(50, ErrorMessage = "Mã sản phẩm không $ược vượt quá 50 ký tự.")]
        public string ProductCode { get; set; }
        public int ProductCategoryId { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
