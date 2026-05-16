using Microsoft.AspNetCore.Mvc;
using QuanLyVeHoaNhac.Models;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyVeHoaNhac.Controllers
{
    public class HomeController : Controller
    {
        // Hàm tạo danh sách dữ liệu - Giữ đúng data cũ và DÙNG HOA NHAC VIEW MODEL
        private List<HoaNhacViewModel> LayDanhSachSuKien()
        {
            return new List<HoaNhacViewModel>()
            {
                new HoaNhacViewModel { MaHoaNhac = 1, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "15.6.2026", DiaDiem = "TP. HỒ CHÍ MINH", GiaVeTu = 2500000, TheTag = "NỔI BẬT", HinhAnh = "/images/event1.jpg" },
                new HoaNhacViewModel { MaHoaNhac = 2, TenHoaNhac = "LOW G", NgheSi = "Low G", ThoiGian = "07.07.2026", DiaDiem = "ĐÀ NẴNG", GiaVeTu = 600000, TheTag = "", HinhAnh = "/images/event2.jpg" },
                new HoaNhacViewModel { MaHoaNhac = 3, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "05.07.2026", DiaDiem = "HÀ NỘI", GiaVeTu = 550000, TheTag = "", HinhAnh = "/images/event3.jpg" },
                new HoaNhacViewModel { MaHoaNhac = 4, TenHoaNhac = "SON TUNG MTP", NgheSi = "Sơn Tùng M-TP", ThoiGian = "12.05.2026", DiaDiem = "TP. HỒ CHÍ MINH", GiaVeTu = 750000, TheTag = "SẮP HẾT VÉ", HinhAnh = "/images/event4.jpg" }
            };
        }

        // 1. TRANG CHỦ: Truyền danh sách HoaNhacViewModel sang View
        public IActionResult Index()
        {
            var danhSachSuKien = LayDanhSachSuKien();
            return View(danhSachSuKien);
        }

        // 2. TRANG CHI TIẾT SỰ KIỆN: Chỉ lấy và truyền ĐÚNG 1 đối tượng HoaNhacViewModel dựa vào ID
        // 1. TRANG CHI TIẾT SỰ KIỆN (Layout theo ảnh ChiTietSuKien.png)
        public IActionResult ChiTietSuKien(int id)
        {
            // Giả lập bốc 1 show từ DB ra
            var suKien = new HoaNhacViewModel
            {
                MaHoaNhac = id,
                TenHoaNhac = id == 2 ? "NOCTURNAL RHYTHMS 2024" : "THE NEON PULSE CONCERT 2024",
                NgheSi = id == 2 ? "LOW G, SƠN TÙNG M-TP" : "DEN VAU, TLINH, JUSTATEE",
                DiaDiem = "Sân vận động Quốc gia Mỹ Đình, Hà Nội",
                ThoiGian = "Thứ Bảy, 25 Tháng 5, 2024 • 19:00",
                HinhAnh = id == 2 ? "/images/event2.jpg" : "/images/event1.jpg",
                GiaVeTu = 1200000
            };

            // Tạo danh sách hạng vé để show ở cột bên trái
            ViewBag.DsLoaiVe = new List<LoaiVe>()
    {
        new LoaiVe { MaLoaiVe = 1, TenLoaiVe = "VIP 1", GiaVe = 4500000, TongSoLuong = 50, SoLuongConLai = 12, TagHang = "PREMIUM", MoTaChiTiet = "Bao gồm bộ quà tặng giới hạn, khu vực đứng sát sân khấu và lối đi riêng." },
        new LoaiVe { MaLoaiVe = 2, TenLoaiVe = "VIP 2", GiaVe = 2800000, TongSoLuong = 100, SoLuongConLai = 45, TagHang = "", MoTaChiTiet = "Khu vực ngồi có mái che, đồ uống miễn phí và quầy bar riêng biệt." },
        new LoaiVe { MaLoaiVe = 3, TenLoaiVe = "VÉ THƯỜNG", GiaVe = 1200000, TongSoLuong = 500, SoLuongConLai = 150,TagHang = "", MoTaChiTiet = "Khu vực đứng tự do phía sau VIP. Trải nghiệm âm thanh vòm chất lượng." }
    };

            return View(suKien);
        }

        // 2. TRANG ĐẶT VÉ CHỌN SỐ LƯỢNG (Layout theo ảnh DatVe.png)
        public IActionResult DatVe(int id)
        {
            var suKien = new HoaNhacViewModel
            {
                MaHoaNhac = id,
                TenHoaNhac = id == 2 ? "NOCTURNAL RHYTHMS 2024" : "THE NEON PULSE CONCERT 2024",
                HinhAnh = id == 2 ? "/images/event2.jpg" : "/images/event1.jpg"
            };
            ViewBag.SuKien = suKien;

            // Danh sách vé có bộ chọn số lượng
            var dsLoaiVe = new List<LoaiVe>()
    {
        new LoaiVe { MaLoaiVe = 1, TenLoaiVe = "VIP 1", GiaVe = 5500000, TagHang = "HẠNG ĐẦU", MoTaChiTiet = "Trải nghiệm cận cảnh sân khấu nhất. Bao gồm bộ quà tặng merchandise giới hạn, lối đi VIP riêng biệt và tiệc nhẹ trước giờ diễn." },
        new LoaiVe { MaLoaiVe = 2, TenLoaiVe = "VIP 2", GiaVe = 3200000, TagHang = "TẦM NHÌN TRUNG TÂM", MoTaChiTiet = "Tầm nhìn bao quát toàn bộ hiệu ứng sân khấu từ khu vực trung tâm. Bao gồm lều giải khát riêng và khu vực vệ sinh cao cấp." },
        new LoaiVe { MaLoaiVe = 3, TenLoaiVe = "THƯỜNG", GiaVe = 1200000, TagHang = "TIÊU CHUẨN", MoTaChiTiet = "Khu vực khán đài chính với âm thanh bùng nổ. Phù hợp cho nhóm bạn cùng tận hưởng không khí lễ hội sôi động." }
    };

            return View(dsLoaiVe);
        }

        // Hàm 1: Mở giao diện Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Hàm 2: Bắt sự kiện khi bấm nút ĐĂNG NHẬP (Giữ nguyên logic cũ của ông)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "user@gmail.com" && password == "123456")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Email hoặc mật khẩu không chính xác!";
                return View();
            }
        }
        public IActionResult ChonGhe(int id, int loaiVeId)
        {
            // ĐIỀU KIỆN QUAN TRỌNG: Nếu là vé thường (ID 3) thì không cho chọn ghế, đẩy về trang kết quả
            if (loaiVeId == 3)
            {
                return RedirectToAction("ThanhToan", new { id = id });
            }
            // Lấy thông tin show để hiện ở cột phải
            var suKien = new HoaNhacViewModel
            {
                MaHoaNhac = id,
                TenHoaNhac = "NEON PULSE 2024",
                DiaDiem = "SÂN VẬN ĐỘNG QUỐC GIA",
                GiaVeTu = 2250000,
                HinhAnh = "/images/event1.jpg"
            };
            ViewBag.SuKien = suKien;

            // Tạo ma trận 14 cột ghế mẫu
            var danhSachGhe = new List<GheViewModel>();
            string[] hang = { "A", "B", "C" };
            for (int h = 0; h < hang.Length; h++)
            {
                for (int i = 1; i <= 14; i++)
                {
                    danhSachGhe.Add(new GheViewModel
                    {
                        MaGhe = hang[h] + i.ToString("D2"),
                        HangGhe = hang[h],
                        SoGhe = i.ToString("D2"),
                        TrangThai = (i == 3 || i == 4) ? 1 : 0, // Giả định ghế 03, 04 đã có người đặt
                        GiaVe = 2250000
                    });
                }
            }
            return View(danhSachGhe);
        }
        public IActionResult ThanhToan(int id)
        {
            // Bốc thông tin sự kiện ra để làm hoá đơn
            var suKien = new HoaNhacViewModel
            {
                MaHoaNhac = id,
                TenHoaNhac = "NEON PULSE 2024",
                DiaDiem = "SÂN VẬN ĐỘNG QUỐC GIA",
                GiaVeTu = 1200000, // Giá vé thường
                HinhAnh = "/images/event1.jpg"
            };
            ViewBag.SuKien = suKien;

            return View();
        }
        public IActionResult VeCuaToi()
        {
            // Giả lập dữ liệu vé vừa thanh toán xong
            var ve = new VeViewModel
            {
                MaVe = "BS-889911",
                TenHoaNhac = "NEON PULSE 2024",
                NgheSi = "SƠN TÙNG M-TP / LOW G",
                ThoiGian = "15.06.2026 • 19:00",
                DiaDiem = "SÂN VẬN ĐỘNG MỸ ĐÌNH, HÀ NỘI",
                ViTriGhe = "Hàng A, Ghế 12",
                LoaiVe = "VIP PLATINUM",
                GiaVe = 2250000,
                HinhAnh = "/images/event1.jpg"
            };
            return View(ve);
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