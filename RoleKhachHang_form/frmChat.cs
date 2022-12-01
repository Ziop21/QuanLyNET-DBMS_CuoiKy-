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
using DataAccessLayer;
using BussinessLogicLayer;

namespace RoleKhachHang_form
{
    public partial class frmChat : Form
    {
        TaiKhoanDAO db_tk = new TaiKhoanDAO();
        TinNhanDAO db_tn = new TinNhanDAO();
        QuanTriDAO db_qt = new QuanTriDAO();
        int timecount = 100000000;
        List<UCChat> listUCChat = new List<UCChat>();

        public string maTK = null;
        public string matknhan = null;
        public bool isThuNgan = false;
        public frmChat()
        {
            InitializeComponent();
        }
        public frmChat(string matk, string matknhan)
        {
            InitializeComponent();
            this.maTK = matk;
            this.matknhan = matknhan;
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (this.isThuNgan == false)
            {
                TINNHAN tn = new TINNHAN();
                tn.MaQuanTri = db_qt.getMaQuanTriByMaTK(this.maTK);
                tn.MaTKGui = this.maTK;
                tn.NoiDung = txtNoiDung.Text;
                tn.MaTKNhan = db_tk.getMaTKNhanVienQuanTriHienTai();
                tn.TgGui = DateTime.Now;
                db_tn.addTinNhan(tn);
                UCChat uc = new UCChat(tn.MaTKNhan, tn.MaTKGui, tn.NoiDung, tn, 1);
                listUCChat.Add(uc);
                this.panelKhungChat.Controls.Add(uc);
                txtNoiDung.Clear();
            }    
            else
            {
                TINNHAN tn = new TINNHAN();
                tn.MaQuanTri = db_qt.getMaQuanTriByMaTK(this.matknhan);
                tn.MaTKGui = this.maTK;
                tn.NoiDung = txtNoiDung.Text;
                tn.MaTKNhan = this.matknhan;
                tn.TgGui = DateTime.Now;
                db_tn.addTinNhan(tn);
                UCChat uc = new UCChat(tn.MaTKNhan, tn.MaTKGui, tn.NoiDung, tn, 2);
                listUCChat.Add(uc);
                this.panelKhungChat.Controls.Add(uc);
                txtNoiDung.Clear();
            }    
            
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDung.Text != "")
                btnGui.Enabled = true;
            else btnGui.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timecount < 0)
                timecount = 100000000;
            else
            {
                if (this.isThuNgan == false)
                {
                    if (db_tk.getMaTKNhanVienQuanTriHienTai() != this.matknhan)
                        this.matknhan = db_tk.getMaTKNhanVienQuanTriHienTai();
                    if (db_tn.getTinNhanLast(db_qt.getMaQuanTriByMaTK(this.maTK), this.matknhan, this.maTK) != null)
                    {
                        TINNHAN tn = db_tn.getTinNhanLast(db_qt.getMaQuanTriByMaTK(this.maTK), this.matknhan, this.maTK);

                        foreach (UCChat item in listUCChat)
                        {
                            if (item.getTINNHAN().NoiDung == tn.NoiDung)
                            {
                                return;
                            }
                        }
                        UCChat uc = new UCChat(tn.MaTKNhan, tn.MaTKGui, tn.NoiDung, tn, 2);
                        listUCChat.Add(uc);
                        this.panelKhungChat.Controls.Add(uc);
                    }
                }
                else
                {
                    if (db_tn.getTinNhanLast(db_qt.getMaQuanTriByMaTK(this.matknhan), this.matknhan, this.maTK) != null)
                    {
                        TINNHAN tn = db_tn.getTinNhanLast(db_qt.getMaQuanTriByMaTK(this.matknhan), this.matknhan, this.maTK);

                        foreach (UCChat item in listUCChat)
                        {
                            if (item.getTINNHAN().NoiDung == tn.NoiDung)
                            {
                                return;
                            }
                        }
                        UCChat uc = new UCChat(tn.MaTKNhan, tn.MaTKGui, tn.NoiDung, tn, 1);
                        listUCChat.Add(uc);
                        this.panelKhungChat.Controls.Add(uc);
                    }
                }
                timecount--;
            }
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
