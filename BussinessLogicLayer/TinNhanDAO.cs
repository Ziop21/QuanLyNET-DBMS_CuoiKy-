using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class TinNhanDAO
    {
        NETEntities db = new NETEntities();
        public void addTinNhan(TINNHAN tn)
        {
            db.TINNHANs.Add(tn);
            db.SaveChanges();
        }
        public TINNHAN getTinNhanLast(int maqt, string matkgui, string matknhan)
        {
            var getTinNhanNhanVien = db.TINNHANs.Where(p => p.MaQuanTri == maqt && p.MaTKNhan == matknhan && p.MaTKGui == matkgui).Select(p => p);
            if (getTinNhanNhanVien.ToList().Count != 0)
            {
                return getTinNhanNhanVien.OrderByDescending(p => p.TgGui).First();
            }
            return null;
                
        }
    }
}
