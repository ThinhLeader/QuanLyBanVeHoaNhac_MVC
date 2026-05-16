namespace QuanLyVeHoaNhac.Models
{
    public class HoaNhac
    {
        // Khóa chính
        public int MaHoaNhac { get; set; }

        // Thông tin sự kiện
        public string TenHoaNhac { get; set; } // Ví dụ: SON TUNG MTP
        public string NgheSi { get; set; }     // Ví dụ: Sơn Tùng M-TP
        public string DiaDiem { get; set; }    // Ví dụ: TP. HỒ CHÍ MINH
        public string ThoiGian { get; set; }   // Ví dụ: 15.6.2026
        public decimal GiaVeTu { get; set; }   // Ví dụ: 2500000

        // Thông tin phục vụ UI
        public string HinhAnhUrl { get; set; } // Đường dẫn ảnh (ví dụ: sontung.png)
        public string TheTag { get; set; }     // Thẻ tag (ví dụ: NỔI BẬT, SẮP HẾT VÉ)
    }
}