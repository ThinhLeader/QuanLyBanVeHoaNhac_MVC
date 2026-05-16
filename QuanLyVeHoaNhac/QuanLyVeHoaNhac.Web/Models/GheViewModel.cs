namespace QuanLyVeHoaNhac.Models
{
    public class GheViewModel
    {
        public string MaGhe { get; set; } // Ví dụ: A12
        public string HangGhe { get; set; } // A, B, C
        public string SoGhe { get; set; } // 01, 02...
        public int TrangThai { get; set; } // 0: Còn trống, 1: Đã đặt, 2: Đang chọn
        public decimal GiaVe { get; set; }
    }
}