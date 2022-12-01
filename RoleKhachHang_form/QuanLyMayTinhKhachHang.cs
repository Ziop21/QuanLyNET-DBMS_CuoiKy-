using BussinessLogicLayer;
using DataAccessLayer;
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
    public partial class QuanLyMayTinhKhachHang : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        DataTable old_dt = null;
        SqlDataReader dr = null;
        TinNhanDAO db_tn = new TinNhanDAO();
        QuanTriDAO db_qt = new QuanTriDAO();

        List<frmChat> listfrmChat = new List<frmChat>();

        string username = null;
        public QuanLyMayTinhKhachHang()
        {
            InitializeComponent();
        }
        public QuanLyMayTinhKhachHang(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        ///string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";


        private void LoadMayTinh()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_QuanLyMayTinhMayTinh";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            IList<string> list = new List<string>();
            dr = cmd.ExecuteReader();
            lblMaMay.DataBindings.Clear();
            lblMaMay.DataBindings.Add("Text", dataGridView1.DataSource, "MaMay");
            lblMaTk.DataBindings.Clear();
            lblMaTk.DataBindings.Add("Text", dataGridView1.DataSource, "MaTK");
            conn.Close();
        }


        private void MayTinh_Load(object sender, EventArgs e)
        {
            LoadMayTinh();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                frmChat frmChat = new frmChat(username, Convert.ToString(dt.Rows[i][3]).ToString());
                frmChat.isThuNgan = true;
                this.listfrmChat.Add(frmChat);
                frmChat.Hide();
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            btnNhanTin.Enabled = false;
            old_dt = dt;
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = old_dt.Columns["MaTK"];
            old_dt.PrimaryKey = keyColumns;
            LoadMayTinh();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool contain = false;
                for (int j = 0; j < old_dt.Rows.Count; j++)
                {
                    if (old_dt.Rows[j]["MaTK"].ToString() == dt.Rows[i]["MaTK"].ToString())
                    {
                        contain = true;
                        break;
                    }
                }
                
                if (contain) 
                    continue;
                else
                {
                    bool exist = false;
                    foreach (var item in listfrmChat)
                    {
                        if (item.matknhan == dt.Rows[i][3].ToString())
                        {
                            item.Close();
                            listfrmChat.Remove(item);
                            item.timer1.Stop();
                            item.Dispose();
                            //item.timer1.Enabled = false;
                            exist = true;
                            break;
                        }    
                    }
                    if (!exist)
                    {
                        frmChat frmChat = new frmChat(username, dt.Rows[i][3].ToString());
                        frmChat.Hide();
                        frmChat.isThuNgan = true;
                        listfrmChat.Add(frmChat);
                    }    
                }    
            }
        }

        private void btnNhanTin_Click(object sender, EventArgs e)
        {
            string matk_khachhang = lblMaTk.Text;
            string mamay_khachhang = lblMaMay.Text;
            foreach (var item in listfrmChat)
            {
                if (item.matknhan == matk_khachhang)
                {
                    item.Show();
                    break;
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNhanTin.Enabled = true;
        }
    }
}
