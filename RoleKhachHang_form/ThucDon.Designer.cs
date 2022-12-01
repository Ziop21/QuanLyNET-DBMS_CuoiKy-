
namespace RoleKhachHang_form
{
    partial class ThucDon
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
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCL = new System.Windows.Forms.TextBox();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtGT = new System.Windows.Forms.TextBox();
            this.txtTNL = new System.Windows.Forms.TextBox();
            this.txtTM = new System.Windows.Forms.TextBox();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.lbCL = new System.Windows.Forms.Label();
            this.lbDB = new System.Windows.Forms.Label();
            this.lbGT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTNL = new System.Windows.Forms.Label();
            this.lbTM = new System.Windows.Forms.Label();
            this.lbMM = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 47;
            this.dataGridView1.Size = new System.Drawing.Size(1488, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(964, 218);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(245, 32);
            this.cbCategory.TabIndex = 3;
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.Location = new System.Drawing.Point(1288, 145);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(137, 41);
            this.btnInit.TabIndex = 2;
            this.btnInit.Text = "Khởi tạo";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(1288, 34);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 41);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(204, 214);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(137, 41);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Up ảnh";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(564, 144);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 41);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(564, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 41);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCL
            // 
            this.txtCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCL.Location = new System.Drawing.Point(964, 149);
            this.txtCL.Margin = new System.Windows.Forms.Padding(4);
            this.txtCL.Name = "txtCL";
            this.txtCL.Size = new System.Drawing.Size(245, 28);
            this.txtCL.TabIndex = 1;
            // 
            // txtDB
            // 
            this.txtDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDB.Location = new System.Drawing.Point(964, 90);
            this.txtDB.Margin = new System.Windows.Forms.Padding(4);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(245, 28);
            this.txtDB.TabIndex = 1;
            // 
            // txtGT
            // 
            this.txtGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGT.Location = new System.Drawing.Point(964, 31);
            this.txtGT.Margin = new System.Windows.Forms.Padding(4);
            this.txtGT.Name = "txtGT";
            this.txtGT.Size = new System.Drawing.Size(245, 28);
            this.txtGT.TabIndex = 1;
            // 
            // txtTNL
            // 
            this.txtTNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTNL.Location = new System.Drawing.Point(204, 151);
            this.txtTNL.Margin = new System.Windows.Forms.Padding(4);
            this.txtTNL.Name = "txtTNL";
            this.txtTNL.Size = new System.Drawing.Size(245, 28);
            this.txtTNL.TabIndex = 1;
            // 
            // txtTM
            // 
            this.txtTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTM.Location = new System.Drawing.Point(204, 91);
            this.txtTM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTM.Name = "txtTM";
            this.txtTM.Size = new System.Drawing.Size(245, 28);
            this.txtTM.TabIndex = 1;
            // 
            // txtMM
            // 
            this.txtMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMM.Location = new System.Drawing.Point(204, 34);
            this.txtMM.Margin = new System.Windows.Forms.Padding(4);
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(245, 28);
            this.txtMM.TabIndex = 1;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(768, 228);
            this.lb1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(88, 24);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Phân loại";
            // 
            // lbCL
            // 
            this.lbCL.AutoSize = true;
            this.lbCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCL.Location = new System.Drawing.Point(768, 155);
            this.lbCL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCL.Name = "lbCL";
            this.lbCL.Size = new System.Drawing.Size(68, 24);
            this.lbCL.TabIndex = 0;
            this.lbCL.Text = "Còn lại";
            // 
            // lbDB
            // 
            this.lbDB.AutoSize = true;
            this.lbDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDB.Location = new System.Drawing.Point(768, 94);
            this.lbDB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDB.Name = "lbDB";
            this.lbDB.Size = new System.Drawing.Size(70, 24);
            this.lbDB.TabIndex = 0;
            this.lbDB.Text = "Đã bán";
            // 
            // lbGT
            // 
            this.lbGT.AutoSize = true;
            this.lbGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGT.Location = new System.Drawing.Point(768, 34);
            this.lbGT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGT.Name = "lbGT";
            this.lbGT.Size = new System.Drawing.Size(73, 24);
            this.lbGT.TabIndex = 0;
            this.lbGT.Text = "Giá tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ảnh";
            // 
            // lbTNL
            // 
            this.lbTNL.AutoSize = true;
            this.lbTNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTNL.Location = new System.Drawing.Point(8, 155);
            this.lbTNL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTNL.Name = "lbTNL";
            this.lbTNL.Size = new System.Drawing.Size(152, 24);
            this.lbTNL.TabIndex = 0;
            this.lbTNL.Text = "Tiền nguyên liệu";
            // 
            // lbTM
            // 
            this.lbTM.AutoSize = true;
            this.lbTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTM.Location = new System.Drawing.Point(8, 95);
            this.lbTM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTM.Name = "lbTM";
            this.lbTM.Size = new System.Drawing.Size(87, 24);
            this.lbTM.TabIndex = 0;
            this.lbTM.Text = "Tên món";
            // 
            // lbMM
            // 
            this.lbMM.AutoSize = true;
            this.lbMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMM.Location = new System.Drawing.Point(8, 38);
            this.lbMM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMM.Name = "lbMM";
            this.lbMM.Size = new System.Drawing.Size(79, 24);
            this.lbMM.TabIndex = 0;
            this.lbMM.Text = "Mã món";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(16, 313);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1505, 367);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtCL);
            this.groupBox1.Controls.Add(this.txtDB);
            this.groupBox1.Controls.Add(this.txtGT);
            this.groupBox1.Controls.Add(this.txtTNL);
            this.groupBox1.Controls.Add(this.txtTM);
            this.groupBox1.Controls.Add(this.txtMM);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Controls.Add(this.lbCL);
            this.groupBox1.Controls.Add(this.lbDB);
            this.groupBox1.Controls.Add(this.lbGT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbTNL);
            this.groupBox1.Controls.Add(this.lbTM);
            this.groupBox1.Controls.Add(this.lbMM);
            this.groupBox1.Location = new System.Drawing.Point(16, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1505, 283);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // ThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 703);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThucDon";
            this.Load += new System.EventHandler(this.ThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCL;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtGT;
        private System.Windows.Forms.TextBox txtTNL;
        private System.Windows.Forms.TextBox txtTM;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lbCL;
        private System.Windows.Forms.Label lbDB;
        private System.Windows.Forms.Label lbGT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTNL;
        private System.Windows.Forms.Label lbTM;
        private System.Windows.Forms.Label lbMM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}