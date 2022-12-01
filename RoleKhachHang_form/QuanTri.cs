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
    public partial class QuanTri : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        public QuanTri()
        {
            InitializeComponent();
        }
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";

        private void loadQT()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_QuanTri";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMQT.ReadOnly = true;
            txtMQT.DataBindings.Clear();
            txtMQT.DataBindings.Add("Text", dataGridView1.DataSource, "MaQuanTri");
            txtAdmin.DataBindings.Clear();
            txtAdmin.DataBindings.Add("Text", dataGridView1.DataSource, "MaTKAdmin");
            txtMTKKH.DataBindings.Clear();
            txtMTKKH.DataBindings.Add("Text", dataGridView1.DataSource, "MaTKKhachHang");
            dtpBD.DataBindings.Clear();
            dtpBD.DataBindings.Add("Text", dataGridView1.DataSource, "TgBatDau");
            dtpKT.DataBindings.Clear();
            dtpKT.DataBindings.Add("Text", dataGridView1.DataSource, "TgKetThuc");
            txtGC.DataBindings.Clear();
            txtGC.DataBindings.Add("Text", dataGridView1.DataSource, "GhiChu");
            conn.Close();
        }
        private void QuanTri_Load(object sender, EventArgs e)
        {
            loadQT();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemQuanTri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTKAdmin", SqlDbType.VarChar).Value = txtAdmin.Text;
            cmd.Parameters.Add("@maTKKhachHang", SqlDbType.VarChar).Value = txtMTKKH.Text;
            cmd.Parameters.Add("@tgBatDau", SqlDbType.DateTime).Value = dtpBD.Value.ToString();
            cmd.Parameters.Add("@tgKetThuc", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(dtpKT.Value.ToString()) ? dtpKT.Value.ToString() : (object)DBNull.Value;
            cmd.Parameters.Add("@ghiChu", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtGC.Text) ? txtGC.Text : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadQT();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaQuanTri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd = new SqlCommand("sp_ThemQuanTri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maQuanTri", SqlDbType.VarChar).Value = txtMQT.Text;
            cmd.Parameters.Add("@maTKAdmin", SqlDbType.VarChar).Value = txtAdmin.Text;
            cmd.Parameters.Add("@maTKKhachHang", SqlDbType.VarChar).Value = txtMTKKH.Text;
            cmd.Parameters.Add("@tgBatDau", SqlDbType.DateTime).Value = dtpBD.Value.ToString();
            cmd.Parameters.Add("@tgKetThuc", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(dtpKT.Value.ToString()) ? dtpKT.Value.ToString() : (object)DBNull.Value;
            cmd.Parameters.Add("@ghiChu", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtGC.Text) ? txtGC.Text : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadQT();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaQuanTri", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maQuanTri", SqlDbType.VarChar).Value = txtMQT.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadQT();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtAdmin.Text = "";
            txtMTKKH.Text = "";
            txtMQT.Text = "";
            txtGC.Text = "";
            dtpBD.Text = "1970/01/01";
            dtpKT.Text = "1970/01/01";
        }
    }
}
