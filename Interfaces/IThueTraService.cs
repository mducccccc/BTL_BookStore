using System;
using System.Collections.Generic;
using System.Data;
using BTL.DTO;

namespace BTL.Interfaces
{
    public interface IThueTraService
    {
        string GenerateNewMaThue();
        DataTable GetAllPhieuThue();
        DataTable GetChiTietThue(string maThue);
        bool LapPhieuThue(ThueSachDTO thue, List<ChiTietThueDTO> chiTietList, out string error);
        string GenerateNewMaTra();
        DataTable GetAllPhieuTra();
        DataTable GetChiTietTra(string maTra);
        DataTable GetSachChuaTra(string maThue);
        bool LapPhieuTra(TraSachDTO tra, List<ChiTietTraDTO> chiTietList, out string error);
    }
}
