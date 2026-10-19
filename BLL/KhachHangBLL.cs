using System;
using System.Data;
using BTL.DAL;
using BTL.DTO;

namespace BTL.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _dal = new();

        public DataTable GetAll() => _dal.GetAll();
        public string GenerateNewMaKH() => _dal.GenerateNewMaKH();

        public bool Insert(KhachHangDTO kh, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(kh.TenKH))
            {
                error = "Tên khách hàng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.MaKH))
            {
                kh.MaKH = _dal.GenerateNewMaKH();
            }

            try
            {
                return _dal.Insert(kh);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Update(KhachHangDTO kh, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(kh.MaKH))
            {
                error = "Mã khách hàng không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.TenKH))
            {
                error = "Tên khách hàng không được để trống!";
                return false;
            }

            try
            {
                return _dal.Update(kh);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool Delete(string maKH, out string error)
        {
            error = string.Empty;
            try
            {
                return _dal.Delete(maKH);
            }
            catch (Exception ex)
            {
                error = "Không thể xóa khách hàng này vì đã có dữ liệu phiếu thuê sách liên quan. (" + ex.Message + ")";
                return false;
            }
        }
    }
}
