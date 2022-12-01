using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class KhachHangDAO
    {
        NETEntities db = new NETEntities();

        public KhachHangDAO()
        {
        }


        //public string dangNhap(string taikhoan, string matkhau)
        //{
        //    try
        //    {
        //        conn = new SqlConnection(strConnectionString);
        //        conn.Open();
        //        SqlCommand command = new SqlCommand(SF_DangNhapTaiKhoan, conn);
        //        command.CommandType = CommandType.Text;
        //        command.Parameters.AddWithValue("@taikhoan", taikhoan.ToLower());
        //        command.Parameters.AddWithValue("@matkhau", matkhau);

        //        string result = command.ExecuteScalar().ToString();
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }

        //}
        //public void updateTrangThai(String maTK)
        //{
        //    try
        //    {
        //        conn = new SqlConnection(strConnectionString);
        //        SqlCommand cmd = new SqlCommand(UPDATE_TINHTRANG_ByMaTK, conn);
        //        cmd.Parameters.AddWithValue("@MaTK", maTK);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //    }

        //}
        public KHACHHANG getKHACHHANG_ByMaTK(string maTK)
        {
            try
            {
                return db.KHACHHANGs.Select(p => p).Where(p => p.MaTK == maTK).First();
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
