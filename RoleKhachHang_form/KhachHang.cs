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
    public partial class KhachHang : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataReader dr = null;
        public KhachHang()
        {
            InitializeComponent();
        }

        public KhachHang(String s)
        {
            InitializeComponent();
            username = s;
        }
        String username;
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";

        void loadKH()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_KhachHang";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMKH.ReadOnly = true;
            txtMKH.DataBindings.Clear();
            txtMKH.DataBindings.Add("Text", dataGridView1.DataSource, "MaKH");
            txtMTK.DataBindings.Clear();
            txtMTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtMM.DataBindings.Clear();
            txtMM.DataBindings.Add("Text", dataGridView1.DataSource, "MaMay");
            txtMMC.DataBindings.Clear();
            txtMMC.DataBindings.Add("Text", dataGridView1.DataSource, "MaMayCu");
            txtTG.DataBindings.Clear();
            txtTGCL.DataBindings.Add("Text", dataGridView1.DataSource, "ThoiGianConLai");
            txtTTG.DataBindings.Clear();
            txtTG.DataBindings.Add("Text", dataGridView1.DataSource, "TienGio");
            txtTGCL.DataBindings.Clear();
            txtTTG.DataBindings.Add("Text", dataGridView1.DataSource, "TongThoiGian");
            conn.Close();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("vs") || username.StartsWith("tn") || username.StartsWith("kt"))
            {
                button2.Enabled = true;
                btnAdd.Enabled = true;
                btnNapTien.Visible = true;
                txtTien.Visible = true;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                button2.Enabled = true;
            }
            loadKH();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maKH", SqlDbType.VarChar).Value = txtMKH.Text;  
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMTK.Text;
            cmd.Parameters.Add("@maMay", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtMM.Text) ? txtMM.Text : (object)DBNull.Value;

            cmd.Parameters.Add("@maMayCu", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtMMC.Text) ? txtMMC.Text : (object)DBNull.Value;

            cmd.Parameters.Add("@thoiGianConLai", SqlDbType.Float).Value = !string.IsNullOrEmpty(txtTGCL.Text) ? float.Parse(txtTGCL.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@tienGio", SqlDbType.Real).Value = !string.IsNullOrEmpty(txtTG.Text) ? float.Parse(txtTG.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@tongThoiGian", SqlDbType.Float).Value = !string.IsNullOrEmpty(txtTTG.Text) ? float.Parse(txtTTG.Text) : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadKH();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maKH", SqlDbType.VarChar).Value = txtMKH.Text;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMTK.Text;
            cmd.Parameters.Add("@maMay", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtMM.Text) ? txtMM.Text : (object)DBNull.Value;

            cmd.Parameters.Add("@maMayCu", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtMMC.Text) ? txtMMC.Text : (object)DBNull.Value;

            cmd.Parameters.Add("@thoiGianConLai", SqlDbType.Float).Value = !string.IsNullOrEmpty(txtTGCL.Text) ? float.Parse(txtTGCL.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@tienGio", SqlDbType.Real).Value = float.Parse(txtTG.Text);
            cmd.Parameters.Add("@tongThoiGian", SqlDbType.Float).Value = float.Parse(txtTTG.Text);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadKH();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaKhachHang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maKH", SqlDbType.VarChar).Value = txtMKH.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadKH();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtMKH.Text = "";
            txtMM.Text = "";
            txtTTG.Text = "";
            txtMTK.Text = "";
            txtTGCL.Text = "";
            txtMMC.Text = "";
            txtTG.Text = "";
            txtMKH.ReadOnly = false;
        }

        private void btnNapTien_Click(object sender, EventArgs e)
        {

        }
    }
}
