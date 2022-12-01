using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class QuanTriDAO
    {
        NETEntities db = new NETEntities();
        public int getMaQuanTriByMaTK(string matk)
        {
            try
            {
                int a = db.QUANTRIs.Where(p => p.MaTKKhachHang == matk).OrderByDescending(p => p.MaQuanTri).Select(p => p.MaQuanTri).First();

                return a;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
