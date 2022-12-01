using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BussinessLogicLayer;


namespace RoleKhachHang_form.UserControls
{
    public partial class UCThucDon : UserControl
    {
        ThucDonDAO db = new ThucDonDAO();
        public string srcImg = null;
        public string tenMon = null;
        public int giaMon = 0;
        public string maMon = null;
        public THUCDON td = new THUCDON();
        public GOIMON gm = new GOIMON();
        public UCThucDon()
        {
            InitializeComponent();
        }
        public THUCDON GetGOIMON()
        {
            return this.td;
        }
        public UCThucDon(THUCDON td)
        {
            InitializeComponent();
            this.td = td;   
            this.gm.MaMon = td.MaMon; 
            this.srcImg = "C:\\UTEXLMS\\Nam3_2022_2023\\DBMS\\QuanLyPhongNet\\" + td.anh;
            this.tenMon = td.TenMon;
            this.giaMon = (int)td.GiaTien;
            this.maMon = td.MaMon;
            addEvent();
        }
        public void addEvent()
        {
            //Khi btnThem click thi se tao ra 1 usercontrol click
            this.btnThem.Click += new EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }
        private void UCThucDon_Load(object sender, EventArgs e)
        {
            ptbAnh.ImageLocation = srcImg;
            lblTen.Text = tenMon;
            lblMaMon.Text = maMon;
            lblGia.Text = String.Format("{0:0,0}", giaMon) + " VND";
            nudSoLuong.Value = 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.gm.SoLuong = (int)nudSoLuong.Value;
        }
    }
}
