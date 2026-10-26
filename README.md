# BTL BookStore — Hệ thống Quản lý Cửa hàng Cho thuê Sách truyện

> **BookStore Pro** | Windows Forms · .NET 8 · SQL Server · Kiến trúc 3-Tầng  
> Bài tập lớn môn Lập trình Trực quan — Năm 3

---

## Mục lục

1. [Tổng quan dự án](#tổng-quan-dự-án)
2. [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
3. [Tài khoản đăng nhập và Mật khẩu](#tài-khoản-đăng-nhập-và-mật-khẩu)
4. [Cách cài đặt và chạy](#cách-cài-đặt-và-chạy)
5. [Kiến trúc 3 tầng](#kiến-trúc-3-tầng)
6. [Cấu trúc thư mục](#cấu-trúc-thư-mục)
7. [Chi tiết từng tầng và module](#chi-tiết-từng-tầng-và-module)
8. [Cơ sở dữ liệu](#cơ-sở-dữ-liệu)
9. [Hệ thống giao diện UI Theme](#hệ-thống-giao-diện-ui-theme)
10. [Tính năng theo yêu cầu BTL](#tính-năng-theo-yêu-cầu-btl)
11. [Dependency và Package](#dependency-và-package)

---

## Tổng quan dự án

| Thuộc tính | Giá trị |
|---|---|
| Tên hệ thống | **BookStore Pro — Quản lý Cửa hàng Cho thuê Sách truyện** |
| Nền tảng | Windows Forms (.NET 8) |
| Ngôn ngữ | C# |
| CSDL | SQL Server (LocalDB / SQL Express) |
| Kiến trúc | 3-Tier: Presentation — BLL — DAL |
| Kết nối DB | `Microsoft.Data.SqlClient` |
| Xuất báo cáo | `ClosedXML` → file `.xlsx` |
| Repo | `https://github.com/mducccccc/BTL_BookStore.git` |
| Nhánh chính | `main` |

---

## Yêu cầu hệ thống

- **OS**: Windows 10/11
- **.NET SDK**: 8.0 trở lên (`dotnet --version`)
- **SQL Server**: SQL Express 2019+ hoặc LocalDB
- **Visual Studio**: 2022 (hoặc VS Code với .NET workload)
- **NuGet packages**: tự động restore qua `dotnet restore`

---

## Tài khoản đăng nhập và Mật khẩu

> Hệ thống xác thực dựa trên bảng `tNhanVien` trong SQL Server.  
> **Mật khẩu** của mỗi nhân viên chính là **số điện thoại** được lưu trong trường `DienThoai`.

### Tài khoản mặc định / demo

| Mã NV | Tên nhân viên | Mật khẩu (Số điện thoại) | Ghi chú |
|---|---|---|---|
| `NV25-01` | Nguyễn Văn Quản Lý | `0988123456` | Tài khoản demo chính |

> **Thêm tài khoản mới**: Vào **Quản lý Nhân viên** → điền thông tin đầy đủ → trường *Điện thoại* sẽ là mật khẩu đăng nhập của nhân viên đó.

### Cơ chế xác thực

```
FormLogin.BtnDangNhap_Click()
  → NhanVienBLL.DangNhap(maNV, matKhau)
  → NhanVienDAL.DangNhap()
  → SQL: SELECT * FROM tNhanVien WHERE MaNV=@MaNV AND DienThoai=@MatKhau
  → Nếu tìm thấy → SessionContext.CurrentNhanVien = nv
  → FormLogin trả DialogResult.OK → Program.cs khởi chạy FormMain
```

---

## Cách cài đặt và chạy

### Bước 1 — Clone và Restore

```bash
git clone https://github.com/mducccccc/BTL_BookStore.git
cd BTL_BookStore
dotnet restore
```

### Bước 2 — Tạo CSDL SQL Server

1. Mở **SQL Server Management Studio (SSMS)**.
2. Kết nối tới `.\SQLEXPRESS` (hoặc instance SQL Server của bạn).
3. Mở và chạy file **`BookStore.sql`** trong thư mục gốc dự án.  
   Script sẽ tạo database `QLChoThueSach`, toàn bộ bảng, stored procedures và dữ liệu mẫu.

### Bước 3 — Kiểm tra chuỗi kết nối

File: `DAL/DatabaseHelper.cs` dòng 12:

```csharp
private static string _connectionString =
    @"Server=.\SQLEXPRESS;Database=QLChoThueSach;Trusted_Connection=True;TrustServerCertificate=True;";
```

Sửa `Server=` nếu dùng instance khác (ví dụ: `Server=(localdb)\MSSQLLocalDB`).

### Bước 4 — Chạy ứng dụng

```bash
dotnet run
# hoặc: mở BTL.sln trong Visual Studio → nhấn F5
```

---

## Kiến trúc 3 tầng

```
┌─────────────────────────────────────────────────────────┐
│                  TẦNG TRÌNH BÀY (GUI)                   │
│  FormLogin · FormMain · UC_Dashboard · UC_Sach          │
│  UC_ThueSach · UC_TraSach · UC_KhachHang · UC_NhanVien  │
│  UC_DanhMuc · UC_TimKiem · UC_BaoCao                    │
│  UITheme · ExportExcelHelper                            │
└─────────────────────┬───────────────────────────────────┘
                      │  Gọi BLL methods
┌─────────────────────▼───────────────────────────────────┐
│                TẦNG NGHIỆP VỤ (BLL)                     │
│  SachBLL · ThueTraBLL · KhachHangBLL · NhanVienBLL      │
│  DanhMucBLL · BaoCaoBLL                                 │
└─────────────────────┬───────────────────────────────────┘
                      │  Gọi DAL methods
┌─────────────────────▼───────────────────────────────────┐
│               TẦNG DỮ LIỆU (DAL)                        │
│  SachDAL · ThueTraDAL · KhachHangDAL · NhanVienDAL      │
│  DanhMucDAL · BaoCaoDAL · DatabaseHelper                │
└─────────────────────┬───────────────────────────────────┘
                      │  ADO.NET / SqlClient
┌─────────────────────▼───────────────────────────────────┐
│              SQL SERVER — QLChoThueSach                  │
│  tSach · tKhachHang · tNhanVien · tPhieuThue            │
│  tChiTietThue · tPhieuTra · tChiTietTra                 │
│  tViPham · tCaLam · tTacGia · tNXB · tLoaiSach...      │
└─────────────────────────────────────────────────────────┘

DTO (Data Transfer Object) — truyền dữ liệu xuyên suốt 3 tầng
mà không expose trực tiếp DataTable / DataRow.
```

---

## Cấu trúc thư mục

```
BTL/
├── BTL.csproj               ← Cấu hình project (.NET 8 WinForms, ClosedXML, SqlClient)
├── BTL.sln                  ← Solution file Visual Studio
├── Program.cs               ← Entry point: FormLogin → FormMain
├── BookStore.sql            ← Script đầy đủ: tạo DB + bảng + SP + dữ liệu mẫu
├── README.md                ← Tài liệu dự án (file này)
│
├── DTO/                     ← Data Transfer Objects (truyền dữ liệu giữa các tầng)
│   ├── SachDTO.cs           ← class SachDTO
│   ├── NguoiDungDTO.cs      ← class KhachHangDTO, NhanVienDTO
│   ├── ThueTraDTO.cs        ← class ThueSachDTO, ChiTietThueDTO, TraSachDTO, ChiTietTraDTO
│   ├── DanhMucDTO.cs        ← class LoaiSachDTO, LinhVucDTO, TinhTrangDTO, NgonNguDTO,
│   │                            CaLamDTO, TacGiaDTO, NXBDTO, ViPhamDTO
│   └── SessionContext.cs    ← Static class lưu phiên đăng nhập
│
├── DAL/                     ← Data Access Layer (trực tiếp tương tác SQL Server)
│   ├── DatabaseHelper.cs    ← Helper tĩnh: ExecuteQuery / NonQuery / Scalar / StoredProc
│   ├── SachDAL.cs           ← CRUD sách, generate MaSach, tìm kiếm
│   ├── KhachHangDAL.cs      ← CRUD khách hàng, generate MaKH
│   ├── NhanVienDAL.cs       ← CRUD nhân viên, DangNhap(), tìm kiếm theo ca/giới tính
│   ├── ThueTraDAL.cs        ← Lập phiếu thuê/trả, trừ kho, hoàn kho
│   ├── DanhMucDAL.cs        ← CRUD: ViPham, TacGia, NXB, CaLam, LoaiSach, LinhVuc...
│   └── BaoCaoDAL.cs         ← Truy vấn báo cáo: sách chưa trả, doanh thu, top 5
│
├── BLL/                     ← Business Logic Layer (validate + điều phối nghiệp vụ)
│   ├── SachBLL.cs
│   ├── KhachHangBLL.cs
│   ├── NhanVienBLL.cs
│   ├── ThueTraBLL.cs
│   ├── DanhMucBLL.cs
│   └── BaoCaoBLL.cs
│
├── GUI/                     ← Tầng giao diện (Windows Forms)
│   ├── UITheme.cs           ← Design system: Color tokens + helper methods
│   ├── ExportExcelHelper.cs ← Xuất DataGridView ra .xlsx (ClosedXML)
│   ├── FormLogin.cs         ← Form đăng nhập
│   ├── FormMain.Designer.cs ← Layout cửa sổ chính (auto-generated style)
│   ├── FormMain.cs          ← Logic điều hướng, session, đồng hồ
│   ├── UC_Dashboard.cs      ← Tổng quan: 4 thẻ chỉ số + bảng sách đang thuê
│   ├── UC_Sach.cs           ← Quản lý kho sách (CRUD + ảnh bìa + xuất Excel)
│   ├── UC_ThueSach.cs       ← Lập phiếu thuê (giỏ sách, trừ kho tự động)
│   ├── UC_TraSach.cs        ← Nhận trả sách + tính tiền + phạt vi phạm
│   ├── UC_KhachHang.cs      ← Quản lý khách hàng
│   ├── UC_NhanVien.cs       ← Quản lý nhân viên
│   ├── UC_DanhMuc.cs        ← Danh mục: Vi phạm, Tác giả, NXB, Ca làm việc
│   ├── UC_TimKiem.cs        ← Tra cứu đa tiêu chí: Sách + Nhân viên
│   ├── UC_BaoCao.cs         ← 3 báo cáo: Sách chưa trả, Doanh thu (biểu đồ), Top 5
│   └── UC_Placeholder.cs   ← Placeholder dự phòng
│
└── Images/                  ← Ảnh bìa sách (đường dẫn lưu trong tSach.Anh)
```

---

## Chi tiết từng tầng và module

### Tầng DTO — Data Transfer Object

| Class | File | Các thuộc tính chính |
|---|---|---|
| `SachDTO` | SachDTO.cs | MaSach, TenSach, MaLoai, MaLV, MaTG, MaNXB, MaNN, SoTrang, GiaSach, DonGiaThue, MaTT, SoLuong, Anh, GhiChu |
| `KhachHangDTO` | NguoiDungDTO.cs | MaKH, TenKH, NgaySinh, GioiTinh, DiaChi |
| `NhanVienDTO` | NguoiDungDTO.cs | MaNV, TenNV, NamSinh, GioiTinh, DiaChi, **DienThoai** (=mật khẩu), LuongThang |
| `ThueSachDTO` | ThueTraDTO.cs | MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc |
| `ChiTietThueDTO` | ThueTraDTO.cs | MaThue, MaSach, SoLuong, DaTra |
| `TraSachDTO` | ThueTraDTO.cs | MaTra, MaThue, MaNV, NgayTra, TongTien |
| `ChiTietTraDTO` | ThueTraDTO.cs | MaTra, MaSach, MaVP, ThanhTien, SoLuong, SoNgayThue |
| `ViPhamDTO` | DanhMucDTO.cs | MaVP, TenVP, TienPhat |
| `TacGiaDTO` | DanhMucDTO.cs | MaTG, TenTG, NgaySinh, GioiTinh, DiaChi |
| `NXBDTO` | DanhMucDTO.cs | MaNXB, TenNXB, DiaChi, DienThoai |
| `CaLamDTO` | DanhMucDTO.cs | MaCa, TenCa |
| `SessionContext` | SessionContext.cs | `CurrentNhanVien` (NhanVienDTO?), `CurrentCaLam` (string), `IsLoggedIn` (bool) |

---

### Tầng DAL — Data Access Layer

#### `DatabaseHelper.cs` — Trung tâm kết nối

| Phương thức | Input | Output | Dùng cho |
|---|---|---|---|
| `GetConnection()` | — | `SqlConnection` | Tạo kết nối mới |
| `ExecuteQuery(sql, params)` | SQL + params | `DataTable` | SELECT |
| `ExecuteNonQuery(sql, params)` | SQL + params | `int` (rows affected) | INSERT/UPDATE/DELETE |
| `ExecuteScalar(sql, params)` | SQL + params | `object?` | COUNT, MAX, scalar |
| `ExecuteStoredProcedure(spName, params)` | SP name + params | `DataTable` | SELECT qua SP |
| `ExecuteStoredProcedureNonQuery(spName, params)` | SP name + params | `int` | DML qua SP |

**Chuỗi kết nối mặc định** (`DAL/DatabaseHelper.cs` dòng 12):
```
Server=.\SQLEXPRESS;Database=QLChoThueSach;Trusted_Connection=True;TrustServerCertificate=True;
```

---

#### `NhanVienDAL.cs` — Bao gồm logic đăng nhập

```csharp
// DangNhap: so sánh MaNV + DienThoai (= mật khẩu)
SELECT * FROM tNhanVien WHERE MaNV = @MaNV AND DienThoai = @MatKhau
```

---

### Tầng BLL — Business Logic Layer

| Class | Validate nổi bật |
|---|---|
| `NhanVienBLL` | TenNV và DienThoai không được trống |
| `KhachHangBLL` | TenKH không được trống |
| `SachBLL` | TenSach bắt buộc, DonGiaThue > 0 |
| `ThueTraBLL` | Phiếu thuê phải có ít nhất 1 sách; SoLuong > 0 |
| `DanhMucBLL` | Mã và Tên không được trống |
| `BaoCaoBLL` | Pass-through với tham số ngày/kỳ |

---

### Tầng GUI — Giao diện người dùng

#### `FormLogin.cs` — Đăng nhập

- Nhập Mã NV + Mật khẩu (= số điện thoại) + Chọn Ca làm việc.
- Xác thực qua `NhanVienBLL.DangNhap()`.
- Lưu kết quả vào `SessionContext.CurrentNhanVien` và `CurrentCaLam`.

---

#### `FormMain` — Cửa sổ chính

- **Top strip** (Navy): Tiêu đề "HỆ THỐNG QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN - BOOKSTORE PRO" | Hotline | Giờ mở cửa.
- **Sidebar** (Navy): 9 nút điều hướng dọc, nút active có màu `NavActiveBg` + chữ `Yellow`.
- **Content area**: Panel trung tâm, swap `UserControl` theo từng nút.
- **Top bar** (White): Đồng hồ thời gian thực · Tên NV · Ca trực · Nút Đăng xuất.
- **Breadcrumb**: `BOOKSTORE / QUẢN LÝ / [TÊN MODULE]`.

---

#### `UC_Dashboard.cs` — Tổng quan

- 4 thẻ chỉ số (card): Tổng đầu sách · Sách đang thuê · Khách hàng · Phiếu trả đã lập.
- Mỗi thẻ có đường line màu nhấn bên trái + số liệu lớn.
- Bảng phía dưới: Danh sách tất cả sách đang được thuê chưa trả.

---

#### `UC_Sach.cs` — Quản lý kho sách

- CRUD: Thêm / Cập nhật / Xóa / Làm mới.
- Upload ảnh bìa (PictureBox), lưu đường dẫn vào DB.
- Tìm kiếm nhanh theo tên sách / tác giả.
- Xuất danh sách ra Excel qua `ExportExcelHelper`.
- Tự sinh mã sách qua Stored Procedure.

---

#### `UC_ThueSach.cs` — Lập phiếu thuê

> YC 1: Chỉ cho chọn sách còn hàng (SoLuong > 0)  
> YC 2: Tự động trừ kho khi lưu phiếu

- Giỏ sách: thêm nhiều đầu sách vào 1 phiếu thuê.
- Hiển thị tồn kho + đơn giá thuê realtime khi chọn sách.
- Lưu đồng thời: `tPhieuThue` + `tChiTietThue` + UPDATE `tSach.SoLuong`.
- Bảng lịch sử phiếu thuê bên phải.

---

#### `UC_TraSach.cs` — Nhận trả sách & Tính tiền

> YC 3: Chỉ hiển thị sách chưa trả của phiếu thuê  
> YC 4: Tính tiền = SoNgayThue × DonGiaThue × SoLuong + TienPhat

- Chọn phiếu thuê → auto hiển thị thông tin KH, ngày thuê, tiền cọc.
- Chọn sách → chọn loại vi phạm (nếu có) → thành tiền tính tự động.
- Thanh toán cuối = Tổng thành tiền − Tiền cọc.
- Lưu: `tPhieuTra` + `tChiTietTra` + hoàn kho `tSach.SoLuong`.

---

#### `UC_KhachHang.cs` — Quản lý khách hàng

- CRUD đầy đủ + tìm kiếm nhanh.
- Tự sinh mã khách hàng qua SP.

---

#### `UC_NhanVien.cs` — Quản lý nhân viên

- CRUD + tìm kiếm.
- **Trường Điện thoại = Mật khẩu đăng nhập** của nhân viên đó.

---

#### `UC_DanhMuc.cs` — Danh mục phụ trợ

| Tab | Nội dung |
|---|---|
| Vi Phạm & Tiền Phạt | Loại vi phạm + mức tiền phạt |
| Tác Giả | Thông tin tác giả sách |
| Nhà Xuất Bản | Thông tin NXB |
| Ca Làm Việc | Ca 1 Sáng / Ca 2 Chiều / Ca 3 Tối |

---

#### `UC_TimKiem.cs` — Tra cứu đa tiêu chí

> YC 5: Tìm sách  
> YC 6: Tìm nhân viên

| Tab | Bộ lọc |
|---|---|
| Tra Cứu Sách | Tên sách + Lĩnh vực + Tác giả + NXB (AND logic, tìm ngay khi gõ) |
| Tra Cứu Nhân Viên | Tên NV + Ca làm việc + Giới tính |

Tab Sách có **preview ảnh bìa** khi click vào dòng kết quả.

---

#### `UC_BaoCao.cs` — Báo cáo & Thống kê

| Tab | YC | Nội dung |
|---|---|---|
| Sách Đang Thuê Chưa Trả | 7 | Danh sách + tổng số cuốn + tổng tiền tạm tính + tổng cọc |
| Doanh Thu | 8 | Chọn kỳ Tháng/Quý/Năm + năm → bảng + biểu đồ cột GDI+ tự vẽ |
| Top 5 Sách Doanh Thu Cao | 9 | Lọc theo khoảng ngày → bảng xếp hạng TOP 1-5 |

Ba tab đều có nút **Xuất Excel** qua `ExportExcelHelper`.

---

#### `ExportExcelHelper.cs` — Xuất báo cáo Excel

Cấu trúc file `.xlsx` được tạo ra:

```
Dòng 1: CỬA HÀNG CHO THUÊ SÁCH TRUYỆN BOOKSTORE  (màu Muted, merge toàn bộ cột)
Dòng 2: [Tiêu đề báo cáo IN HOA]                  (Navy, Bold, căn giữa)
Dòng 3: Thời gian xuất: dd/MM/yyyy HH:mm  |  Người lập: [Tên NV]  (Italic)
Dòng 4: (trống)
Dòng 5: Header cột                                 (Pale #EAF5FC, Navy Bold)
Dòng 6+: Dữ liệu (auto-detect: số tiền → #,##0  |  ngày → dd/MM/yyyy)
```

---

#### `UITheme.cs` — Design System

Helper static class áp dụng theme nhất quán cho toàn ứng dụng:

| Method | Tác dụng |
|---|---|
| `StyleDataGridView(dgv)` | Áp theme chuẩn: header Pale, text Navy, row 32px, alt row |
| `StylePrimaryButton(btn)` | Blue background, trắng, FlatStyle, no border |
| `StyleSecondaryButton(btn)` | White background, Navy text, border 1px Border |
| `StyleDangerButton(btn)` | Red (#DC2626), white, FlatStyle |
| `StyleSummaryBox(pnl)` | Panel Pale, title Navy Bold, subtitle Muted |

---

## Cơ sở dữ liệu

**Tên DB**: `QLChoThueSach`  
**Script khởi tạo**: `BookStore.sql` (trong thư mục gốc dự án)

### Bảng chính

| Bảng | Khóa chính | Mô tả |
|---|---|---|
| `tSach` | `MaSach` CHAR(8) | Danh mục sách truyện |
| `tKhachHang` | `MaKH` CHAR(8) | Khách hàng |
| `tNhanVien` | `MaNV` CHAR(7) | Nhân viên (DienThoai = mật khẩu) |
| `tPhieuThue` | `MaThue` CHAR(10) | Phiếu thuê sách |
| `tChiTietThue` | `(MaThue, MaSach)` | Chi tiết sách trong phiếu thuê |
| `tPhieuTra` | `MaTra` CHAR(10) | Phiếu trả & thanh toán |
| `tChiTietTra` | `(MaTra, MaSach)` | Chi tiết trả từng cuốn |
| `tViPham` | `MaVP` CHAR(5) | Loại vi phạm + tiền phạt |
| `tCaLam` | `MaCa` CHAR(5) | Ca làm việc |
| `tTacGia` | `MaTG` CHAR(5) | Tác giả |
| `tNXB` | `MaNXB` CHAR(5) | Nhà xuất bản |
| `tLoaiSach` | `MaLoai` CHAR(5) | Loại sách (tiểu thuyết, truyện tranh...) |
| `tLinhVuc` | `MaLV` CHAR(5) | Lĩnh vực (viễn tưởng, lịch sử...) |
| `tNgonNgu` | `MaNN` CHAR(5) | Ngôn ngữ |
| `tTinhTrang` | `MaTT` CHAR(5) | Tình trạng sách |

### Stored Procedures

| SP | Tác dụng |
|---|---|
| `SP_GenerateNewMaSach` | Tự sinh mã sách format SACH-XXX |
| `SP_GenerateNewMaNV` | Tự sinh mã nhân viên format NV25-XX |
| `SP_GenerateNewMaKH` | Tự sinh mã khách hàng |
| `SP_GenerateNewMaThue` | Tự sinh mã phiếu thuê |
| `SP_GenerateNewMaTra` | Tự sinh mã phiếu trả |
| `SP_GetDoanhThu` | Doanh thu theo kỳ/tháng/quý/năm |
| `SP_GetTop5Sach` | Top 5 sách doanh thu cao nhất |
| `SP_GetSachDangThueChuaTra` | Sách đang thuê chưa trả (kèm tổng tiền tạm tính) |

---

## Hệ thống giao diện UI Theme

### Bảng màu (Color Tokens)

| Token | Hex | Dùng cho |
|---|---|---|
| `Navy` | `#1C4279` | Sidebar, top strip, tiêu đề chính, header DGV |
| `Blue` | `#087FB5` | Nút primary, action trigger |
| `BlueHover` | `#066A98` | Hover trạng thái nút primary |
| `Pale` | `#EAF5FC` | Header DataGridView, thẻ summary |
| `Page` | `#F4F9FC` | Màu nền tổng thể toàn ứng dụng |
| `Border` | `#DCE7F1` | Đường viền, phân cách, splitter |
| `Text` | `#183B68` | Màu chữ chính |
| `Muted` | `#607B99` | Phụ đề, metadata, breadcrumb |
| `Yellow` | `#F5D52A` | Logo BOOKSTORE, nút sidebar đang active |
| `NavActiveBg` | `#28558E` | Nền nút sidebar khi đang chọn |
| `SelectionBg` | `#D0E6F6` | Hàng được chọn trong DataGridView |

---

## Tính năng theo yêu cầu BTL

| # | Yêu cầu | Module | Mô tả kỹ thuật |
|---|---|---|---|
| 1 | Lập phiếu thuê sách | `UC_ThueSach` | ComboBox sách chỉ lấy SoLuong > 0 từ DB |
| 2 | Tự động trừ/hoàn kho | `ThueTraDAL` | UPDATE tSach.SoLuong ±SoLuong khi lưu phiếu thuê/trả |
| 3 | Lọc sách chưa trả | `UC_TraSach` | JOIN tChiTietThue WHERE DaTra = 0 AND MaThue = @MaThue |
| 4 | Tính tiền thuê + phạt | `UC_TraSach` | ThanhTien = SoNgayThue × DonGiaThue × SoLuong + TienPhat |
| 5 | Tìm kiếm sách đa tiêu chí | `UC_TimKiem` | Lọc AND: Tên + Lĩnh vực + Tác giả + NXB; preview ảnh bìa |
| 6 | Tìm kiếm nhân viên | `UC_TimKiem` | Lọc AND: Tên + Ca làm việc + Giới tính |
| 7 | BC sách đang thuê chưa trả | `UC_BaoCao` | SP_GetSachDangThueChuaTra + tổng tiền tạm tính |
| 8 | BC doanh thu | `UC_BaoCao` | SP_GetDoanhThu + biểu đồ cột GDI+ tự vẽ (SmoothingMode AntiAlias) |
| 9 | BC Top 5 sách doanh thu | `UC_BaoCao` | SP_GetTop5Sach + xếp hạng TOP 1-5 |
| 10 | Đăng nhập phiên làm việc | `FormLogin` | Xác thực NV qua DB; chọn ca; lưu SessionContext |

---

## Dependency và Package

```xml
<!-- BTL.csproj -->
<PackageReference Include="ClosedXML" Version="0.105.1" />
<PackageReference Include="Microsoft.Data.SqlClient" Version="7.1.1" />
```

| Package | Phiên bản | Tác dụng |
|---|---|---|
| `ClosedXML` | 0.105.1 | Tạo file Excel .xlsx có đầy đủ format: màu cell, font, border, number format |
| `Microsoft.Data.SqlClient` | 7.1.1 | Kết nối SQL Server qua ADO.NET; TrustServerCertificate tránh lỗi SSL |

---

## Lệnh hay dùng khi phát triển

```bash
# Restore packages
dotnet restore

# Build Debug
dotnet build

# Build Release
dotnet build -c Release

# Run
dotnet run

# Kill BTL.exe trước khi build để tránh file lock
Stop-Process -Name "BTL" -Force -ErrorAction SilentlyContinue

# Push thay đổi lên GitHub
git add .
git commit -m "feat: mo ta thay doi"
git push origin main
```

> **Lưu ý**: Nếu gặp lỗi `MSB3021/3027` (file lock khi build), đảm bảo đã tắt `BTL.exe` trước khi build.

---

*Cập nhật lần cuối: 10/2026 | Branch: `main`*  
*Repository: [github.com/mducccccc/BTL_BookStore](https://github.com/mducccccc/BTL_BookStore)*
