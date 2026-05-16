using QuanLyVeHoaNhac.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVeHoaNhac.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public int MaNguoiDung { get; set; }

        public int? MaKhuyenMai { get; set; } // Cho phép null nếu không có khuyến mãi

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue)]
        public decimal TongTien { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ThanhTien { get; set; }

        public string PhuongThucThanhToan { get; set; }

        public bool TrangThaiThanhToan { get; set; }

        // Navigation properties
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}