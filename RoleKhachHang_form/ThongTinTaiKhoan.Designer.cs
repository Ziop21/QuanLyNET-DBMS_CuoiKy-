
namespace RoleKhachHang_form
{
    partial class frmTTTK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTTK));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPDV = new System.Windows.Forms.Label();
            this.lblTGSD = new System.Windows.Forms.Label();
            this.lblTGCL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDangXuat = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnThucDon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGiaoTiep = new System.Windows.Forms.Button();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerTTTK = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblPDV);
            this.panel1.Controls.Add(this.lblTGSD);
            this.panel1.Controls.Add(this.lblTGCL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 158);
            this.panel1.TabIndex = 0;
            // 
            // lblPDV
            // 
            this.lblPDV.AutoSize = true;
            this.lblPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDV.Location = new System.Drawing.Point(298, 94);
            this.lblPDV.Name = "lblPDV";
            this.lblPDV.Size = new System.Drawing.Size(61, 20);
            this.lblPDV.TabIndex = 11;
            this.lblPDV.Text = "lblPDV";
            this.lblPDV.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblTGSD
            // 
            this.lblTGSD.AutoSize = true;
            this.lblTGSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGSD.Location = new System.Drawing.Point(294, 32);
            this.lblTGSD.Name = "lblTGSD";
            this.lblTGSD.Size = new System.Drawing.Size(73, 20);
            this.lblTGSD.TabIndex = 10;
            this.lblTGSD.Text = "lblTGSD";
            // 
            // lblTGCL
            // 
            this.lblTGCL.AutoSize = true;
            this.lblTGCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGCL.Location = new System.Drawing.Point(298, 64);
            this.lblTGCL.Name = "lblTGCL";
            this.lblTGCL.Size = new System.Drawing.Size(71, 20);
            this.lblTGCL.TabIndex = 9;
            this.lblTGCL.Text = "lblTGCL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(135, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phí dịch vụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(133, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thời gian còn lại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(133, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thời gian sử dụng:";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(8, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 126);
            this.panel2.TabIndex = 1;
            // 
            // lblDangXuat
            // 
            this.lblDangXuat.AutoSize = true;
            this.lblDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuat.Location = new System.Drawing.Point(60, 109);
            this.lblDangXuat.Name = "lblDangXuat";
            this.lblDangXuat.Size = new System.Drawing.Size(84, 20);
            this.lblDangXuat.TabIndex = 1;
            this.lblDangXuat.Text = "Đăng xuất";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.BackgroundImage")));
            this.btnDangXuat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Location = new System.Drawing.Point(56, 21);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(98, 88);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnThucDon);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btnGiaoTiep);
            this.panel3.Controls.Add(this.btnDangXuat);
            this.panel3.Controls.Add(this.lblDangXuat);
            this.panel3.Controls.Add(this.btnDoiMK);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 237);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 292);
            this.panel3.TabIndex = 3;
            // 
            // btnThucDon
            // 
            this.btnThucDon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThucDon.BackgroundImage")));
            this.btnThucDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucDon.Location = new System.Drawing.Point(56, 164);
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Size = new System.Drawing.Size(98, 88);
            this.btnThucDon.TabIndex = 8;
            this.btnThucDon.UseVisualStyleBackColor = true;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Thực đơn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giao tiếp";
            // 
            // btnGiaoTiep
            // 
            this.btnGiaoTiep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGiaoTiep.BackgroundImage")));
            this.btnGiaoTiep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGiaoTiep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiaoTiep.Location = new System.Drawing.Point(238, 164);
            this.btnGiaoTiep.Name = "btnGiaoTiep";
            this.btnGiaoTiep.Size = new System.Drawing.Size(98, 88);
            this.btnGiaoTiep.TabIndex = 5;
            this.btnGiaoTiep.UseVisualStyleBackColor = true;
            this.btnGiaoTiep.Click += new System.EventHandler(this.btnGiaoTiep_Click);
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoiMK.BackgroundImage")));
            this.btnDoiMK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoiMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMK.Location = new System.Drawing.Point(241, 21);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(98, 88);
            this.btnDoiMK.TabIndex = 4;
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(234, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đổi mật khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tài khoản:";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaiKhoan.Location = new System.Drawing.Point(106, 19);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(136, 20);
            this.lblTaiKhoan.TabIndex = 5;
            this.lblTaiKhoan.Text = "TAIKHOANTEST";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(18, 555);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 269);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // timerTTTK
            // 
            this.timerTTTK.Enabled = true;
            this.timerTTTK.Tick += new System.EventHandler(this.timerTTTK_Tick);
            // 
            // frmTTTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 874);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Location = new System.Drawing.Point(1210, 0);
            this.MaximizeBox = false;
            this.Name = "frmTTTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ThongTinTaiKhoan";
            this.Load += new System.EventHandler(this.frmTTTK_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDangXuat;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGiaoTiep;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerTTTK;
        private System.Windows.Forms.Label lblPDV;
        private System.Windows.Forms.Label lblTGSD;
        private System.Windows.Forms.Label lblTGCL;
    }
}