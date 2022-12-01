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

namespace RoleKhachHang_form
{
    public partial class TaiKhoan : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataReader dr = null;
        public bool isThuNgan = false;
        public bool isAdmin = false;
        public bool isNhanVien = false;
        public TaiKhoan()
        {
            InitializeComponent();
        }

        public TaiKhoan(String s)
        {
            InitializeComponent();
            username = s;
        }
        String username;
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";

        private void LoadTK(int flag = 0)
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_TaiKhoan";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            if (flag == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (!dt.Rows[i][0].ToString().StartsWith("tk"))
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }
            }
            dataGridView1.DataSource = dt;
            txtMTK.DataBindings.Clear();
            txtMTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtTK.DataBindings.Clear();
            txtTK.DataBindings.Add("Text", dataGridView1.DataSource, "TaiKhoan");
            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("Text", dataGridView1.DataSource, "MatKhau");
            dtpNT.DataBindings.Clear();
            dtpNT.DataBindings.Add("Text", dataGridView1.DataSource, "NgayTao");
            IList<string> TT = new List<string>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TT.Add(dr["TinhTrang"].ToString());
            }
            TT = TT.Distinct().ToList();
            cbTT.DataSource = TT;
            conn.Close();
        }

        private void TaiKhoanLoadPQ(String username)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_TaiKhoanLoad", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = username;
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMTK.DataBindings.Clear();
            txtMTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtTK.DataBindings.Clear();
            txtTK.DataBindings.Add("Text", dataGridView1.DataSource, "TaiKhoan");
            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("Text", dataGridView1.DataSource, "MatKhau");
            dtpNT.DataBindings.Clear();
            dtpNT.DataBindings.Add("Text", dataGridView1.DataSource, "NgayTao");
            IList<string> TT = new List<string>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TT.Add(dr["TinhTrang"].ToString());
            }
            TT = TT.Distinct().ToList();
            cbTT.DataSource = TT;
            conn.Close();
        }


        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("vs") || username.StartsWith("tn") || username.StartsWith("kt") || username.StartsWith("db"))
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = true;
                txtMTK.Enabled = false;
                cbTT.Enabled = false;
                dtpNT.Enabled = false;
                this.isNhanVien = true;
                TaiKhoanLoadPQ(username);
            }
            else if (username.Contains("thungan"))
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                this.isThuNgan = true;
                LoadTK(1);
            }    
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                this.isAdmin = true;
                LoadTK();
            }

        }

        private void dtpNT_ValueChanged(object sender, EventArgs e)
        {
            dtpNT.CustomFormat = "dd-MM-yyyy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (this.isThuNgan && !txtMTK.Text.Contains("tk"))
            {
                MessageBox.Show("Mã tài khoản tạo không phải là tài khoản khách hàng");
                return;
            }
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMTK.Text;
            cmd.Parameters.Add("@taiKhoan", SqlDbType.VarChar).Value = txtTK.Text;
            cmd.Parameters.Add("@matKhau", SqlDbType.VarChar).Value = txtMK.Text;
            cmd.Parameters.Add("@ngayTao", SqlDbType.Date).Value = dtpNT.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@tinhTrang", SqlDbType.VarChar).Value = cbTT.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isThuNgan)
                LoadTK(1);
            else if (this.isAdmin)
                LoadTK();
            else if (this.isNhanVien)
                TaiKhoanLoadPQ(this.username);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMTK.Text;
            cmd.Parameters.Add("@taiKhoan", SqlDbType.VarChar).Value = txtTK.Text;
            cmd.Parameters.Add("@matKhau", SqlDbType.VarChar).Value = txtMK.Text;
            cmd.Parameters.Add("@ngayTao", SqlDbType.Date).Value = dtpNT.Value.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@tinhTrang", SqlDbType.VarChar).Value = cbTT.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isThuNgan)
                LoadTK(1);
            else if (this.isAdmin)
                LoadTK();
            else if (this.isNhanVien)
                TaiKhoanLoadPQ(this.username);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaTaiKhoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMTK.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isThuNgan)
                LoadTK(1);
            else if (this.isAdmin)
                LoadTK();
            else if (this.isNhanVien)
                TaiKhoanLoadPQ(this.username);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtMK.Text = "";
            txtMTK.Text = "";
            txtTK.Text = "";
            dtpNT.Value = DateTime.Now;
            cbTT.SelectedIndex = -1;
            txtMTK.ReadOnly = false;
        }
    }
}
