using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoleKhachHang_form.UserControls;
using BussinessLogicLayer;
using DataAccessLayer;

namespace RoleKhachHang_form
{
    public partial class frmThucDon : Form
    {
        ThucDonDAO db_td = new ThucDonDAO();
        GoiMonDAO db_gm = new GoiMonDAO();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        List<UCThucDon> dsUCThucDon = new List<UCThucDon>();
        string maTaiKhoan = null;
        public frmThucDon()
        {
            InitializeComponent();
        }
        public frmThucDon(string maTaiKhoan)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
        }
        private void addListUC(List<UCThucDon> uc)
        {
            panelCenter.Controls.Clear();
            foreach (var item in uc)
            {
                panelCenter.Controls.Add(item);
            }
        }
        private void movelSidePanel(Button button)
        {
            sidePanel.Top = button.Top;
            sidePanel.Height = button.Height;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNha_Click(object sender, EventArgs e)
        {
            movelSidePanel(btnNha);

            List<THUCDON> list = db_td.getAllThucDon();
            panelCenter.Controls.Clear();
            addListTHUCDONtoPANEL(list);

            // addListUC(thucDons);
            clbNuocUong.SetItemChecked(0, false);
            clbNuocUong.SetItemChecked(1, false);
            clbNuocUong.SetItemChecked(2, false);
            clbThucAn.SetItemChecked(0, false);
            clbThucAn.SetItemChecked(1, false);
            clbThucAn.SetItemChecked(2, false);

        }
        private void btnThucAn_Click(object sender, EventArgs e)
        {
            panelCenter.Controls.Clear();
            dsUCThucDon = new List<UCThucDon>();
            clbThucAn.SetItemChecked(0, true);
            clbThucAn.SetItemChecked(1, true);
            clbThucAn.SetItemChecked(2, true);

            clbNuocUong.SetItemChecked(0, false);
            clbNuocUong.SetItemChecked(1, false);
            clbNuocUong.SetItemChecked(2, false);

            movelSidePanel(btnThucAn);
            //List<THUCDON> list = db_td.getTHUCDONsByLoai("ma");
            //panelCenter.Controls.Clear();
            //addListTHUCDONtoPANEL(list);

        }

        private void btnNuocUong_Click(object sender, EventArgs e)
        {
            panelCenter.Controls.Clear();
            dsUCThucDon = new List<UCThucDon>();
            clbNuocUong.SetItemChecked(0, true);
            clbNuocUong.SetItemChecked(1, true);
            clbNuocUong.SetItemChecked(2, true);

            clbThucAn.SetItemChecked(0, false);
            clbThucAn.SetItemChecked(1, false);
            clbThucAn.SetItemChecked(2, false);

            movelSidePanel(btnNuocUong);

            //List<THUCDON> list = db_td.getTHUCDONsByLoai("nu");

            //panelCenter.Controls.Clear();
            //addListTHUCDONtoPANEL(list);
        }

        private void GoiMon_Click(object sender, EventArgs e)
        {

            try
            {
                UCThucDon uCThucDon = (UCThucDon)sender;
                THUCDON td = db_td.findThucDonById(uCThucDon.gm.MaMon);
                GOIMON gm = uCThucDon.gm;
                gm.TrangThai = "";
                gm.MaMon = td.MaMon;
                gm.MaTK = this.maTaiKhoan;
                gm.TongTien = td.GiaTien * (int)uCThucDon.gm.SoLuong;

                dt.Rows.Add(gm.MaTK, gm.MaMon, td.TenMon, td.GiaTien, gm.SoLuong, gm.TrangThai, gm.TongTien, null, null, null, null);

                grdDanhSach.DataSource = dt;

                btnGoiMon.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void frmThucDon_Load(object sender, EventArgs e)
        {
            btnNha_Click(sender, e);

            initGoiMonCuaKhachHangDGV();

            lblTenMon.DataBindings.Add("Text", dt, "tenMon");
            nupSoLuong.DataBindings.Add("Text", dt, "soLuong");
            lblSTTGOIMON.DataBindings.Add("Text", dt, "soThuTuGOIMON");
        }

        private void initGoiMonCuaKhachHangDGV()
        {
            dt = new DataTable();
            dt.Columns.Add("maTK", typeof(string));
            dt.Columns.Add("MaMon", typeof(string));
            dt.Columns.Add("tenMon", typeof(string));
            dt.Columns.Add("giaTien", typeof(int));
            dt.Columns.Add("soLuong", typeof(int));
            dt.Columns.Add("trangThai", typeof(string));
            dt.Columns.Add("tongTien", typeof(string));
            dt.Columns.Add("thoigianGoi", typeof(string));
            dt.Columns.Add("thoigianGiao", typeof(string));
            dt.Columns.Add("soThuTuGOIMON", typeof(int));
            dt.Columns.Add("soThuTu", typeof(int));
            dt.Columns[10].AutoIncrement = true;
            dt.Columns[10].AutoIncrementSeed = 1;

            grdDanhSach.DataSource = dt;
            grdDanhSach.ForeColor = Color.Black;
            grdDanhSach.Columns[10].HeaderText = "STT";
            grdDanhSach.Columns[0].HeaderText = "Mã tài khoản";
            grdDanhSach.Columns[1].HeaderText = "Mã món";
            grdDanhSach.Columns[2].HeaderText = "Tên món";
            grdDanhSach.Columns[3].HeaderText = "Giá tiền";
            grdDanhSach.Columns[4].HeaderText = "Số lượng";
            grdDanhSach.Columns[5].HeaderText = "Trạng thái";
            grdDanhSach.Columns[6].HeaderText = "Tổng tiền";
            grdDanhSach.Columns[7].HeaderText = "Thời gian gọi";
            grdDanhSach.Columns[8].HeaderText = "Thời gian giao";

            grdDanhSach.Columns[0].Visible = false;
            grdDanhSach.Columns[1].Visible = false;
            grdDanhSach.Columns[9].Visible = false;


        }
        private void resetValueOfTable()
        {
            dt.Columns.RemoveAt(10);
            dt.Rows.Clear();
            DataColumn Col = dt.Columns.Add("soThuTu", typeof(int));
            Col.SetOrdinal(10);// to put the column in position 0;
            Col.AutoIncrement = true;
            Col.AutoIncrementSeed = 1;

            grdDanhSach.DataSource = dt;
            grdDanhSach.ForeColor = Color.Black;
            grdDanhSach.Columns[10].HeaderText = "STT";
            grdDanhSach.Columns[0].HeaderText = "Mã tài khoản";
            grdDanhSach.Columns[1].HeaderText = "Mã món";
            grdDanhSach.Columns[2].HeaderText = "Tên món";
            grdDanhSach.Columns[3].HeaderText = "Giá tiền";
            grdDanhSach.Columns[4].HeaderText = "Số lượng";
            grdDanhSach.Columns[5].HeaderText = "Trạng thái";
            grdDanhSach.Columns[6].HeaderText = "Tổng tiền";
            grdDanhSach.Columns[7].HeaderText = "Thời gian gọi";
            grdDanhSach.Columns[8].HeaderText = "Thời gian giao";

            grdDanhSach.Columns[0].Visible = false;
            grdDanhSach.Columns[1].Visible = false;
            grdDanhSach.Columns[9].Visible = false;
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            resetValueOfTable();
            List<KhachHangGoiMon> list = db_gm.getGOIMONsByMaTK(this.maTaiKhoan);
            foreach (var item in list)
            {
                if (item.TrangThai != "done")
                {
                    GOIMON gm = db_gm.getGOIMONBySTT(item.STT);
                    DataRow dataRow = dt.NewRow();
                    //dataRow[0] = 0;
                    dataRow[0] = item.MaTk;
                    dataRow[1] = item.MaMon;
                    dataRow[2] = item.TenMon;
                    dataRow[3] = item.GiaTien;
                    item.SoLuong = gm.SoLuong;
                    dataRow[4] = item.SoLuong;
                    dataRow[5] = item.TrangThai;
                    dataRow[6] = item.TongTien;
                    dataRow[7] = item.TgGoiMon;
                    dataRow[8] = item.TgGiao;
                    dataRow[9] = item.STT;
                    dt.Rows.Add(dataRow);
                }
                
            }
            btnCapNhat.Enabled = false;
            grdDanhSach.DataSource = dt;
            btnGoiMon.Enabled = false;
            btnHuyMon.Enabled = false;
        }

        private void btnGoiMon_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult tl = MessageBox.Show("Bạn có chắc muốn gọi những món vừa thêm", "Gọi Món",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item[5] == "" && Convert.ToInt32(item[4]) > 0)
                            db_gm.goiMon(item[0].ToString(), item[1].ToString(), Convert.ToInt32(item[4]));
                    }
                    btnReload_Click(sender, e);
                    btnCapNhat.Enabled = false;
                    btnHuyMon.Enabled = false;
                    MessageBox.Show("Gọi món thành công!!!");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                int STTGOIMON = Convert.ToInt32(lblSTTGOIMON.Text);
                int SoLuong = Convert.ToInt32(nupSoLuong.Value);
                if (SoLuong > 0)
                {
                    DialogResult tl = MessageBox.Show("Bạn có chắc muốn cập nhật số lượng món đã chọn", "Cập Nhật Số Lượng",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (tl == DialogResult.Yes)
                    {
                        db_gm.capNhatSoLuong(STTGOIMON, SoLuong);
                        MessageBox.Show("Cập nhật thành công");
                    }
                    btnReload_Click(sender, e);
                    btnCapNhat.Enabled = false;
                    btnHuyMon.Enabled = false;
                }
                else
                    MessageBox.Show("Số lượng không hợp lệ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void grdDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnHuyMon.Enabled = true;
        }

        private void btnHuyMon_Click(object sender, EventArgs e)
        {
            try
            {
                int STTGOIMON = Convert.ToInt32(lblSTTGOIMON.Text);
                DialogResult tl = MessageBox.Show("Bạn có chắc muốn hủy gọi món đã chọn", "Hủy Món",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    db_gm.xoaGoiMonBySTT(STTGOIMON);
                    MessageBox.Show("Xóa gọi món thành công");
                }
                btnReload_Click(sender, e);
                btnCapNhat.Enabled = false;
                btnHuyMon.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addListTHUCDONtoPANEL(List<THUCDON> list)
        {
            List<UCThucDon> UCthucDons = new List<UCThucDon>();

            foreach (var item in list)
            {
                UCThucDon uc = new UCThucDon(item);
                UCthucDons.Add(uc);
            }
            foreach (var item in UCthucDons)
            {
                dsUCThucDon.Add(item);
                panelCenter.Controls.Add(item);
                item.Click += new EventHandler(this.GoiMon_Click);
            }
        }
        private void removeListTHUCDONfromPANEL(List<THUCDON> list)
        {
            foreach (var item in list)
            {
                foreach (var i in dsUCThucDon)
                {
                    if (i.GetGOIMON().MaMon == item.MaMon)
                    {
                        this.panelCenter.Controls.Remove(i);
                        dsUCThucDon.Remove(i);
                        break;
                    }
                }
            }
        }
        private void clbThucAn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue == CheckState.Checked)
                {
                    List<THUCDON> list = db_td.getThucDonbyPhanLoai(clbThucAn.Items[e.Index].ToString());
                    addListTHUCDONtoPANEL(list);
                }    
                else if (e.NewValue == CheckState.Unchecked)
                {
                    List<THUCDON> list = db_td.getThucDonbyPhanLoai(clbThucAn.Items[e.Index].ToString());
                   
                    removeListTHUCDONfromPANEL(list);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clbNuocUong_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue == CheckState.Checked)
                {
                    List<THUCDON> list = db_td.getThucDonbyPhanLoai(clbNuocUong.Items[e.Index].ToString());
                    addListTHUCDONtoPANEL(list);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    List<THUCDON> list = db_td.getThucDonbyPhanLoai(clbNuocUong.Items[e.Index].ToString());
                    removeListTHUCDONfromPANEL(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
