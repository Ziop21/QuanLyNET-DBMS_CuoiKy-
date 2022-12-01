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
    public partial class GoiMon : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        string username;
        bool isAdmin = false;
        bool isThuNgan = false;
        bool isDauBep = false;
        bool isDSTT = false;
        bool isDSDN = false;
        bool isDSDG = false;
        public GoiMon()
        {
            InitializeComponent();
        }
        public GoiMon(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";

        private void loadGM()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_GoiMon";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtSTT.ReadOnly = true;
            txtSTT.DataBindings.Clear();
            txtSTT.DataBindings.Add("Text", dataGridView1.DataSource, "STT");
            txtMaTK.DataBindings.Clear();
            txtMaTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("Text", dataGridView1.DataSource, "MaMon");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", dataGridView1.DataSource, "TongTien");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");
            cbbTrangThai.DataBindings.Clear();
            cbbTrangThai.DataBindings.Add("Text", dataGridView1.DataSource, "TrangThai");
            dtpTGGoiMon.DataBindings.Clear();
            dtpTGGoiMon.DataBindings.Add("Text", dataGridView1.DataSource, "TgGoiMon");
            dtpTGGiao.DataBindings.Clear();
            dtpTGGiao.DataBindings.Add("Text", dataGridView1.DataSource, "TgGiao");
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemGoiMon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMaTK.Text;
            cmd.Parameters.Add("@maMon", SqlDbType.VarChar).Value = txtMaMon.Text;
            cmd.Parameters.Add("@tongTien", SqlDbType.Real).Value = txtTongTien.Text;
            cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = txtSoLuong.Text;
            cmd.Parameters.Add("@trangThai", SqlDbType.VarChar).Value = cbbTrangThai.Text;
            cmd.Parameters.Add("@tgGoiMon", SqlDbType.DateTime).Value = dtpTGGoiMon.Value.ToString();
            cmd.Parameters.Add("@tgGiao", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(dtpTGGiao.Value.ToString()) ? dtpTGGiao.Value.ToString() : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isAdmin)
                loadGM();
            else
                loadGM_ThuNgan();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaGoiMon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@stt", SqlDbType.Int).Value = txtSTT.Text;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = txtMaTK.Text;
            cmd.Parameters.Add("@maMon", SqlDbType.VarChar).Value = txtMaMon.Text;
            cmd.Parameters.Add("@tongTien", SqlDbType.Real).Value = txtTongTien.Text;
            cmd.Parameters.Add("@soLuong", SqlDbType.Int).Value = txtSoLuong.Text;
            cmd.Parameters.Add("@trangThai", SqlDbType.VarChar).Value = cbbTrangThai.Text;
            cmd.Parameters.Add("@tgGoiMon", SqlDbType.DateTime).Value = dtpTGGoiMon.Value.ToString();
            cmd.Parameters.Add("@tgGiao", SqlDbType.DateTime).Value = !string.IsNullOrEmpty(dtpTGGiao.Value.ToString()) ? dtpTGGiao.Value.ToString() : (object)DBNull.Value;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            if (this.isAdmin)
                loadGM();
            else
                loadGM_ThuNgan();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaGoiMon", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@stt", SqlDbType.Int).Value = txtSTT.Text;
            adapter = new SqlDataAdapter(cmd);
            if (adapter != null)
                adapter.Fill(dt);
            if (this.isAdmin)
                loadGM();
            else
                loadGM_ThuNgan();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            txtSTT.Text = "";
            txtMaTK.Text = "";
            txtMaMon.Text = "";
            txtSoLuong.Text = "";
            txtTongTien.Text = "";
            cbbTrangThai.Text = "";
            dtpTGGoiMon.Text = DateTime.Today.Date.ToString();
            dtpTGGiao.Text = DateTime.Today.Date.ToString();
        }
        public void loadGM_ThuNgan(int flag = 0)
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_GoiMon";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (flag == 1)
                {
                    if (Convert.ToDateTime(dt.Rows[i][6]).Date.ToString() != DateTime.Now.Date.ToString() || !dt.Rows[i][5].ToString().Contains("Thu tien"))
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }
                else if (flag == 2)
                {
                    if (Convert.ToDateTime(dt.Rows[i][6]).Date.ToString() != DateTime.Now.Date.ToString() || !dt.Rows[i][5].ToString().Contains("Dang giao"))
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }
                else
                {
                    if (Convert.ToDateTime(dt.Rows[i][6]).Date.ToString() != DateTime.Now.Date.ToString())
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }
               
            }

           
            
            dataGridView1.DataSource = dt;
            txtSTT.ReadOnly = true;
            txtSTT.DataBindings.Clear();
            txtSTT.DataBindings.Add("Text", dataGridView1.DataSource, "STT");
            txtMaTK.DataBindings.Clear();
            txtMaTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("Text", dataGridView1.DataSource, "MaMon");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", dataGridView1.DataSource, "TongTien");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");
            cbbTrangThai.DataBindings.Clear();
            cbbTrangThai.DataBindings.Add("Text", dataGridView1.DataSource, "TrangThai");
            dtpTGGoiMon.DataBindings.Clear();
            dtpTGGoiMon.DataBindings.Add("Text", dataGridView1.DataSource, "TgGoiMon");
            dtpTGGiao.DataBindings.Clear();
            dtpTGGiao.DataBindings.Add("Text", dataGridView1.DataSource, "TgGiao");
            conn.Close();
        }
        public void loadGM_DauBep(int flag = 0)
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_GoiMon";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (flag == 1)
                {
                    if (Convert.ToDateTime(dt.Rows[i][6]).Date.ToString() != DateTime.Now.Date.ToString() || !dt.Rows[i][5].ToString().Contains("Dang nau"))
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }
                else
                {
                    if (Convert.ToDateTime(dt.Rows[i][6]).Date.ToString() != DateTime.Now.Date.ToString())
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                    }
                }

            }

            dataGridView1.DataSource = dt;
            txtSTT.ReadOnly = true;
            txtSTT.DataBindings.Clear();
            txtSTT.DataBindings.Add("Text", dataGridView1.DataSource, "STT");
            txtMaTK.DataBindings.Clear();
            txtMaTK.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("Text", dataGridView1.DataSource, "MaMon");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", dataGridView1.DataSource, "TongTien");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");
            cbbTrangThai.DataBindings.Clear();
            cbbTrangThai.DataBindings.Add("Text", dataGridView1.DataSource, "TrangThai");
            dtpTGGoiMon.DataBindings.Clear();
            dtpTGGoiMon.DataBindings.Add("Text", dataGridView1.DataSource, "TgGoiMon");
            dtpTGGiao.DataBindings.Clear();
            dtpTGGiao.DataBindings.Add("Text", dataGridView1.DataSource, "TgGiao");
            conn.Close();
        }
        private void GoiMon_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("tn"))
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = true;
                txtMaMon.Enabled = false;
                txtMaTK.Enabled = false;
                txtSoLuong.Enabled = false;
                txtSTT.Enabled = false;
                txtTongTien.Enabled = false;
                dtpTGGiao.Enabled = false;
                dtpTGGoiMon.Enabled = false;
                btnDSCanGiao.Visible = true;
                cbbTrangThai.Items.Clear();
                string[] list = { "Thu tien...", "Dang nau...", "Done..."};
                cbbTrangThai.Items.AddRange(list);
                loadGM_ThuNgan();
                this.isThuNgan = true;
            }
            else if (username.StartsWith("db"))
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = true;
                txtMaMon.Enabled = false;
                txtMaTK.Enabled = false;
                txtSoLuong.Enabled = false;
                txtSTT.Enabled = false;
                txtTongTien.Enabled = false;
                dtpTGGiao.Enabled = false;
                dtpTGGoiMon.Enabled = false;
                cbbTrangThai.Items.Clear();
                string[] list = {"Dang nau...", "Dang giao..." };
                cbbTrangThai.Items.AddRange(list);
                loadGM_DauBep();
                btnDSThuTien.Text = "DS cần nấu";
                this.isDauBep = true;
            }
            else
            {
                btnDSCanGiao.Visible = false;
                btnDSThuTien.Visible = false;
                this.isAdmin = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                loadGM();
            }
        }

        private void btnDSThuTien_Click(object sender, EventArgs e)
        {
            if (this.isDauBep)
            {
                if (this.isDSDN)
                {
                    
                    loadGM_DauBep(0);
                    btnDSThuTien.Text = "DS đang nấu";
                    this.isDSDN = false;
                }
                else
                {
                    btnDSThuTien.Text = "DS gọi món";
                    loadGM_DauBep(1);
                    this.isDSDN = true;
                }
            }
          
            if (this.isThuNgan)
            {
                if (this.isDSTT)
                {
                    btnDSThuTien.Text = "DS thu tiền";
                    loadGM_ThuNgan(0);
                    this.isDSTT = false;
                    cbbTrangThai.Items.Clear();
                    string[] list = { "Thu tien...", "Dang nau...", "Done..."};
                    cbbTrangThai.Items.AddRange(list);
                }
                else
                {
                    btnDSThuTien.Text = "DS gọi món";
                    loadGM_ThuNgan(1);
                    this.isDSTT = true;
                    cbbTrangThai.Items.Clear();
                    string[] list = { "Thu tien...", "Dang nau..."};
                    cbbTrangThai.Items.AddRange(list);
                }
            }    
              

        }

        private void btnDSCanGiao_Click(object sender, EventArgs e)
        {

            if (this.isDSDG)
            {
                btnDSCanGiao.Text = "DS cần giao";
                loadGM_ThuNgan(0);
                cbbTrangThai.Items.Clear();
                string[] list = { "Thu tien...", "Dang nau...", "Done..." };
                cbbTrangThai.Items.AddRange(list);

                this.isDSDG = false;
            }
            else
            {
                btnDSCanGiao.Text = "DS gọi món";                
                loadGM_ThuNgan(2);
                cbbTrangThai.Items.Clear();
                string[] list = {"Dang giao...", "Done..." };
                cbbTrangThai.Items.AddRange(list);
                this.isDSDG = true;
            }
        }
    }
}
