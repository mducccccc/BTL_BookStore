using System.Data;
using BTL.DAL;

namespace BTL.BLL
{
    public class DanhMucBLL
    {
        private readonly DanhMucDAL _dal = new();

        public DataTable GetLinhVuc() => _dal.GetAllLinhVuc();
        public DataTable GetLoaiSach() => _dal.GetAllLoaiSach();
        public DataTable GetTinhTrang() => _dal.GetAllTinhTrang();
        public DataTable GetNgonNgu() => _dal.GetAllNgonNgu();
        public DataTable GetCaLam() => _dal.GetAllCaLam();
        public DataTable GetViPham() => _dal.GetAllViPham();
        public DataTable GetTacGia() => _dal.GetAllTacGia();
        public DataTable GetNXB() => _dal.GetAllNXB();
    }
}
