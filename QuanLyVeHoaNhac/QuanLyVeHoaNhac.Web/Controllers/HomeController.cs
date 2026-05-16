using Microsoft.AspNetCore.Mvc;
using QuanLyVeHoaNhac.Models;
using System.Diagnostics;

namespace QuanLyVeHoaNhac.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var danhSachSuKien = new List<HoaNhac>()
            {
                new HoaNhac { MaHoaNhac = 1, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "15.6.2026", DiaDiem = "TP. HỒ CHÍ MINH", GiaVeTu = 2500000, TheTag = "NỔI BẬT", HinhAnhUrl = "/images/event1.jpg" },
                new HoaNhac { MaHoaNhac = 2, TenHoaNhac = "LOW G", NgheSi = "Low G", ThoiGian = "07.07.2026", DiaDiem = "ĐÀ NẴNG", GiaVeTu = 600000, TheTag = "", HinhAnhUrl = "/images/event2.jpg" },
                new HoaNhac { MaHoaNhac = 3, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "05.07.2026", DiaDiem = "HÀ NỘI", GiaVeTu = 550000, TheTag = "", HinhAnhUrl = "/images/event3.jpg" },
                new HoaNhac { MaHoaNhac = 4, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "12.05.2026", DiaDiem = "TP. HỒ CHÍ MINH", GiaVeTu = 750000, TheTag = "SẮP HẾT VÉ", HinhAnhUrl = "/images/event4.jpg" }
            };
            return View(danhSachSuKien);
        }
        // Hàm 1: Mở giao diện Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Hàm 2: Bắt sự kiện khi bấm nút ĐĂNG NHẬP
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // HANDCODE DỮ LIỆU: Tạo một tài khoản giả để test
            if (email == "user@gmail.com" && password == "123456")
            {
                // Đăng nhập đúng -> Chuyển hướng về trang chủ
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Đăng nhập sai -> Báo lỗi và giữ nguyên ở trang Login
                ViewBag.ErrorMessage = "Email hoặc mật khẩu không chính xác!";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
