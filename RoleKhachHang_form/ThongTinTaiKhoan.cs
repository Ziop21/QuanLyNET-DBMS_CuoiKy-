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

namespace RoleKhachHang_form
{
    public partial class frmTTTK : Form
    {
        TaiKhoanDAO db_tk = new TaiKhoanDAO();
        KhachHangDAO db_kh = new KhachHangDAO();
        int second_count = 0;
        int minute_count = 0;
        int hour_count = 0;
        frmChat frmChat = null;
        public string matk;
        CountDownTimer timer = null;

        public frmTTTK()
        {
            InitializeComponent();
        }
        public frmTTTK(string mataikhoan)
        {
             this.second_count = 0;
            this.minute_count = 0;
            this.hour_count = 0;
            InitializeComponent();
            matk = mataikhoan;
            this.frmChat = new frmChat(mataikhoan, db_tk.getMaTKNhanVienQuanTriHienTai());
        }

       

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            db_tk.dangXuat(matk);
            timerTTTK.Enabled = false;
            timer.Stop();
            this.Close();
            this.frmChat.Close();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDoiMatKhau = new frmDoiMatKhau(matk);
            frmDoiMatKhau.Show();
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            frmThucDon frmThucDon = new frmThucDon(this.matk);
            frmThucDon.Show();
        }

        private void btnGiaoTiep_Click(object sender, EventArgs e)
        {
            frmChat.Show();
            this.Closed += (s, args) =>
            {
                frmChat.Close();
            };
        }

        private void frmTTTK_Load(object sender, EventArgs e)
        {
            load(sender, e);
            this.frmChat.Hide();
        }
        private void load(object sender, EventArgs e)
        {
            db_tk.updateTrangThai(matk);
            TAIKHOAN tk = db_tk.getTAIKHOAN(matk);
            lblTaiKhoan.Text = tk.TaiKhoan.ToUpper();
            KHACHHANG kh = db_kh.getKHACHHANG_ByMaTK(tk.MaTK);
            lblPDV.Text = kh.TienGio.ToString() + "VND";

            timerTTTK.Enabled = true;
            timerTTTK.Interval = 1000;
            timer = new CountDownTimer();
            timer.SetTime(kh.ThoiGianConLai, 0);
            timer.Start();
            timer.TimeChanged += () => lblTGCL.Text = timer.TimeLeftMsStr;
            timer.CountDownFinished += () => btnDangXuat_Click(sender, e);
            timer.StepMs = 77;
        }   


        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void timerTTTK_Tick(object sender, EventArgs e)
        {
           
            second_count += 1;
            if (second_count + 1 >= 60)
            {
                second_count = 0;
                minute_count += 1;
            }
            if (minute_count >= 60)
            {
                hour_count += 1;
                minute_count = 0;
            }
            DateTime dateTime = new DateTime(2022, 1, 1, hour_count, minute_count, second_count);
            lblTGSD.Text = String.Format("{0: HH:mm:ss}", dateTime);
        }
    }
}
