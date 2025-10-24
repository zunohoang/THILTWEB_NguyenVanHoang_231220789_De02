using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace NguyenVanHoang_231220789_De02.Models
{
    [Table("NvhCatalog")]
    public class NvhCatalog
    {
        [Key] 
        public int nvhId { get; set; }

        [Required]
        [MaxLength(100)]
        public string nvhCateName { get; set; }

        [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng 100 đến 5000")]
        public int nvhCatePrice { get; set; }

        public int nvhCateQty { get; set; }

        [RegularExpression(@".+\.(jpg|jpeg|png|gif|tiff)$",
            ErrorMessage = "Tên file phải có đuôi .jpg, .jpeg, .png, .gif, .tiff")]
        public string? nvhPicture { get; set; }

        public bool nvhCateActive { get; set; }

        [NotMapped]
        public IFormFile? UploadImage { get; set; }
    }
}
