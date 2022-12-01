
namespace RoleKhachHang_form
{
    partial class frmThucDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.clbNuocUong = new System.Windows.Forms.CheckedListBox();
            this.clbThucAn = new System.Windows.Forms.CheckedListBox();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.btnNuocUong = new System.Windows.Forms.Button();
            this.btnThucAn = new System.Windows.Forms.Button();
            this.btnNha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnHuyMon = new System.Windows.Forms.Button();
            this.btnGoiMon = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSTTGOIMON = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.nupSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.grdDanhSach = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.panelLeft.Controls.Add(this.clbNuocUong);
            this.panelLeft.Controls.Add(this.clbThucAn);
            this.panelLeft.Controls.Add(this.sidePanel);
            this.panelLeft.Controls.Add(this.btnNuocUong);
            this.panelLeft.Controls.Add(this.btnThucAn);
            this.panelLeft.Controls.Add(this.btnNha);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(286, 1000);
            this.panelLeft.TabIndex = 7;
            // 
            // clbNuocUong
            // 
            this.clbNuocUong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.clbNuocUong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbNuocUong.CheckOnClick = true;
            this.clbNuocUong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbNuocUong.ForeColor = System.Drawing.Color.White;
            this.clbNuocUong.FormattingEnabled = true;
            this.clbNuocUong.Items.AddRange(new object[] {
            "Nước giải khát",
            "Trà sữa",
            "Cà phê"});
            this.clbNuocUong.Location = new System.Drawing.Point(33, 497);
            this.clbNuocUong.Name = "clbNuocUong";
            this.clbNuocUong.Size = new System.Drawing.Size(253, 125);
            this.clbNuocUong.TabIndex = 4;
            this.clbNuocUong.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbNuocUong_ItemCheck);
            // 
            // clbThucAn
            // 
            this.clbThucAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.clbThucAn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbThucAn.CheckOnClick = true;
            this.clbThucAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbThucAn.ForeColor = System.Drawing.Color.White;
            this.clbThucAn.FormattingEnabled = true;
            this.clbThucAn.Items.AddRange(new object[] {
            "Mì tôm",
            "Cơm",
            "Ăn vặt"});
            this.clbThucAn.Location = new System.Drawing.Point(33, 276);
            this.clbThucAn.Name = "clbThucAn";
            this.clbThucAn.Size = new System.Drawing.Size(253, 125);
            this.clbThucAn.TabIndex = 3;
            this.clbThucAn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbThucAn_ItemCheck);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.sidePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.sidePanel.Location = new System.Drawing.Point(0, 100);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(15, 82);
            this.sidePanel.TabIndex = 0;
            // 
            // btnNuocUong
            // 
            this.btnNuocUong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuocUong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuocUong.Location = new System.Drawing.Point(12, 407);
            this.btnNuocUong.Name = "btnNuocUong";
            this.btnNuocUong.Size = new System.Drawing.Size(274, 82);
            this.btnNuocUong.TabIndex = 2;
            this.btnNuocUong.Text = "Nước uống";
            this.btnNuocUong.UseVisualStyleBackColor = true;
            this.btnNuocUong.Click += new System.EventHandler(this.btnNuocUong_Click);
            // 
            // btnThucAn
            // 
            this.btnThucAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucAn.Location = new System.Drawing.Point(12, 188);
            this.btnThucAn.Name = "btnThucAn";
            this.btnThucAn.Size = new System.Drawing.Size(274, 82);
            this.btnThucAn.TabIndex = 2;
            this.btnThucAn.Text = "Thức ăn";
            this.btnThucAn.UseVisualStyleBackColor = true;
            this.btnThucAn.Click += new System.EventHandler(this.btnThucAn_Click);
            // 
            // btnNha
            // 
            this.btnNha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNha.Location = new System.Drawing.Point(12, 100);
            this.btnNha.Name = "btnNha";
            this.btnNha.Size = new System.Drawing.Size(274, 82);
            this.btnNha.TabIndex = 1;
            this.btnNha.Text = "Nhà";
            this.btnNha.UseVisualStyleBackColor = true;
            this.btnNha.Click += new System.EventHandler(this.btnNha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỰC ĐƠN";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(286, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1214, 100);
            this.panelTop.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "NET AAA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(1151, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.AutoScroll = true;
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCenter.Location = new System.Drawing.Point(286, 100);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1214, 591);
            this.panelCenter.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnCapNhat);
            this.panel1.Controls.Add(this.btnHuyMon);
            this.panel1.Controls.Add(this.btnGoiMon);
            this.panel1.Location = new System.Drawing.Point(1183, 697);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 199);
            this.panel1.TabIndex = 10;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.White;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.Black;
            this.btnReload.Location = new System.Drawing.Point(42, 107);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(102, 42);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCapNhat.Enabled = false;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.Black;
            this.btnCapNhat.Location = new System.Drawing.Point(167, 107);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(118, 42);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnHuyMon
            // 
            this.btnHuyMon.BackColor = System.Drawing.Color.Red;
            this.btnHuyMon.Enabled = false;
            this.btnHuyMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyMon.Location = new System.Drawing.Point(167, 45);
            this.btnHuyMon.Name = "btnHuyMon";
            this.btnHuyMon.Size = new System.Drawing.Size(118, 41);
            this.btnHuyMon.TabIndex = 1;
            this.btnHuyMon.Text = "Hủy món";
            this.btnHuyMon.UseVisualStyleBackColor = false;
            this.btnHuyMon.Click += new System.EventHandler(this.btnHuyMon_Click);
            // 
            // btnGoiMon
            // 
            this.btnGoiMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGoiMon.Enabled = false;
            this.btnGoiMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoiMon.ForeColor = System.Drawing.Color.Black;
            this.btnGoiMon.Location = new System.Drawing.Point(42, 45);
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.Size = new System.Drawing.Size(106, 42);
            this.btnGoiMon.TabIndex = 0;
            this.btnGoiMon.Text = "Gọi món";
            this.btnGoiMon.UseVisualStyleBackColor = false;
            this.btnGoiMon.Click += new System.EventHandler(this.btnGoiMon_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.lblSTTGOIMON);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.nupSoLuong);
            this.panel2.Controls.Add(this.lblSoLuong);
            this.panel2.Location = new System.Drawing.Point(920, 697);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 199);
            this.panel2.TabIndex = 11;
            // 
            // lblSTTGOIMON
            // 
            this.lblSTTGOIMON.AutoSize = true;
            this.lblSTTGOIMON.BackColor = System.Drawing.Color.White;
            this.lblSTTGOIMON.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTTGOIMON.ForeColor = System.Drawing.Color.Black;
            this.lblSTTGOIMON.Location = new System.Drawing.Point(83, 103);
            this.lblSTTGOIMON.Name = "lblSTTGOIMON";
            this.lblSTTGOIMON.Size = new System.Drawing.Size(96, 25);
            this.lblSTTGOIMON.TabIndex = 4;
            this.lblSTTGOIMON.Text = "Số lượng:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblTenMon);
            this.panel3.Location = new System.Drawing.Point(33, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 68);
            this.panel3.TabIndex = 3;
            // 
            // lblTenMon
            // 
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.ForeColor = System.Drawing.Color.Black;
            this.lblTenMon.Location = new System.Drawing.Point(0, 0);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(200, 68);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nupSoLuong
            // 
            this.nupSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupSoLuong.Location = new System.Drawing.Point(160, 134);
            this.nupSoLuong.Name = "nupSoLuong";
            this.nupSoLuong.Size = new System.Drawing.Size(54, 30);
            this.nupSoLuong.TabIndex = 2;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(49, 136);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(96, 25);
            this.lblSoLuong.TabIndex = 1;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // grdDanhSach
            // 
            this.grdDanhSach.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.grdDanhSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDanhSach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.grdDanhSach.BackgroundColor = System.Drawing.Color.Black;
            this.grdDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grdDanhSach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDanhSach.GridColor = System.Drawing.Color.Black;
            this.grdDanhSach.Location = new System.Drawing.Point(-13, 697);
            this.grdDanhSach.Name = "grdDanhSach";
            this.grdDanhSach.ReadOnly = true;
            this.grdDanhSach.RowHeadersWidth = 51;
            this.grdDanhSach.RowTemplate.Height = 24;
            this.grdDanhSach.Size = new System.Drawing.Size(934, 199);
            this.grdDanhSach.TabIndex = 3;
            this.grdDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDanhSach_CellClick);
            // 
            // frmThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1500, 1000);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdDanhSach);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thực đơn";
            this.Load += new System.EventHandler(this.frmThucDon_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnNuocUong;
        private System.Windows.Forms.Button btnThucAn;
        private System.Windows.Forms.Button btnNha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.FlowLayoutPanel panelCenter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox clbThucAn;
        private System.Windows.Forms.CheckedListBox clbNuocUong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnHuyMon;
        private System.Windows.Forms.Button btnGoiMon;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.NumericUpDown nupSoLuong;
        private System.Windows.Forms.DataGridView grdDanhSach;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSTTGOIMON;
    }
}