using QuanLyVeHoaNhac.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVeHoaNhac.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int MaHoaDon { get; set; }

        public int MaLoaiVe { get; set; }

        [Required(ErrorMessage = "Số lượng mua không được để trống")]
        [Range(1, 100, ErrorMessage = "Số lượng vé mua trong một lần phải từ 1 đến 100 vé")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá không được là số âm")]
        public decimal DonGia { get; set; }

        // Navigation properties (Các thuộc tính điều hướng liên kết)
        public virtual HoaDon HoaDon { get; set; }
        public virtual LoaiVe LoaiVe { get; set; }

        // 1 ChiTietHoaDon sẽ sinh ra Nhiều Vé có mã QR khác nhau
        public virtual ICollection<Ve> Ves { get; set; }
    }
}