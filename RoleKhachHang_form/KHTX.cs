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
    public partial class KHTX : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataReader dr = null;
        public KHTX()
        {
            InitializeComponent();
        }

        public KHTX(String s)
        {
            InitializeComponent();
            username = s;
        }
        String username;
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";

        private void loadTX()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_KHTX";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtID.ReadOnly = true;
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dataGridView1.DataSource, "ID");
            txtMKH.DataBindings.Clear();
            txtMKH.DataBindings.Add("Text", dataGridView1.DataSource, "MaKH");
            txtSTN.DataBindings.Clear();
            txtSTN.DataBindings.Add("Text", dataGridView1.DataSource, "SoTienNap");
            txtHT.DataBindings.Clear();
            txtHT.DataBindings.Add("Text", dataGridView1.DataSource, "HoTen");
            txtNS.DataBindings.Clear();
            txtNS.DataBindings.Add("Text", dataGridView1.DataSource, "NgaySinh");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dataGridView1.DataSource, "SDT");
            conn.Close();
        }
        private void KHTX_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("vs") || username.StartsWith("tn") || username.StartsWith("kt"))
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnEdit.Enabled = true;
                
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            loadTX();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemKHTX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maKH", SqlDbType.VarChar).Value = txtMKH.Text;        
            cmd.Parameters.Add("@soTienNap", SqlDbType.Float).Value = !string.IsNullOrEmpty(txtSTN.Text) ? float.Parse(txtSTN.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@hoTen", SqlDbType.VarChar).Value = txtHT.Text;
            cmd.Parameters.Add("@ngaySinh", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(txtHT.Text) ? float.Parse(txtHT.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = txtSDT.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadTX();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaKHTX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txtID.Text);
            cmd.Parameters.Add("@maKH", SqlDbType.VarChar).Value = txtMKH.Text;
            cmd.Parameters.Add("@soTienNap", SqlDbType.Float).Value = !string.IsNullOrEmpty(txtSTN.Text) ? float.Parse(txtSTN.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@hoTen", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtHT.Text) ? txtHT.Text : (object)DBNull.Value;
            cmd.Parameters.Add("@ngaySinh", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(txtNS.Text) ? DateTime.Parse(txtNS.Text) : (object)DBNull.Value;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = !string.IsNullOrEmpty(txtSDT.Text) ? txtSDT.Text : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadTX();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaKHTX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            loadTX();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtMKH.Text = "";
            txtSTN.Text = "";
            txtHT.Text = "";
            txtSDT.Text = "";
            txtNS.Text = "";
            txtMKH.ReadOnly = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
