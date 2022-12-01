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
    public partial class frmDoiMatKhau : Form
    {
        string matk = "";
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string matk)
        {
            this.matk = matk;
            InitializeComponent();
        }

        TaiKhoanDAO db_tk = new TaiKhoanDAO();
        
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMKMoi.Text == txtMKMoi2.Text)
                {
                    TAIKHOAN tk = db_tk.getTAIKHOAN(matk);
                    
                    if (tk.MatKhau == txtMKHT.Text)
                    {
                        db_tk.doiMatKhau(matk, txtMKHT.Text, txtMKMoi.Text);
                        MessageBox.Show("Đổi mật khẩu thành công !!!");
                        this.Close();
                    }    
                    else
                    {
                        MessageBox.Show("Nhập sai mật khẩu cũ !!!");
                    }    
                    
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp !!!");
                }    
            }
            catch (Exception)
            {

                throw;
            }
             
            
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = db_tk.getTAIKHOAN(this.matk).TaiKhoan;
        }
    }
}
