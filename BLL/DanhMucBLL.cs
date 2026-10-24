using System.Data;
using BTL.DAL;
using BTL.DTO;

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

        // Vi phạm
        public bool InsertViPham(ViPhamDTO vp) => _dal.InsertViPham(vp);
        public bool UpdateViPham(ViPhamDTO vp) => _dal.UpdateViPham(vp);
        public bool DeleteViPham(string maVP) => _dal.DeleteViPham(maVP);

        // Tác giả
        public bool InsertTacGia(TacGiaDTO tg) => _dal.InsertTacGia(tg);
        public bool UpdateTacGia(TacGiaDTO tg) => _dal.UpdateTacGia(tg);
        public bool DeleteTacGia(string maTG) => _dal.DeleteTacGia(maTG);

        // NXB
        public bool InsertNXB(NXBDTO nxb) => _dal.InsertNXB(nxb);
        public bool UpdateNXB(NXBDTO nxb) => _dal.UpdateNXB(nxb);
        public bool DeleteNXB(string maNXB) => _dal.DeleteNXB(maNXB);

        // Ca làm
        public bool InsertCaLam(CaLamDTO ca) => _dal.InsertCaLam(ca);
        public bool UpdateCaLam(CaLamDTO ca) => _dal.UpdateCaLam(ca);
        public bool DeleteCaLam(string maCa) => _dal.DeleteCaLam(maCa);
    }
}
