
namespace RoleKhachHang_form
{
    partial class QuanLyMayTinhKhachHang
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnNhanTin = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblMaTk = new System.Windows.Forms.Label();
            this.lblMaMay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 47;
            this.dataGridView1.Size = new System.Drawing.Size(976, 495);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(74, 563);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(130, 25);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Mã tài khoản:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(381, 563);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(124, 25);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Mã máy tính:";
            // 
            // btnNhanTin
            // 
            this.btnNhanTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNhanTin.Enabled = false;
            this.btnNhanTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanTin.Location = new System.Drawing.Point(837, 553);
            this.btnNhanTin.Name = "btnNhanTin";
            this.btnNhanTin.Size = new System.Drawing.Size(133, 44);
            this.btnNhanTin.TabIndex = 4;
            this.btnNhanTin.Text = "Nhắn tin";
            this.btnNhanTin.UseVisualStyleBackColor = false;
            this.btnNhanTin.Click += new System.EventHandler(this.btnNhanTin_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(698, 553);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(133, 44);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblMaTk
            // 
            this.lblMaTk.AutoSize = true;
            this.lblMaTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTk.Location = new System.Drawing.Point(222, 563);
            this.lblMaTk.Name = "lblMaTk";
            this.lblMaTk.Size = new System.Drawing.Size(67, 25);
            this.lblMaTk.TabIndex = 6;
            this.lblMaTk.Text = "MaTK";
            // 
            // lblMaMay
            // 
            this.lblMaMay.AutoSize = true;
            this.lblMaMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMay.Location = new System.Drawing.Point(520, 563);
            this.lblMaMay.Name = "lblMaMay";
            this.lblMaMay.Size = new System.Drawing.Size(78, 25);
            this.lblMaMay.TabIndex = 7;
            this.lblMaMay.Text = "MaMay";
            // 
            // QuanLyMayTinhKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 638);
            this.Controls.Add(this.lblMaMay);
            this.Controls.Add(this.lblMaTk);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnNhanTin);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "QuanLyMayTinhKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyMayTinhKhachHang";
            this.Load += new System.EventHandler(this.MayTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnNhanTin;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblMaTk;
        private System.Windows.Forms.Label lblMaMay;
    }
}