
namespace RoleKhachHang_form.UserControls
{
    partial class UCThucDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbAnh = new System.Windows.Forms.PictureBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbAnh
            // 
            this.ptbAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbAnh.ImageLocation = "C:\\\\UTEXLMS\\\\Nam3_2022_2023\\\\DBMS\\\\QuanLyPhongNet\\\\image\\\\a.png";
            this.ptbAnh.Location = new System.Drawing.Point(34, 18);
            this.ptbAnh.Name = "ptbAnh";
            this.ptbAnh.Size = new System.Drawing.Size(273, 206);
            this.ptbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAnh.TabIndex = 0;
            this.ptbAnh.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.BackColor = System.Drawing.Color.White;
            this.lblTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.ForeColor = System.Drawing.Color.Black;
            this.lblTen.Location = new System.Drawing.Point(0, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(165, 34);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "label1";
            this.lblTen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGia
            // 
            this.lblGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGia.Location = new System.Drawing.Point(0, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(165, 34);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "label2";
            this.lblGia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.PaleGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Red;
            this.btnThem.Location = new System.Drawing.Point(23, 306);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(118, 36);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.BackColor = System.Drawing.Color.White;
            this.lblMaMon.Enabled = false;
            this.lblMaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMon.ForeColor = System.Drawing.Color.Black;
            this.lblMaMon.Location = new System.Drawing.Point(237, 252);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(83, 25);
            this.lblMaMon.TabIndex = 4;
            this.lblMaMon.Text = "maMon";
            this.lblMaMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaMon.Visible = false;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(265, 308);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(45, 30);
            this.nudSoLuong.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(141, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số lượng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTen);
            this.panel1.Location = new System.Drawing.Point(81, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 34);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblGia);
            this.panel2.Location = new System.Drawing.Point(80, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 34);
            this.panel2.TabIndex = 9;
            // 
            // UCThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.lblMaMon);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.ptbAnh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UCThucDon";
            this.Size = new System.Drawing.Size(347, 354);
            this.Load += new System.EventHandler(this.UCThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbAnh;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
