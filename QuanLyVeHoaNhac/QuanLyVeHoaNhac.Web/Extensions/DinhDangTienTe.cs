using System.Globalization;

namespace QuanLyVeHoaNhac.Extensions
{
    public static class DinhDangTienTe
    {
        
        public static string ToVnd(this decimal giaVe)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return giaVe.ToString("#,### đ", cul.NumberFormat);
        }

        public static string ToVnd(this double giaVe)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return giaVe.ToString("#,### đ", cul.NumberFormat);
        }
    }
}