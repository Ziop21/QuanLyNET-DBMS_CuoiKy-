using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogicLayer;
using DataAccessLayer;

namespace RoleKhachHang_form
{
    public partial class Login : Form
    {
        TaiKhoanDAO db_tk = new TaiKhoanDAO();
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        public Login()
        {
            InitializeComponent();
        }
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@taiKhoan", SqlDbType.VarChar).Value = txtTK.Text.Trim();
            cmd.Parameters.Add("@matKhau", SqlDbType.VarChar).Value = txtMK.Text.Trim();
            string status = cmd.ExecuteScalar().ToString();
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            if (status.StartsWith("ad"))
            {
                Main main = new Main(status);
                db_tk.updateTrangThai(status);
                this.Hide();
                main.ShowDialog();
                this.Close();
               
            }
            else if (status.StartsWith("kt") || status.StartsWith("vs"))
            {
                Main main = new Main(status);
                main.thốngKêToolStripMenuItem.Visible = false;
                main.đồĂnThứcUốngToolStripMenuItem.Visible = false;
                main.máyTrạmToolStripMenuItem.Visible = false;
                main.quảnLýCôngViệcToolStripMenuItem.Visible = false;
                main.vaiTròCôngViệcToolStripMenuItem.Visible = false;
                main.kháchHàngToolStripMenuItem.Visible = false;
                main.kháchHàngVãngLaiToolStripMenuItem.Visible = false;
                main.kháchHàngThườngXuyênToolStripMenuItem.Visible = false;
                main.gọiMónToolStripMenuItem.Visible = false;
                main.tàiKhoảnToolStripMenuItem.Text = "Tài khoản cá nhân";
                main.nhânViênToolStripMenuItem.Text = "Thông tin cá nhân";
                main.quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                main.quảnLýTiệmToolStripMenuItem.Visible = false;
                db_tk.updateTrangThai(status);
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else if (status.StartsWith("db"))
            {
                Main main = new Main(status);
                main.thốngKêToolStripMenuItem.Visible = false;
                main.đồĂnThứcUốngToolStripMenuItem.Visible = true;
                main.máyTrạmToolStripMenuItem.Visible = false;
                main.quảnLýCôngViệcToolStripMenuItem.Visible = false;
                main.vaiTròCôngViệcToolStripMenuItem.Visible = false;
                main.kháchHàngToolStripMenuItem.Visible = false;
                main.kháchHàngVãngLaiToolStripMenuItem.Visible = false;
                main.kháchHàngThườngXuyênToolStripMenuItem.Visible = false;
                main.gọiMónToolStripMenuItem.Visible = true;
                main.quảnLýTiệmToolStripMenuItem.Visible = false;
                main.tàiKhoảnToolStripMenuItem.Text = "Tài khoản cá nhân";
                main.nhânViênToolStripMenuItem.Text = "Thông tin cá nhân";
                main.quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
                db_tk.updateTrangThai(status);
                this.Hide();                
                main.ShowDialog();
                this.Close();
            }    
            else if (status.StartsWith("tn"))
            {
                Main main = new Main(status);
                main.thốngKêToolStripMenuItem.Visible = false;
                main.đồĂnThứcUốngToolStripMenuItem.Visible = false;
                main.máyTrạmToolStripMenuItem.Visible = false;
                main.quảnLýCôngViệcToolStripMenuItem.Visible = false;
                main.vaiTròCôngViệcToolStripMenuItem.Visible = false;
                main.kháchHàngToolStripMenuItem.Enabled = true;
                main.kháchHàngVãngLaiToolStripMenuItem.Enabled = true;
                main.kháchHàngThườngXuyênToolStripMenuItem.Enabled = true;
                main.gọiMónToolStripMenuItem.Enabled = true;
                main.tàiKhoảnToolStripMenuItem.Text = "Tài khoản cá nhân";
                main.nhânViênToolStripMenuItem.Text = "Thông tin cá nhân";
                db_tk.updateTrangThai(status);
                this.Hide();
                main.ShowDialog();
                this.Close();
            }    
            else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (tb == DialogResult.OK)
                Application.Exit();
        }
    }
}
