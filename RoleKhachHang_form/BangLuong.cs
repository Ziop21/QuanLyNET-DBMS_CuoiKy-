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
    public partial class BangLuong : Form
    {
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        DataTable dt = null;
        SqlConnection conn = null;
        SqlDataReader dr = null;
        public bool isAdmin = false;
        public bool isNhanVien = false;
        public BangLuong()
        {
            InitializeComponent();
        }

        public BangLuong(String s)
        {
            InitializeComponent();
            username = s;
        }
        String username;
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";

        private void LoadBL()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_BangLuong";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtML.ReadOnly = true;
            txtML.DataBindings.Clear();
            txtML.DataBindings.Add("Text", dataGridView1.DataSource, "MaLuong");
            txtVT.DataBindings.Clear();
            txtVT.DataBindings.Add("Text", dataGridView1.DataSource, "VaiTro");
            txtLTG.DataBindings.Clear();
            txtLTG.DataBindings.Add("Text", dataGridView1.DataSource, "LuongTheoGio");
            IList<string> listHT = new List<string>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listHT.Add(dr[3].ToString());
            }
            listHT = listHT.Distinct().ToList();
            cbHT.DataSource = listHT;
            cbHT.DisplayMember = "HinhThuc";
            conn.Close();
        }
        private void loadBL_PQ(string username)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_BangLuongLoad", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = username;
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtML.ReadOnly = true;
            txtML.DataBindings.Clear();
            txtML.DataBindings.Add("Text", dataGridView1.DataSource, "MaLuong");
            txtVT.DataBindings.Clear();
            txtVT.DataBindings.Add("Text", dataGridView1.DataSource, "VaiTro");
            txtLTG.DataBindings.Clear();
            txtLTG.DataBindings.Add("Text", dataGridView1.DataSource, "LuongTheoGio");
            IList<string> listHT = new List<string>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listHT.Add(dr[3].ToString());
            }
            listHT = listHT.Distinct().ToList();
            cbHT.DataSource = listHT;
            cbHT.DisplayMember = "HinhThuc";
            conn.Close();
        }

        private void BangLuong_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("vs") || username.StartsWith("tn") || username.StartsWith("kt") || username.StartsWith("db"))
            {
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnLuongAll.Visible = false;
                this.isNhanVien = true;
                loadBL_PQ(this.username);
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnLuongAll.Visible = true;
                btnLuong.Visible = false;
                this.isAdmin = true;
                LoadBL();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemBangLuong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maLuong", SqlDbType.VarChar).Value = txtML.Text;
            cmd.Parameters.Add("@vaiTro", SqlDbType.NVarChar).Value = txtVT.Text;
            cmd.Parameters.Add("@luongTheoGio", SqlDbType.Real).Value = float.Parse(txtLTG.Text);
            cmd.Parameters.Add("@hinhThuc", SqlDbType.NVarChar).Value = cbHT.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isAdmin)
                LoadBL();
            else if (this.isNhanVien)
                loadBL_PQ(username);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaBangLuong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maLuong", SqlDbType.VarChar).Value = txtML.Text;
            cmd.Parameters.Add("@vaiTro", SqlDbType.NVarChar).Value = txtVT.Text;
            cmd.Parameters.Add("@luongTheoGio", SqlDbType.Real).Value = float.Parse(txtLTG.Text);
            cmd.Parameters.Add("@hinhThuc", SqlDbType.NVarChar).Value = cbHT.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isAdmin)
                LoadBL();
            else if (this.isNhanVien)
                loadBL_PQ(username);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaBangLuong", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maLuong", SqlDbType.VarChar).Value = txtML.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isAdmin)
                LoadBL();
            else if (this.isNhanVien)
                loadBL_PQ(username);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtML.Text = "";
            txtLTG.Text = "";
            txtVT.Text = "";
            cbHT.SelectedIndex = 0;
            txtML.ReadOnly = false;
        }

        private void txtML_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_LuongThangNhanVien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matk", SqlDbType.VarChar).Value = username;
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLuongAll_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_LuongThangNhanVienAll", conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
