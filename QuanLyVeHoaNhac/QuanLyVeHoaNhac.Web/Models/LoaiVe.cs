namespace QuanLyVeHoaNhac.Models
{
    public class LoaiVe
    {
        // 5 Thuộc tính bắt buộc khớp 100% cơ sở dữ liệu ERD
        public int MaLoaiVe { get; set; }
        public int MaHoaNhac { get; set; }
        public string TenLoaiVe { get; set; }
        public decimal GiaVe { get; set; }
        public int TongSoLuong { get; set; }

        // Các thuộc tính mở rộng để binding lên giao diện thiết kế
        public string MoTaChiTiet { get; set; }
        public int SoLuongConLai { get; set; }
        public string TagHang { get; set; } // Ví dụ: "PREMIUM"
    }
}