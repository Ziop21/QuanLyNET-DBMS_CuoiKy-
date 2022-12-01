using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoleKhachHang_form
{
    public partial class ThucDon : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        IDataReader dr = null;
        public ThucDon()
        {
            InitializeComponent();
        }
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LoadTD()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_ThucDon";
            IList<string> cate = new List<string>();
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtMM.ReadOnly = true;
            txtMM.DataBindings.Clear();
            txtMM.DataBindings.Add("Text", dataGridView1.DataSource, "MaMon");
            txtTM.DataBindings.Clear();
            txtTM.DataBindings.Add("Text", dataGridView1.DataSource, "TenMon");
            txtTNL.DataBindings.Clear();
            txtTNL.DataBindings.Add("Text", dataGridView1.DataSource, "TienNguyenLieu");
            txtGT.DataBindings.Clear();
            txtGT.DataBindings.Add("Text", dataGridView1.DataSource, "GiaTien");
            txtDB.DataBindings.Clear();
            txtDB.DataBindings.Add("Text", dataGridView1.DataSource, "DaBan");
            txtCL.DataBindings.Clear();
            txtCL.DataBindings.Add("Text", dataGridView1.DataSource, "ConLai");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cate.Add(dr["PhanLoai"].ToString());
            }
            cate = cate.Distinct().ToList();
            cbCategory.DataSource = cate;
            conn.Close();
        }

        private void ThucDon_Load(object sender, EventArgs e)
        {
            LoadTD();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemThucDon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maMon", SqlDbType.VarChar).Value = txtMM.Text;
            cmd.Parameters.Add("@tenMon", SqlDbType.NVarChar).Value = txtTM.Text;
            cmd.Parameters.Add("@tienNguyenLieu", SqlDbType.Real).Value = float.Parse(txtTNL.Text);
            cmd.Parameters.Add("@giaTien", SqlDbType.Real).Value = float.Parse(txtGT.Text);
            cmd.Parameters.Add("@daBan", SqlDbType.Int).Value = Int32.Parse(txtDB.Text);
            cmd.Parameters.Add("@conLai", SqlDbType.Int).Value = Int32.Parse(txtCL.Text);
            cmd.Parameters.Add("@anh", SqlDbType.VarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@phanLoai", SqlDbType.VarChar).Value = cbCategory.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadTD();
        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaThucDon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maMon", SqlDbType.VarChar).Value = txtMM.Text;
            cmd.Parameters.Add("@tenMon", SqlDbType.NVarChar).Value = txtTM.Text;
            cmd.Parameters.Add("@tienNguyenLieu", SqlDbType.Real).Value = float.Parse(txtTNL.Text);
            cmd.Parameters.Add("@giaTien", SqlDbType.Real).Value = float.Parse(txtGT.Text);
            cmd.Parameters.Add("@daBan", SqlDbType.Int).Value = Int32.Parse(txtDB.Text);
            cmd.Parameters.Add("@conLai", SqlDbType.Int).Value = Int32.Parse(txtCL.Text);
            cmd.Parameters.Add("@anh", SqlDbType.VarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@phanLoai", SqlDbType.VarChar).Value = cbCategory.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadTD();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaThucDon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maMon", SqlDbType.VarChar).Value = txtMM.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadTD();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtMM.Text = "";
            txtTM.Text = "";
            txtTNL.Text = "0";
            txtGT.Text = "0";
            txtDB.Text = "";
            txtCL.Text = "";
            txtMM.ReadOnly = false;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
    }
}
