namespace QuanLyVeHoaNhac.Models
{
    public enum TrangThaiVe
    {
        ConTrong = 0,   // Vé chưa có ai đặt
        DangGiuCho = 1, // Khách đang giữ chỗ chờ thanh toán trong 15 phút
        DaThanhToan = 2,// Đã thanh toán thành công
        DaHuy = 3       // Quá thời gian giữ chỗ hoặc khách hủy đơn
    }
}