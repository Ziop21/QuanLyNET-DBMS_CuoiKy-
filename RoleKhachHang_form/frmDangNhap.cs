using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BussinessLogicLayer;

namespace RoleKhachHang_form
{
    public partial class frmDangNhap : Form
    {
        NETEntities db = new NETEntities();
        TaiKhoanDAO db_tk = new TaiKhoanDAO();
        KhachHangDAO db_kh = new KhachHangDAO();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string maTK = db_tk.dangNhap(txtTaiKhoan.Text, txtMatKhau.Text, lblMaMay.Text);
                if (maTK == "Sai mk" || maTK == "Sai tk")
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!");
                }  
                else if (maTK == "Loi" || maTK.Length > 5)
                {
                    MessageBox.Show(maTK);
                }
                else
                {
                    frmTTTK frmTTTK = new frmTTTK(maTK);
                    frmTTTK.Show();
                    this.Hide();
                    frmTTTK.Closed += (s, args) =>
                    {
                        //KHACHHANG kh = db_kh.getKHACHHANG_ByMaTK(maTK);
                        //kh.MaMay = "";
                        //db.SaveChanges();
                        this.Show();
                        txtMatKhau.Clear();
                        txtTaiKhoan.Clear();
                        txtTaiKhoan.Focus();
                        db.Dispose();
                        db = new NETEntities();
                        db_tk = new TaiKhoanDAO();
                        db_kh = new KhachHangDAO();
                    };

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!!!");
            }
            
        }

        private void txtTaiKhoam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
