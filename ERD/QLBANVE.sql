CREATE DATABASE QuanLyBanVeHoaNhacDB;
GO
USE QuanLyBanVeHoaNhacDB;
GO

-- ==========================================
-- 1. NHÓM PHÂN QUYỀN & NGƯỜI DÙNG
-- ==========================================

CREATE TABLE VaiTro (
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE -- QuanTriVien, KhachHang, NhanVien
);

CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    MaVaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(MaVaiTro),
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauMaHoa VARCHAR(255) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(20),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThaiHoatDong BIT DEFAULT 1
);

-- ==========================================
-- 2. NHÓM SỰ KIỆN & HÒA NHẠC
-- ==========================================

CREATE TABLE DiaDiem (
    MaDiaDiem INT IDENTITY(1,1) PRIMARY KEY,
    TenDiaDiem NVARCHAR(200) NOT NULL,
    DiaChi NVARCHAR(500) NOT NULL,
    SucChua INT NOT NULL -- Số lượng người tối đa
);

CREATE TABLE NgheSi (
    MaNgheSi INT IDENTITY(1,1) PRIMARY KEY,
    NghiepDanh NVARCHAR(100) NOT NULL,
    TieuSu NVARCHAR(MAX)
);

CREATE TABLE HoaNhac (
    MaHoaNhac INT IDENTITY(1,1) PRIMARY KEY,
    MaDiaDiem INT NOT NULL FOREIGN KEY REFERENCES DiaDiem(MaDiaDiem),
    TenHoaNhac NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    ThoiGianBatDau DATETIME NOT NULL,
    ThoiGianKetThuc DATETIME NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT 'SapDienRa' -- SapDienRa, DangDienRa, DaKetThuc, DaHuy
);

-- Bảng trung gian để 1 buổi hòa nhạc có thể có nhiều ca sĩ và ngược lại
CREATE TABLE HoaNhac_NgheSi (
    MaHoaNhac INT NOT NULL FOREIGN KEY REFERENCES HoaNhac(MaHoaNhac),
    MaNgheSi INT NOT NULL FOREIGN KEY REFERENCES NgheSi(MaNgheSi),
    PRIMARY KEY (MaHoaNhac, MaNgheSi)
);

-- ==========================================
-- 3. NHÓM VÉ & KHUYẾN MÃI
-- ==========================================

-- Quản lý các hạng vé của mỗi buổi hòa nhạc
CREATE TABLE LoaiVe (
    MaLoaiVe INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaNhac INT NOT NULL FOREIGN KEY REFERENCES HoaNhac(MaHoaNhac),
    TenLoaiVe NVARCHAR(50) NOT NULL,
    GiaVe DECIMAL(18, 2) NOT NULL CHECK (GiaVe >= 0),
    TongSoLuong INT NOT NULL CHECK (TongSoLuong > 0)
);

-- Quản lý các chương trình giảm giá
CREATE TABLE KhuyenMai (
    MaKhuyenMai INT IDENTITY(1,1) PRIMARY KEY,
    MaGiamGia VARCHAR(50) NOT NULL UNIQUE,
    PhanTramGiam FLOAT CHECK (PhanTramGiam > 0 AND PhanTramGiam <= 100),
    GiamToiDa DECIMAL(18,2),
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    GioiHanSuDung INT -- Số lần tối đa mã này được nhập
);

-- ==========================================
-- 4. NHÓM GIAO DỊCH & HÓA ĐƠN
-- ==========================================

CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    MaKhuyenMai INT NULL FOREIGN KEY REFERENCES KhuyenMai(MaKhuyenMai), -- Có thể NULL nếu không xài mã
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 2) NOT NULL, -- Tổng tiền gốc chưa giảm
    ThanhTien DECIMAL(18, 2) NOT NULL, -- Số tiền thực tế khách phải chuyển
    PhuongThucThanhToan NVARCHAR(50), -- ChuyenKhoan, VNPay
    TrangThaiThanhToan NVARCHAR(50) DEFAULT 'ChoThanhToan' -- ChoThanhToan, DaThanhToan, ThatBai
);

-- Mỗi dòng trong hóa đơn tương ứng với số lượng mua của một loại vé
CREATE TABLE ChiTietHoaDon (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaLoaiVe INT NOT NULL FOREIGN KEY REFERENCES LoaiVe(MaLoaiVe),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18, 2) NOT NULL
);

-- Bảng vé vật lý/điện tử cụ thể sinh ra cho người dùng sau khi thanh toán xong
CREATE TABLE Ve (
    MaVe INT IDENTITY(1,1) PRIMARY KEY,
    MaChiTiet INT NOT NULL FOREIGN KEY REFERENCES ChiTietHoaDon(MaChiTiet),
    MaGhe VARCHAR(20) NULL, -- Ví dụ: A1, B12. Nếu vé đứng có thể để NULL
    MaQR VARCHAR(255) UNIQUE NOT NULL, -- Chuỗi ký tự ngẫu nhiên tạo mã QR check-in
    TrangThaiCheckIn BIT DEFAULT 0 -- 0: Chưa soát vé, 1: Đã vào cổng
);
GO