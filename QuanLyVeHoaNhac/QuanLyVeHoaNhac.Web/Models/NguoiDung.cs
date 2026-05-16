using QuanLyVeHoaNhac.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVeHoaNhac.Models
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }

        public int MaVaiTro { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhauMaHoa { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string SoDienThoai { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public bool TrangThaiHoatDong { get; set; }

        // Navigation properties
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}