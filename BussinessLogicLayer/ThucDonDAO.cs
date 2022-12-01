using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class ThucDonDAO
    {
        NETEntities db = new NETEntities();

        public List<THUCDON> getAllThucDon()
        {
            return db.THUCDONs.Select(p => p).ToList();
        }
        public List<THUCDON> getTHUCDONsByLoai(string loai)
        {
            return db.THUCDONs.Select(p => p).Where(p => p.MaMon.Contains(loai)).ToList();
        }
        public THUCDON findThucDonById(string MaMon)
        {
            return db.THUCDONs.Where(p => p.MaMon == MaMon).First();
        }
        public List<THUCDON> getThucDonbyPhanLoai(string name)
        {
            return db.THUCDONs.Select(p => p).Where(p => p.PhanLoai.ToLower().Contains(name.ToLower())).ToList();
        }


    }
}
