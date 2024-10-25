using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_News")]
    public class News : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu $ề không $ược $ể trống.")]
        [StringLength(200, ErrorMessage = "Tiêu $ề không $ược vượt quá 200 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mã danh mục không $ược $ể trống.")]
        public int CategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không $ược vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [StringLength(2000, ErrorMessage = "Chi tiết không $ược vượt quá 2000 ký tự.")]
        public string? Detail { get; set; }

        [StringLength(250, ErrorMessage = "Hình ảnh không $ược vượt quá 250 ký tự.")]
        public string? Image { get; set; }

        [StringLength(150, ErrorMessage = "Tiêu $ề SEO không $ược vượt quá 150 ký tự.")]
        public string? SeoTitle { get; set; }

        [StringLength(150, ErrorMessage = "Từ khóa SEO không $ược vượt quá 150 ký tự.")]
        public string? SeoKeyword { get; set; }

        [StringLength(250, ErrorMessage = "Mô tả SEO không $ược vượt quá 250 ký tự.")]
        public string? SeoDescription { get; set; }
        
    }
}
