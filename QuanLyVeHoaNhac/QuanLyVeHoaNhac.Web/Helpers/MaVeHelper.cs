using System;

namespace QuanLyVeHoaNhac.Helpers
{
    public static class MaVeHelper
    {
        // Tự động tạo mã vé ngẫu nhiên (Ví dụ: HN01-2026-A1B2C)
        public static string TaoMaVe(string maHoaNhac)
        {
            string chuoiNgauNhien = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            string namHienTai = DateTime.Now.Year.ToString();
            return $"{maHoaNhac}-{namHienTai}-{chuoiNgauNhien}";
        }
    }
}