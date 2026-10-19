using System;
using System.Collections.Generic;
using System.Data;
using BTL.DAL;
using BTL.DTO;

namespace BTL.BLL
{
    public class ThueTraBLL
    {
        private readonly ThueTraDAL _dal = new();

        #region THUÊ SÁCH (YÊU CẦU 1, 2)

        public string GenerateNewMaThue() => _dal.GenerateNewMaThue();
        public DataTable GetAllPhieuThue() => _dal.GetAllPhieuThue();
        public DataTable GetChiTietThue(string maThue) => _dal.GetChiTietThue(maThue);

        public bool LapPhieuThue(ThueSachDTO thue, List<ChiTietThueDTO> chiTietList, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(thue.MaKH))
            {
                error = "Vui lòng chọn khách hàng thuê sách!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(thue.MaNV))
            {
                error = "Vui lòng chọn nhân viên lập phiếu!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(thue.MaCa))
            {
                error = "Vui lòng chọn ca làm việc!";
                return false;
            }
            if (chiTietList == null || chiTietList.Count == 0)
            {
                error = "Phiếu thuê phải có ít nhất 1 cuốn sách!";
                return false;
            }

            // Yêu cầu 1: Kiểm tra số lượng thuê hợp lệ (> 0)
            foreach (var ct in chiTietList)
            {
                if (ct.SoLuong <= 0)
                {
                    error = $"Số lượng thuê sách [{ct.MaSach}] phải lớn hơn 0!";
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(thue.MaThue))
            {
                thue.MaThue = _dal.GenerateNewMaThue();
            }

            try
            {
                return _dal.LapPhieuThue(thue, chiTietList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        #endregion

        #region TRẢ SÁCH (YÊU CẦU 2, 3, 4)

        public string GenerateNewMaTra() => _dal.GenerateNewMaTra();
        public DataTable GetAllPhieuTra() => _dal.GetAllPhieuTra();
        public DataTable GetChiTietTra(string maTra) => _dal.GetChiTietTra(maTra);

        // Yêu cầu 3: Lấy danh sách sách chưa trả theo mã phiếu thuê
        public DataTable GetSachChuaTra(string maThue)
        {
            if (string.IsNullOrWhiteSpace(maThue)) return new DataTable();
            return _dal.GetSachChuaTra(maThue);
        }

        public bool LapPhieuTra(TraSachDTO tra, List<ChiTietTraDTO> chiTietList, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(tra.MaThue))
            {
                error = "Vui lòng chọn mã phiếu thuê cần trả sách!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(tra.MaNV))
            {
                error = "Vui lòng chọn nhân viên nhận trả sách!";
                return false;
            }
            if (chiTietList == null || chiTietList.Count == 0)
            {
                error = "Vui lòng chọn ít nhất 1 cuốn sách để trả!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tra.MaTra))
            {
                tra.MaTra = _dal.GenerateNewMaTra();
            }

            try
            {
                return _dal.LapPhieuTra(tra, chiTietList);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
