using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussinessLogicLayer
{
    public class TaiKhoanDAO
    {
        public TaiKhoanDAO()
        {
        }
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        NETEntities db = new NETEntities();
        public void doiMatKhau(string matk, string matkhaucu, string matkhaumoi)
        {
            try
            {
                TAIKHOAN tk = db.TAIKHOANs.Select(p => p).Where(p => p.MaTK == matk).First();
                if (tk.MatKhau == matkhaucu)
                {
                    tk.MatKhau = matkhaumoi;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public string getMaTKNhanVienQuanTriHienTai()
        {
            return db.NHANVIENs.Where(p => p.CONGVIEC.TenCV.ToLower().Contains("thu ngân") && p.TAIKHOAN.TinhTrang == "on").Select(p => p.MaTK).First();
        }
        //public string phanQuyen(string matk)
        //{
        //    try
        //    {
        //        string role = "";
        //        if (db.NHANVIENs.Select(p => p.MaTK).Contains(matk))
        //        {
        //            NHANVIEN nv = db.NHANVIENs.Select(p => p).Where(p => p.MaTK == matk).First();
        //            if (nv.MaCV != "cv001")
        //                role = "Nhân viên";
        //            else
        //                role = "Quản trị";
        //        }
        //        else if (db.KHACHHANGs.Select(p => p.MaTK).Contains(matk))
        //            role = "Khách Hàng";
        //        return role;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        public string dangNhap(string taikhoan, string matkhau, string mamay)
        {
            try
            {
                //string matk = db.TAIKHOANs.Select(p => p.MaTK).Where(p => p == DefinedFunction.sf_DangNhapTaiKhoan(taikhoan, matkhau)).First();
                //matk = matk.Trim();

                string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
                conn = new SqlConnection(connection);
                conn.Open();
                cmd = new SqlCommand("select dbo.sf_DangNhapTaiKhoan(@taikhoan_input, @matkhau_input)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@taikhoan_input", taikhoan));
                cmd.Parameters.Add(new SqlParameter("@matkhau_input", matkhau));
                string matk = cmd.ExecuteScalar().ToString();
                matk = matk.Trim();
                //adapter = new SqlDataAdapter(cmd);
                //dt = new DataTable();
                //adapter.Fill(dt);
                conn.Close();

                if (matk == "Sai mk" || matk == "Sai tk")
                {
                    return matk;
                }
                else if (matk == "Loi")
                {
                    return matk;
                }



                if (!String.IsNullOrEmpty(matk))
                {
                    TAIKHOAN tk = db.TAIKHOANs.Select(p => p).Where(p => p.MaTK == matk).First();
                    tk.TinhTrang = "on";

                    KHACHHANG kh = db.KHACHHANGs.Select(p => p).Where(p => p.MaTK == matk).First();
                    kh.MaMay = mamay;

                    db.SaveChanges();

                }
                return matk.Trim();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public void dangXuat(string matk)
        {
            try
            {
                TAIKHOAN tk = db.TAIKHOANs.Select(p => p).Where(p => p.MaTK == matk).First();
                tk.TinhTrang = "off";
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void updateTrangThai(String maTK)
        {
            try
            {
                var taikhoan = db.TAIKHOANs.Select(p => p).Where(p => p.MaTK == maTK).First();
                taikhoan.TinhTrang = "on";
                db.SaveChanges();
            }
            catch (Exception)
            {
            }

        }
        public TAIKHOAN getTAIKHOAN(string maTK)
        {
            try
            {
                return db.TAIKHOANs.Select(p => p).Where(p => p.MaTK == maTK).First();
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
