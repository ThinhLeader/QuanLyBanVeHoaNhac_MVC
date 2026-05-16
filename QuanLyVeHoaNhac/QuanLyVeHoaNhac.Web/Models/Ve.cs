using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVeHoaNhac.Models
{
    [Table("Ve")]
    public class Ve
    {
        [Key]
        public int MaVe { get; set; }

        public int MaChiTiet { get; set; }

        [Required]
        [StringLength(20)]
        public string MaGhe { get; set; }

        [Required]
        public string MaQR { get; set; }

        public bool TrangThaiCheckin { get; set; }

        // Navigation properties
        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }
    }
}