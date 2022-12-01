using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoleKhachHang_form
{
    public partial class ThongKe : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        SqlCommand cmd = null;
        DataTable dt = null;
        SqlDataReader dr = null;
        public ThongKe()
        {
            InitializeComponent();
        }
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";

        private void loadThang()
        {
            conn = new SqlConnection(connection);
            string sql = "select distinct MONTH(TgGoiMon) as month from GOIMON";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            IList<string> month = new List<string>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                month.Add(dr["month"].ToString());
            }
            cbThang.DataSource = month;
            conn.Close();
        }

        private void PieChart()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            string sql = "select TenMon, DaBan from THUCDON order by DaBan desc";
            IList<String> name = new List<String>();
            IList<int> quantity = new List<int>();
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr["TenMon"].ToString());
                quantity.Add(Convert.ToInt32(dr["DaBan"].ToString()));
            }
            System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = "Biểu đồ tròn thể hiện tổng số lượng đồ ăn thức uống đã bán ra";
            chartPie.Titles.Add(title);
            chartPie.Series["s1"].IsValueShownAsLabel = true;
            chartPie.Series["s1"].Font = new Font("Arial", 12, FontStyle.Regular);
            int i = 0;
            while (i < name.Count())
            {
                chartPie.Series["s1"].Points.AddXY(name[i], quantity[i]);
                i++;
            }

            conn.Close();
        }

        private void StackedChart()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            IList<string> name = new List<string>();
            IList<int> tongthu = new List<int>();
            IList<int> tongchi = new List<int>();
            IList<int> loinhuan = new List<int>();
            cmd = new SqlCommand("ThongKeChiPhiDATU", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr["PhanLoai"].ToString());
                tongthu.Add(Convert.ToInt32(dr["TongThu"].ToString()));
                tongchi.Add(Convert.ToInt32(dr["TongChi"].ToString()));
                loinhuan.Add(Convert.ToInt32(dr["LoiNhuan"].ToString()));
            }
            System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = "Biểu đồ cột chồng thể hiện lợi nhuận thu về từ việc bán đồ ăn thức uống";
            chartStacked.Titles.Add(title);
            chartStacked.Series["Tổng thu"].IsValueShownAsLabel = true;
            chartStacked.Series["Tổng chi"].IsValueShownAsLabel = true;
            chartStacked.Series["Lợi nhuận"].IsValueShownAsLabel = true;
            for (int i = 0; i < name.Count(); i++)
            {
                chartStacked.Series["Tổng thu"].Points.AddXY(name[i], tongthu[i]);
                chartStacked.Series["Tổng chi"].Points.AddXY(name[i], tongchi[i]);
                chartStacked.Series["Lợi nhuận"].Points.AddXY(name[i], loinhuan[i]);
            }
            conn.Close();
        }

        private void ColumnMonth()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            IList<String> name = new List<String>();
            IList<int> tongthu = new List<int>();
            cmd = new SqlCommand("ThongKeChiPhiDATU_Thang", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@thang", SqlDbType.VarChar).Value = cbThang.SelectedItem.ToString();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr["PhanLoai"].ToString());
                tongthu.Add(Convert.ToInt32(dr["TongThu"].ToString()));
            }
            foreach (var series in column.Series)
            {
                series.Points.Clear();
            }
            System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Font = new Font("Arial", 13, FontStyle.Bold);
            title.Text = "Biểu đồ cột thể hiện tổng số lượng đồ ăn thức uống đã bán ra theo tháng";
            column.Titles.Clear();
            column.Titles.Add(title);
            column.Series["Tổng thu"].IsValueShownAsLabel = true;
            for (int i = 0; i < tongthu.Count(); i++)
            {
                column.Series["Tổng thu"].Points.AddXY(name[i], tongthu[i]);
            }
            conn.Close();
        }


        private void bar()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            IList<String> name = new List<String>();
            IList<int> luong = new List<int>();
            cmd = new SqlCommand("ThongKeLuongThang", conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr["Thang"].ToString());
                luong.Add(Convert.ToInt32(dr["LuongThang"].ToString()));
            }
            System.Windows.Forms.DataVisualization.Charting.Title title = new System.Windows.Forms.DataVisualization.Charting.Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.Text = "Biểu đồ thanh ngang thể hiện chi phí lương trả cho nhân viên theo tháng";
            barChart.Titles.Add(title);
            barChart.Series["Lương tháng"].IsValueShownAsLabel = true;
            for (int i = 0; i < name.Count(); i++)
            {
                barChart.Series["Lương tháng"].Points.AddXY(name[i], luong[i]);
            }
            conn.Close();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

            PieChart();
            loadThang();
            StackedChart();
            bar();

        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            ColumnMonth();
        }
    }
}
