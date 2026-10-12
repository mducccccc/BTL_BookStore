-- =========================================================================
-- ĐỒ ÁN: LẬP TRÌNH TRỰC QUAN - ĐẠI HỌC GIAO THÔNG VẬN TẢI
-- ĐỀ TÀI: HỆ THỐNG QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN
-- DATABASE SCRIPT: QuanLyChoThueSach.sql
-- =========================================================================

CREATE DATABASE QLChoThueSach;
GO

USE QLChoThueSach;
GO

-- =========================================================================
-- 1. TẠO CÁC BẢNG DANH MỤC & ĐỐI TƯỢNG CƠ BẢN
-- =========================================================================

-- Bảng 1: Lĩnh vực
CREATE TABLE tLinhVuc (
    MaLV CHAR(4) NOT NULL,
    TenLV NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_tLinhVuc PRIMARY KEY (MaLV)
);
GO

-- Bảng 2: Loại sách
CREATE TABLE tLoaiSach (
    MaLoai CHAR(4) NOT NULL,
    TenLoai NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tLoaiSach PRIMARY KEY (MaLoai)
);
GO

-- Bảng 3: Tình trạng sách
CREATE TABLE tTinhTrang (
    MaTT CHAR(4) NOT NULL,
    TenTT NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tTinhTrang PRIMARY KEY (MaTT)
);
GO

-- Bảng 4: Ngôn ngữ
CREATE TABLE tNgonNgu (
    MaNN CHAR(2) NOT NULL,
    TenNN NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tNgonNgu PRIMARY KEY (MaNN)
);
GO

-- Bảng 5: Tác giả
CREATE TABLE tTacGia (
    MaTG CHAR(6) NOT NULL,
    TenTG NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh CHAR(1) NULL CHECK (GioiTinh IN ('M', 'F')),
    DiaChi NVARCHAR(200) NULL,
    CONSTRAINT PK_tTacGia PRIMARY KEY (MaTG)
);
GO

-- Bảng 6: Nhà xuất bản
CREATE TABLE tNXB (
    MaNXB CHAR(6) NOT NULL,
    TenNXB NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200) NULL,
    DienThoai NVARCHAR(20) NULL,
    CONSTRAINT PK_tNXB PRIMARY KEY (MaNXB)
);
GO

-- Bảng 7: Ca làm
CREATE TABLE tCaLam (
    MaCa CHAR(3) NOT NULL,
    TenCa NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_tCaLam PRIMARY KEY (MaCa)
);
GO

-- Bảng 8: Vi phạm
CREATE TABLE tViPham (
    MaVP CHAR(5) NOT NULL,
    TenVP NVARCHAR(100) NOT NULL,
    TienPhat DECIMAL(12,0) NOT NULL DEFAULT 0 CHECK (TienPhat >= 0),
    CONSTRAINT PK_tViPham PRIMARY KEY (MaVP)
);
GO

-- Bảng 9: Khách hàng
CREATE TABLE tKhachHang (
    MaKH CHAR(8) NOT NULL,
    TenKH NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh CHAR(1) NULL CHECK (GioiTinh IN ('M', 'F')),
    DiaChi NVARCHAR(200) NULL,
    CONSTRAINT PK_tKhachHang PRIMARY KEY (MaKH)
);
GO

-- Bảng 10: Nhân viên
CREATE TABLE tNhanVien (
    MaNV CHAR(7) NOT NULL,
    TenNV NVARCHAR(100) NOT NULL,
    NamSinh INT NULL,
    GioiTinh CHAR(1) NOT NULL CHECK (GioiTinh IN ('M', 'F')),
    DiaChi NVARCHAR(200) NULL,
    DienThoai NVARCHAR(20) NOT NULL,
    LuongThang DECIMAL(12,0) NULL CHECK (LuongThang >= 0),
    CONSTRAINT PK_tNhanVien PRIMARY KEY (MaNV)
);
GO

-- Bảng 11: Sách truyện
CREATE TABLE tSachTruyen (
    MaSach CHAR(8) NOT NULL,
    TenSach NVARCHAR(200) NOT NULL,
    MaLoai CHAR(4) NOT NULL,
    MaLV CHAR(4) NOT NULL,
    MaTG CHAR(6) NOT NULL,
    MaNXB CHAR(6) NOT NULL,
    MaNN CHAR(2) NOT NULL,
    SoTrang INT NULL CHECK (SoTrang > 0),
    GiaSach DECIMAL(12,0) NOT NULL CHECK (GiaSach >= 0),
    DonGiaThue DECIMAL(12,0) NOT NULL CHECK (DonGiaThue >= 0),
    MaTT CHAR(4) NOT NULL,
    SoLuong INT NOT NULL DEFAULT 0 CHECK (SoLuong >= 0),
    Anh NVARCHAR(255) NULL,
    GhiChu NVARCHAR(500) NULL,
    CONSTRAINT PK_tSachTruyen PRIMARY KEY (MaSach),
    CONSTRAINT FK_Sach_Loai FOREIGN KEY (MaLoai) REFERENCES tLoaiSach(MaLoai) ON DELETE NO ACTION,
    CONSTRAINT FK_Sach_LinhVuc FOREIGN KEY (MaLV) REFERENCES tLinhVuc(MaLV) ON DELETE NO ACTION,
    CONSTRAINT FK_Sach_TacGia FOREIGN KEY (MaTG) REFERENCES tTacGia(MaTG) ON DELETE NO ACTION,
    CONSTRAINT FK_Sach_NXB FOREIGN KEY (MaNXB) REFERENCES tNXB(MaNXB) ON DELETE NO ACTION,
    CONSTRAINT FK_Sach_NgonNgu FOREIGN KEY (MaNN) REFERENCES tNgonNgu(MaNN) ON DELETE NO ACTION,
    CONSTRAINT FK_Sach_TinhTrang FOREIGN KEY (MaTT) REFERENCES tTinhTrang(MaTT) ON DELETE NO ACTION
);
GO

-- =========================================================================
-- 2. TẠO CÁC BẢNG GIAO DỊCH (THUÊ - TRẢ SÁCH)
-- =========================================================================

-- Bảng 12: Phiếu thuê sách
CREATE TABLE tThueSach (
    MaThue CHAR(10) NOT NULL,
    MaKH CHAR(8) NOT NULL,
    MaNV CHAR(7) NOT NULL,
    MaCa CHAR(3) NOT NULL,
    NgayThue DATE NOT NULL,
    TienDatCoc DECIMAL(12,0) NOT NULL DEFAULT 0 CHECK (TienDatCoc >= 0),
    CONSTRAINT PK_tThueSach PRIMARY KEY (MaThue),
    CONSTRAINT FK_Thue_KhachHang FOREIGN KEY (MaKH) REFERENCES tKhachHang(MaKH) ON DELETE NO ACTION,
    CONSTRAINT FK_Thue_NhanVien FOREIGN KEY (MaNV) REFERENCES tNhanVien(MaNV) ON DELETE NO ACTION,
    CONSTRAINT FK_Thue_CaLam FOREIGN KEY (MaCa) REFERENCES tCaLam(MaCa) ON DELETE NO ACTION
);
GO

-- Bảng 13: Chi tiết thuê sách
CREATE TABLE tChiTietThueSach (
    MaThue CHAR(10) NOT NULL,
    MaSach CHAR(8) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DaTra BIT NOT NULL DEFAULT 0,
    CONSTRAINT PK_tChiTietThueSach PRIMARY KEY (MaThue, MaSach),
    CONSTRAINT FK_CTThue_Thue FOREIGN KEY (MaThue) REFERENCES tThueSach(MaThue) ON DELETE CASCADE,
    CONSTRAINT FK_CTThue_Sach FOREIGN KEY (MaSach) REFERENCES tSachTruyen(MaSach) ON DELETE NO ACTION
);
GO

-- Bảng 14: Phiếu trả sách
CREATE TABLE tTraSach (
    MaTra CHAR(10) NOT NULL,
    MaThue CHAR(10) NOT NULL,
    MaNV CHAR(7) NOT NULL,
    NgayTra DATE NOT NULL,
    TongTien DECIMAL(12,0) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    CONSTRAINT PK_tTraSach PRIMARY KEY (MaTra),
    CONSTRAINT FK_Tra_Thue FOREIGN KEY (MaThue) REFERENCES tThueSach(MaThue) ON DELETE NO ACTION,
    CONSTRAINT FK_Tra_NhanVien FOREIGN KEY (MaNV) REFERENCES tNhanVien(MaNV) ON DELETE NO ACTION
);
GO

-- Bảng 15: Chi tiết trả sách
CREATE TABLE tChiTietTraSach (
    MaTra CHAR(10) NOT NULL,
    MaSach CHAR(8) NOT NULL,
    MaVP CHAR(5) NULL,
    ThanhTien DECIMAL(12,0) NOT NULL CHECK (ThanhTien >= 0),
    CONSTRAINT PK_tChiTietTraSach PRIMARY KEY (MaTra, MaSach),
    CONSTRAINT FK_CTTra_Tra FOREIGN KEY (MaTra) REFERENCES tTraSach(MaTra) ON DELETE CASCADE,
    CONSTRAINT FK_CTTra_Sach FOREIGN KEY (MaSach) REFERENCES tSachTruyen(MaSach) ON DELETE NO ACTION,
    CONSTRAINT FK_CTTra_ViPham FOREIGN KEY (MaVP) REFERENCES tViPham(MaVP) ON DELETE NO ACTION
);
GO

-- =========================================================================
-- 3. CÁC TRIGGER ĐẢM BẢO TỒN KHO & TRẠNG THÁI (YÊU CẦU 2)
-- =========================================================================

-- Trigger 1: Trừ số lượng sách khi thêm vào chi tiết thuê
CREATE TRIGGER trg_ChiTietThue_Insert 
ON tChiTietThueSach
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE s
    SET s.SoLuong = s.SoLuong - x.TongThue
    FROM tSachTruyen s
    JOIN (
        SELECT MaSach, SUM(SoLuong) AS TongThue
        FROM inserted 
        GROUP BY MaSach
    ) x ON x.MaSach = s.MaSach;
END;
GO

-- Trigger 2: Hoàn lại số lượng sách nếu xóa dòng chi tiết thuê (chưa trả)
CREATE TRIGGER trg_ChiTietThue_Delete 
ON tChiTietThueSach
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE s
    SET s.SoLuong = s.SoLuong + x.TongThue
    FROM tSachTruyen s
    JOIN (
        SELECT MaSach, SUM(SoLuong) AS TongThue
        FROM deleted 
        WHERE DaTra = 0 
        GROUP BY MaSach
    ) x ON x.MaSach = s.MaSach;
END;
GO

-- Trigger 3: Cộng số lượng sách và cập nhật cờ DaTra khi ghi nhận chi tiết trả
CREATE TRIGGER trg_ChiTietTra_Insert 
ON tChiTietTraSach
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    -- Cộng tồn kho sách theo số lượng đã thuê của phiếu đó
    UPDATE s
    SET s.SoLuong = s.SoLuong + ct.SoLuong
    FROM tSachTruyen s
    JOIN inserted i ON i.MaSach = s.MaSach
    JOIN tTraSach t ON t.MaTra = i.MaTra
    JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue AND ct.MaSach = i.MaSach;

    -- Đánh dấu sách đã trả
    UPDATE ct
    SET ct.DaTra = 1
    FROM tChiTietThueSach ct
    JOIN tTraSach t ON t.MaThue = ct.MaThue
    JOIN inserted i ON i.MaTra = t.MaTra AND i.MaSach = ct.MaSach;
END;
GO

-- =========================================================================
-- 4. STORED PROCEDURES SINH MÃ TỰ ĐỘNG
-- =========================================================================

-- 4.1. Mã Sách: Syy-NNNN (VD: S25-0001)
CREATE PROCEDURE SP_GenerateNewMaSach
    @NewMaSach CHAR(8) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    DECLARE @Prefix CHAR(4) = 'S' + FORMAT(GETDATE(), 'yy') + '-';
    DECLARE @Latest CHAR(8), @Sequence INT;

    SELECT TOP 1 @Latest = MaSach
    FROM tSachTruyen WITH (UPDLOCK, HOLDLOCK)
    WHERE MaSach LIKE @Prefix + '[0-9][0-9][0-9][0-9]'
    ORDER BY MaSach DESC;

    SET @Sequence = CASE WHEN @Latest IS NULL THEN 1 
                         ELSE CAST(RIGHT(@Latest, 4) AS INT) + 1 END;

    IF @Sequence > 9999
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Đã đạt giới hạn 9999 mã sách trong năm.', 16, 1);
        RETURN;
    END

    SET @NewMaSach = @Prefix + RIGHT('000' + CAST(@Sequence AS VARCHAR(4)), 4);
    COMMIT TRANSACTION;
END;
GO

-- 4.2. Mã Phiếu Thuê: THyyMMNNNN (VD: TH25100001)
CREATE PROCEDURE SP_GenerateNewMaThue
    @NewMaThue CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    DECLARE @Prefix CHAR(6) = 'TH' + FORMAT(GETDATE(), 'yyMM');
    DECLARE @Latest CHAR(10), @Sequence INT;

    SELECT TOP 1 @Latest = MaThue
    FROM tThueSach WITH (UPDLOCK, HOLDLOCK)
    WHERE MaThue LIKE @Prefix + '[0-9][0-9][0-9][0-9]'
    ORDER BY MaThue DESC;

    SET @Sequence = CASE WHEN @Latest IS NULL THEN 1 
                         ELSE CAST(RIGHT(@Latest, 4) AS INT) + 1 END;

    IF @Sequence > 9999
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Đã đạt giới hạn 9999 phiếu thuê trong tháng.', 16, 1);
        RETURN;
    END

    SET @NewMaThue = @Prefix + RIGHT('000' + CAST(@Sequence AS VARCHAR(4)), 4);
    COMMIT TRANSACTION;
END;
GO

-- 4.3. Mã Phiếu Trả: TRyyMMNNNN (VD: TR25100001)
CREATE PROCEDURE SP_GenerateNewMaTra
    @NewMaTra CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    DECLARE @Prefix CHAR(6) = 'TR' + FORMAT(GETDATE(), 'yyMM');
    DECLARE @Latest CHAR(10), @Sequence INT;

    SELECT TOP 1 @Latest = MaTra
    FROM tTraSach WITH (UPDLOCK, HOLDLOCK)
    WHERE MaTra LIKE @Prefix + '[0-9][0-9][0-9][0-9]'
    ORDER BY MaTra DESC;

    SET @Sequence = CASE WHEN @Latest IS NULL THEN 1 
                         ELSE CAST(RIGHT(@Latest, 4) AS INT) + 1 END;

    IF @Sequence > 9999
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Đã đạt giới hạn 9999 phiếu trả trong tháng.', 16, 1);
        RETURN;
    END

    SET @NewMaTra = @Prefix + RIGHT('000' + CAST(@Sequence AS VARCHAR(4)), 4);
    COMMIT TRANSACTION;
END;
GO

-- 4.4. Mã Khách Hàng: KHyy-NNN (VD: KH25-001)
CREATE PROCEDURE SP_GenerateNewMaKH
    @NewMaKH CHAR(8) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    DECLARE @Prefix CHAR(5) = 'KH' + FORMAT(GETDATE(), 'yy') + '-';
    DECLARE @Latest CHAR(8), @Sequence INT;

    SELECT TOP 1 @Latest = MaKH
    FROM tKhachHang WITH (UPDLOCK, HOLDLOCK)
    WHERE MaKH LIKE @Prefix + '[0-9][0-9][0-9]'
    ORDER BY MaKH DESC;

    SET @Sequence = CASE WHEN @Latest IS NULL THEN 1 
                         ELSE CAST(RIGHT(@Latest, 3) AS INT) + 1 END;

    SET @NewMaKH = @Prefix + RIGHT('00' + CAST(@Sequence AS VARCHAR(3)), 3);
    COMMIT TRANSACTION;
END;
GO

-- 4.5. Mã Nhân Viên: NVyy-NN (VD: NV25-01)
CREATE PROCEDURE SP_GenerateNewMaNV
    @NewMaNV CHAR(7) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    DECLARE @Prefix CHAR(5) = 'NV' + FORMAT(GETDATE(), 'yy') + '-';
    DECLARE @Latest CHAR(7), @Sequence INT;

    SELECT TOP 1 @Latest = MaNV
    FROM tNhanVien WITH (UPDLOCK, HOLDLOCK)
    WHERE MaNV LIKE @Prefix + '[0-9][0-9]'
    ORDER BY MaNV DESC;

    SET @Sequence = CASE WHEN @Latest IS NULL THEN 1 
                         ELSE CAST(RIGHT(@Latest, 2) AS INT) + 1 END;

    SET @NewMaNV = @Prefix + RIGHT('0' + CAST(@Sequence AS VARCHAR(2)), 2);
    COMMIT TRANSACTION;
END;
GO

-- =========================================================================
-- 5. FUNCTION VÀ PROCEDURE XỬ LÝ TRẢ SÁCH (YÊU CẦU 4)
-- =========================================================================

-- Hàm tính thành tiền: Thành tiền = Đơn giá thuê x Số ngày thuê + Tiền phạt (nếu có)
CREATE FUNCTION fn_TinhThanhTien (
    @MaThue CHAR(10), 
    @MaSach CHAR(8), 
    @NgayTra DATE, 
    @MaVP CHAR(5)
)
RETURNS DECIMAL(12,0)
AS
BEGIN
    DECLARE @NgayThue DATE, @DonGia DECIMAL(12,0), @SL INT;
    DECLARE @SoNgay INT, @TienPhat DECIMAL(12,0) = 0;

    SELECT @NgayThue = t.NgayThue, @SL = ct.SoLuong, @DonGia = s.DonGiaThue
    FROM tThueSach t
    JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue
    JOIN tSachTruyen s ON s.MaSach = ct.MaSach
    WHERE t.MaThue = @MaThue AND ct.MaSach = @MaSach;

    SET @SoNgay = DATEDIFF(DAY, @NgayThue, @NgayTra);
    IF @SoNgay < 1 SET @SoNgay = 1;

    IF @MaVP IS NOT NULL
        SELECT @TienPhat = TienPhat FROM tViPham WHERE MaVP = @MaVP;

    RETURN (@DonGia * @SoNgay * @SL) + ISNULL(@TienPhat, 0);
END;
GO

-- Thủ tục thêm chi tiết trả và tự cập nhật tổng tiền phiếu trả
CREATE PROCEDURE SP_ThemChiTietTra
    @MaTra CHAR(10), 
    @MaSach CHAR(8), 
    @MaVP CHAR(5) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @MaThue CHAR(10), @NgayTra DATE;
    SELECT @MaThue = MaThue, @NgayTra = NgayTra FROM tTraSach WHERE MaTra = @MaTra;

    -- Kiểm tra sách có nằm trong phiếu và chưa trả không
    IF NOT EXISTS (
        SELECT 1 FROM tChiTietThueSach 
        WHERE MaThue = @MaThue AND MaSach = @MaSach AND DaTra = 0
    )
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Sách này không có trong phiếu thuê hoặc đã được trả trước đó.', 16, 1);
        RETURN;
    END

    -- Ghi nhận chi tiết trả
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES (
        @MaTra, 
        @MaSach, 
        @MaVP, 
        dbo.fn_TinhThanhTien(@MaThue, @MaSach, @NgayTra, @MaVP)
    );

    -- Cập nhật tổng tiền vào phiếu trả
    UPDATE tTraSach
    SET TongTien = (SELECT SUM(ThanhTien) FROM tChiTietTraSach WHERE MaTra = @MaTra)
    WHERE MaTra = @MaTra;

    COMMIT TRANSACTION;
END;
GO

-- =========================================================================
-- 6. CÁC THỦ TỤC TRUY VẤN VÀ TÌM KIẾM (YÊU CẦU 1, 3, 5, 6)
-- =========================================================================

-- Yêu cầu 1: Lấy danh sách sách có sẵn để thuê (Số lượng > 0)
CREATE PROCEDURE SP_GetSachConHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSach, TenSach, DonGiaThue, SoLuong
    FROM tSachTruyen
    WHERE SoLuong > 0
    ORDER BY TenSach;
END;
GO

-- Yêu cầu 3: Lấy danh sách sách chưa trả theo mã phiếu thuê
CREATE PROCEDURE SP_GetSachChuaTraTheoPhieu
    @MaThue CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ct.MaSach, s.TenSach, ct.SoLuong, s.DonGiaThue
    FROM tChiTietThueSach ct
    JOIN tSachTruyen s ON s.MaSach = ct.MaSach
    WHERE ct.MaThue = @MaThue AND ct.DaTra = 0;
END;
GO

-- Yêu cầu 5: Tìm kiếm sách truyện kết hợp đa tiêu chí
CREATE PROCEDURE SP_TimSach
    @TenSach NVARCHAR(200) = NULL,
    @MaLV CHAR(4) = NULL,
    @MaTG CHAR(6) = NULL,
    @MaNXB CHAR(6) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT s.MaSach, s.TenSach, lv.TenLV, tg.TenTG, nxb.TenNXB, 
           s.DonGiaThue, s.SoLuong, tt.TenTT, s.Anh
    FROM tSachTruyen s
    JOIN tLinhVuc lv ON lv.MaLV = s.MaLV
    JOIN tTacGia tg ON tg.MaTG = s.MaTG
    JOIN tNXB nxb ON nxb.MaNXB = s.MaNXB
    JOIN tTinhTrang tt ON tt.MaTT = s.MaTT
    WHERE (@TenSach IS NULL OR s.TenSach LIKE N'%' + @TenSach + N'%')
      AND (@MaLV IS NULL OR s.MaLV = @MaLV)
      AND (@MaTG IS NULL OR s.MaTG = @MaTG)
      AND (@MaNXB IS NULL OR s.MaNXB = @MaNXB);
END;
GO

-- Yêu cầu 6: Tìm kiếm nhân viên kết hợp đa tiêu chí
CREATE PROCEDURE SP_TimNhanVien
    @TenNV NVARCHAR(100) = NULL,
    @MaCa CHAR(3) = NULL,
    @GioiTinh CHAR(1) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.MaNV, nv.TenNV, nv.NamSinh, nv.GioiTinh, 
           nv.DiaChi, nv.DienThoai, nv.LuongThang
    FROM tNhanVien nv
    WHERE (@TenNV IS NULL OR nv.TenNV LIKE N'%' + @TenNV + N'%')
      AND (@GioiTinh IS NULL OR nv.GioiTinh = @GioiTinh)
      AND (@MaCa IS NULL OR EXISTS (
          SELECT 1 FROM tThueSach t WHERE t.MaNV = nv.MaNV AND t.MaCa = @MaCa
      ));
END;
GO

-- =========================================================================
-- 7. BÁO CÁO VÀ THỐNG KÊ (YÊU CẦU 7, 8, 9)
-- =========================================================================

-- Yêu cầu 7: Báo cáo sách đang thuê chưa trả
CREATE VIEW vw_SachDangThueChuaTra
AS
SELECT t.MaThue, kh.TenKH, s.MaSach, s.TenSach, ct.SoLuong,
       t.NgayThue,
       DATEDIFF(DAY, t.NgayThue, GETDATE()) AS SoNgayDaThue,
       s.DonGiaThue * (CASE WHEN DATEDIFF(DAY, t.NgayThue, GETDATE()) < 1 THEN 1 
                            ELSE DATEDIFF(DAY, t.NgayThue, GETDATE()) END) * ct.SoLuong AS TienThueTamTinh,
       t.TienDatCoc, nv.TenNV AS NhanVienLap
FROM tChiTietThueSach ct
JOIN tThueSach t ON t.MaThue = ct.MaThue
JOIN tKhachHang kh ON kh.MaKH = t.MaKH
JOIN tSachTruyen s ON s.MaSach = ct.MaSach
JOIN tNhanVien nv ON nv.MaNV = t.MaNV
WHERE ct.DaTra = 0;
GO

-- Yêu cầu 8: Thống kê doanh thu theo Tháng, Quý, Năm
CREATE PROCEDURE SP_DoanhThu
    @Kieu VARCHAR(5),          -- 'THANG', 'QUY' hoặc 'NAM'
    @Nam INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Kieu = 'THANG'
        SELECT MONTH(NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach 
        WHERE YEAR(NgayTra) = @Nam
        GROUP BY MONTH(NgayTra) 
        ORDER BY Ky;
    ELSE IF @Kieu = 'QUY'
        SELECT DATEPART(QUARTER, NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach 
        WHERE YEAR(NgayTra) = @Nam
        GROUP BY DATEPART(QUARTER, NgayTra) 
        ORDER BY Ky;
    ELSE
        SELECT YEAR(NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach
        GROUP BY YEAR(NgayTra) 
        ORDER BY Ky;
END;
GO

-- Yêu cầu 9: Top 5 sách truyện có doanh thu cao nhất
CREATE PROCEDURE SP_Top5SachDoanhThu
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 5 
           ROW_NUMBER() OVER (ORDER BY SUM(c.ThanhTien) DESC) AS Hang,
           s.MaSach, s.TenSach, tg.TenTG,
           COUNT(*) AS SoLanThue,
           SUM(c.ThanhTien) AS DoanhThu
    FROM tChiTietTraSach c
    JOIN tTraSach tr ON tr.MaTra = c.MaTra
    JOIN tSachTruyen s ON s.MaSach = c.MaSach
    JOIN tTacGia tg ON tg.MaTG = s.MaTG
    WHERE (@TuNgay IS NULL OR tr.NgayTra >= @TuNgay)
      AND (@DenNgay IS NULL OR tr.NgayTra <= @DenNgay)
    GROUP BY s.MaSach, s.TenSach, tg.TenTG
    ORDER BY DoanhThu DESC;
END;
GO

-- =========================================================================
-- 8. NẠP DỮ LIỆU MẪU (SEED DATA ĐỂ TEST ĐƯỢC NGAY)
-- =========================================================================

-- Lĩnh vực
INSERT INTO tLinhVuc (MaLV, TenLV) VALUES 
('LV01', N'Truyện tranh Manga'),
('LV02', N'Tiểu thuyết Trinh thám'),
('LV03', N'Văn học Thiếu nhi'),
('LV04', N'Võ hiệp - Kiếm hiệp');

-- Loại sách
INSERT INTO tLoaiSach (MaLoai, TenLoai) VALUES 
('L001', N'Sách mới xuất bản'),
('L002', N'Sách tiêu chuẩn'),
('L003', N'Sách cũ sưu tầm');

-- Tình trạng
INSERT INTO tTinhTrang (MaTT, TenTT) VALUES 
('TT01', N'Mới 99% - Tốt'),
('TT02', N'Bình thường - Ổn định'),
('TT03', N'Hơi cũ - Gáy yếu');

-- Ngôn ngữ
INSERT INTO tNgonNgu (MaNN, TenNN) VALUES 
('VN', N'Tiếng Việt'),
('EN', N'Tiếng Anh'),
('JP', N'Tiếng Nhật');

-- Tác giả
INSERT INTO tTacGia (MaTG, TenTG, NgaySinh, GioiTinh, DiaChi) VALUES 
('TG0001', N'Gosho Aoyama', '1963-06-21', 'M', N'Hokuei, Tottori, Nhật Bản'),
('TG0002', N'Kim Dung', '1924-02-06', 'M', N'Hải Ninh, Chiết Giang, Trung Quốc'),
('TG0003', N'Nguyễn Nhật Ánh', '1955-05-07', 'M', N'Thăng Bình, Quảng Nam'),
('TG0004', N'J.K. Rowling', '1965-07-31', 'F', N'Yate, Gloucestershire, Anh');

-- Nhà xuất bản
INSERT INTO tNXB (MaNXB, TenNXB, DiaChi, DienThoai) VALUES 
('NXB001', N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '02439434730'),
('NXB002', N'NXB Trẻ', N'161B Lý Chính Thắng, TP.HCM', '02839316289'),
('NXB003', N'NXB Văn Học', N'18 Nguyễn Trường Tộ, Hà Nội', '02437161657');

-- Ca làm
INSERT INTO tCaLam (MaCa, TenCa) VALUES 
('CA1', N'Ca Sáng (07:30 - 12:00)'),
('CA2', N'Ca Chiều (12:00 - 17:30)'),
('CA3', N'Ca Tối (17:30 - 22:00)');

-- Vi phạm & tiền phạt
INSERT INTO tViPham (MaVP, TenVP, TienPhat) VALUES 
('VP001', N'Rách bìa / bong gáy', 20000),
('VP002', N'Mất trang / bẩn nhiều trang', 40000),
('VP003', N'Mất sách (Đền nguyên giá bìa)', 80000),
('VP004', N'Trả muộn quá hạn', 15000);

-- Khách hàng
INSERT INTO tKhachHang (MaKH, TenKH, NgaySinh, GioiTinh, DiaChi) VALUES 
('KH25-001', N'Lê Minh Hoàng', '2004-03-15', 'M', N'Cầu Giấy, Hà Nội'),
('KH25-002', N'Trần Thị Mai', '2003-08-20', 'F', N'Đống Đa, Hà Nội'),
('KH25-003', N'Phạm Tuấn Anh', '2005-11-02', 'M', N'Thanh Xuân, Hà Nội');

-- Nhân viên
-- Mật khẩu mặc định trong App là số điện thoại (ví dụ: 0988123456)
INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang) VALUES 
('NV25-01', N'Nguyễn Văn Quản Lý', 1995, 'M', N'Ba Đình, Hà Nội', '0988123456', 12000000),
('NV25-02', N'Trần Thu Hà', 2001, 'F', N'Cầu Giấy, Hà Nội', '0912345678', 6500000);

-- Sách truyện (Đơn vị tính: VNĐ)
INSERT INTO tSachTruyen (MaSach, TenSach, MaLoai, MaLV, MaTG, MaNXB, MaNN, SoTrang, GiaSach, DonGiaThue, MaTT, SoLuong, Anh, GhiChu) VALUES 
('S25-0001', N'Thám tử lừng danh Conan - Tập 100', 'L001', 'LV01', 'TG0001', 'NXB001', 'VN', 180, 30000, 3000, 'TT01', 10, 'Images/conan100.jpg', N'Bản in màu đẹp'),
('S25-0002', N'Tiếu Ngạo Giang Hồ - Trọn bộ Tập 1', 'L002', 'LV04', 'TG0002', 'NXB003', 'VN', 500, 120000, 8000, 'TT02', 5, 'Images/tieungao1.jpg', N'Bìa mềm'),
('S25-0003', N'Mắt Biếc', 'L002', 'LV03', 'TG0003', 'NXB002', 'VN', 280, 85000, 5000, 'TT01', 8, 'Images/matbiec.jpg', N'Bản tái bản 2023'),
('S25-0004', N'Harry Potter và Hòn đá Phù thủy', 'L001', 'LV03', 'TG0004', 'NXB002', 'VN', 350, 135000, 10000, 'TT01', 6, 'Images/harrypotter1.jpg', N'Sách mới 100%');

-- Dữ liệu mẫu Giao dịch: Phiếu thuê
INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc) VALUES 
('TH25100001', 'KH25-001', 'NV25-02', 'CA1', '2025-10-01', 50000),
('TH25100002', 'KH25-002', 'NV25-02', 'CA2', '2025-10-05', 100000);

-- Chi tiết thuê (Trigger sẽ tự động trừ số lượng của S25-0001, S25-0002, S25-0003)
INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
('TH25100001', 'S25-0001', 1, 0),
('TH25100001', 'S25-0003', 1, 0),
('TH25100002', 'S25-0002', 1, 0);

-- Thử nghiệm trả sách 1 cuốn (S25-0001 của phiếu TH25100001) vào ngày 2025-10-04
INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien) VALUES 
('TR25100001', 'TH25100001', 'NV25-02', '2025-10-04', 0);

-- Dùng procedure để tính tiền tự động: 3 ngày x 3000 + 0 = 9000
EXEC SP_ThemChiTietTra @MaTra = 'TR25100001', @MaSach = 'S25-0001', @MaVP = NULL;
GO