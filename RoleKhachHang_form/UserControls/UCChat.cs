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

namespace RoleKhachHang_form.UserControls
{
    public partial class UCChat : UserControl
    {
        string matkNhan = null;
        string matkGui = null;
        string noidung = null;
        byte KHACHHANGorNHANVIEN = 1;
        TINNHAN tn = new TINNHAN();
        public UCChat()
        {
            InitializeComponent();
        }
        public UCChat(string matkNhan, string matkGui, string noidung, TINNHAN tn, byte flag)
        {
            InitializeComponent();
            this.tn = tn;
            this.matkGui = matkGui;
            this.matkNhan = matkNhan;
            this.noidung = noidung;
            this.KHACHHANGorNHANVIEN = flag;
        }
        public TINNHAN getTINNHAN()
        {
            return this.tn;
        }
        private void UCChat_Load(object sender, EventArgs e)
        {
            if (KHACHHANGorNHANVIEN == 1)
            {
                lblNoiDung.Text = "Khách hàng: " + this.noidung + "  (" + DateTime.Now.ToString() + ")";
            }
            else if (KHACHHANGorNHANVIEN == 2)
            {
                lblNoiDung.Text = "Nhân viên: " + this.noidung + "  (" + DateTime.Now.ToString() + ")";
            }    
           
        }
    }
}
