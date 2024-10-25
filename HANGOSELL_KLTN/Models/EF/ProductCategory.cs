using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_ProductCategory")]
    public class ProductCategory : CommonAbtract
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu $ề không $ược $ể trống.")]
        [StringLength(200, ErrorMessage = "Tiêu $ề không $ược vượt quá 200 ký tự.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không $ược vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = "Biểu tượng không $ược vượt quá 100 ký tự.")]
        public string? Icon { get; set; }

        [StringLength(150, ErrorMessage = "Tiêu $ề SEO không $ược vượt quá 150 ký tự.")]
        public string? SeoTitle { get; set; }

        [StringLength(150, ErrorMessage = "Từ khóa SEO không $ược vượt quá 150 ký tự.")]
        public string? SeoKeyword { get; set; }

        [StringLength(250, ErrorMessage = "Mô tả SEO không $ược vượt quá 250 ký tự.")]
        public string? SeoDescription { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
