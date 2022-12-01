using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class GoiMonDAO
    {
        NETEntities db = new NETEntities();
        public List<KhachHangGoiMon> getGOIMONsByMaTK(string matk)
        {
            return db.KhachHangGoiMons.Where(p => p.MaTk == matk).Select(p => p).ToList();
        }
        public GOIMON getGOIMONBySTT(int STT)
        {
            return db.GOIMONs.Where(p => p.STT == STT).Select(p => p).First();
        }
        public void xoaGoiMonBySTT(int STT)
        {
            db.GOIMONs.Remove(db.GOIMONs.Where(p => p.STT == STT).Select(p => p).First());
            db.SaveChanges();
        }
        public void goiMon(string matk, string mamon, int soluong)
        {
            db.sp_KhachHangGoiMon(matk, mamon, soluong);
        }    
        public void capNhatSoLuong(int STT, int soluong)
        {
            GOIMON gm = db.GOIMONs.Select(p => p).Where(p => p.STT == STT).First();
            gm.SoLuong = soluong;
            db.SaveChanges();
        }
    }
}
