using System;
using System.Data;
using BTL.DAL;
using BTL.DTO;

namespace BTL.BLL
{
    public class SachBLL
    {
        private readonly SachDAL _dal = new();

        public DataTable GetAll() => _dal.GetAll();

        public string GenerateNewMaSach() => _dal.GenerateNewMaSach();

        public bool Insert(SachDTO sach, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(sach.TenSach))
            {
                error = "Tên sách không được để trống!";
                return false;
            }
            if (sach.DonGiaThue < 0 || sach.GiaSach < 0)
            {
                error = "Giá sách và đơn giá thuê không được là số âm!";
                return false;
            }
            if (sach.SoLuong < 0)
            {
                error = "Số lượng sách không được nhỏ hơn 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sach.MaSach))
            {
                sach.MaSach = _dal.GenerateNewMaSach();
            }

            try
            {
                return _dal.Insert(sach);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Update(SachDTO sach, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(sach.MaSach))
            {
                error = "Mã sách không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(sach.TenSach))
            {
                error = "Tên sách không được để trống!";
                return false;
            }
            if (sach.DonGiaThue < 0 || sach.GiaSach < 0)
            {
                error = "Giá sách và đơn giá thuê không được là số âm!";
                return false;
            }
            if (sach.SoLuong < 0)
            {
                error = "Số lượng sách không được nhỏ hơn 0!";
                return false;
            }

            try
            {
                return _dal.Update(sach);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Delete(string maSach, out string error)
        {
            error = string.Empty;
            try
            {
                return _dal.Delete(maSach);
            }
            catch (Exception ex)
            {
                error = "Không thể xóa sách này vì đã có dữ liệu giao dịch mượn/trả liên quan. (" + ex.Message + ")";
                return false;
            }
        }

        // Yêu cầu 1: Lấy danh sách sách có số lượng > 0
        public DataTable GetSachConHang() => _dal.GetSachConHang();

        // Yêu cầu 5: Tìm kiếm sách truyện
        public DataTable TimKiemSach(string? tenSach, string? maLV, string? maTG, string? maNXB)
        {
            return _dal.TimKiemSach(tenSach, maLV, maTG, maNXB);
        }
    }
}
