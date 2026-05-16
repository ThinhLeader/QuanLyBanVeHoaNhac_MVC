using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Thêm thư mục này để dùng Session
using QuanLyVeHoaNhac.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeHoaNhac.Controllers
{
    [Route("AdminHoaNhac")]
    public class AdminHoaNhacController : Controller
    {
        private static List<HoaNhac> danhSachHoaNhac = new List<HoaNhac>()
        {
            new HoaNhac { Id = "HN01", TenHoaNhac = "NOCTURNAL RHYTHMS 2026", DiaDiem = "Sân Vận Động Mỹ Đình", ThoiGian = new DateTime(2026, 12, 20, 19, 0, 0) },
            new HoaNhac { Id = "HN02", TenHoaNhac = "ĐÊM NHẠC ACOUSTIC LÃ TRƯỜNG", DiaDiem = "Nhà Hát Lớn Đà Nẵng", ThoiGian = DateTime.Now.AddDays(7) }
        };

        // Hàm kiểm tra xem Admin đã đăng nhập chưa
        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("AdminStatus") == "LoggedIn";
        }

        // 1. Trang danh sách (Index) - Đã sửa từ string về IActionResult chuẩn để hiện bảng
        [Route("")]
        public IActionResult Index()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login"); // Chưa đăng nhập thì đá về trang Login
            }
            return View(danhSachHoaNhac);
        }

        // 2. Giao diện Đăng nhập dành riêng cho Admin
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            if (IsAdminLoggedIn()) return Redirect("/AdminHoaNhac");
            return View();
        }

        // 3. Xử lý logic khi Admin bấm nút ĐĂNG NHẬP
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Tài khoản Admin hardcode của Tiến
            if (email == "admin@gmail.com" && password == "123456")
            {
                HttpContext.Session.SetString("AdminStatus", "LoggedIn"); // Cấp quyền Session
                return Redirect("/AdminHoaNhac"); // Đăng nhập xong đá sang trang bảng danh sách
            }

            ViewBag.Error = "Tài khoản hoặc mật khẩu Admin không chính xác!";
            return View();
        }

        // 4. Trang mở Form thêm mới Đêm nhạc
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login");
            return View();
        }

        // 5. Xử lý Lưu dữ liệu khi điền Form xong
        [Route("Create")]
        [HttpPost]
        public IActionResult Create(HoaNhac hoaNhac)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login");

            if (hoaNhac != null)
            {
                danhSachHoaNhac.Add(hoaNhac);
            }
            return Redirect("/AdminHoaNhac"); // Lưu xong quay về bảng danh sách bằng Redirect cứng
        }

        // 6. Xử lý Xóa dữ liệu
        [Route("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction("Login");

            var item = danhSachHoaNhac.FirstOrDefault(h => h.Id == id);
            if (item != null)
            {
                danhSachHoaNhac.Remove(item);
            }
            return Redirect("/AdminHoaNhac");
        }
    }
}