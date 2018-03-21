namespace _2017_QLKH
{
    partial class DanhMucSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMucSP));
            this.bt_quaylai = new System.Windows.Forms.Button();
            this.group_qldmsp = new System.Windows.Forms.GroupBox();
            this.btn_mo = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_them = new System.Windows.Forms.Button();
            this.tbx_makho = new System.Windows.Forms.TextBox();
            this.tbx_TenDM = new System.Windows.Forms.TextBox();
            this.tbx_ghichu = new System.Windows.Forms.TextBox();
            this.tbx_MaDN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.group_dmsp = new System.Windows.Forms.GroupBox();
            this.dgv_dmsanpham = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_timkiem = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.group_qldmsp.SuspendLayout();
            this.group_dmsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dmsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_quaylai
            // 
            this.bt_quaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_quaylai.Image = ((System.Drawing.Image)(resources.GetObject("bt_quaylai.Image")));
            this.bt_quaylai.Location = new System.Drawing.Point(12, 1);
            this.bt_quaylai.Name = "bt_quaylai";
            this.bt_quaylai.Size = new System.Drawing.Size(53, 37);
            this.bt_quaylai.TabIndex = 11;
            this.bt_quaylai.UseVisualStyleBackColor = true;
            this.bt_quaylai.Click += new System.EventHandler(this.bt_quaylai_Click);
            // 
            // group_qldmsp
            // 
            this.group_qldmsp.Controls.Add(this.btn_mo);
            this.group_qldmsp.Controls.Add(this.bt_xoa);
            this.group_qldmsp.Controls.Add(this.bt_sua);
            this.group_qldmsp.Controls.Add(this.bt_them);
            this.group_qldmsp.Controls.Add(this.tbx_makho);
            this.group_qldmsp.Controls.Add(this.tbx_TenDM);
            this.group_qldmsp.Controls.Add(this.tbx_ghichu);
            this.group_qldmsp.Controls.Add(this.tbx_MaDN);
            this.group_qldmsp.Controls.Add(this.label5);
            this.group_qldmsp.Controls.Add(this.label4);
            this.group_qldmsp.Controls.Add(this.label3);
            this.group_qldmsp.Controls.Add(this.label2);
            this.group_qldmsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_qldmsp.Location = new System.Drawing.Point(12, 50);
            this.group_qldmsp.Name = "group_qldmsp";
            this.group_qldmsp.Size = new System.Drawing.Size(242, 288);
            this.group_qldmsp.TabIndex = 0;
            this.group_qldmsp.TabStop = false;
            this.group_qldmsp.Text = "Quản Trị";
            // 
            // btn_mo
            // 
            this.btn_mo.Location = new System.Drawing.Point(190, 32);
            this.btn_mo.Name = "btn_mo";
            this.btn_mo.Size = new System.Drawing.Size(32, 23);
            this.btn_mo.TabIndex = 7;
            this.btn_mo.Text = "Mở";
            this.btn_mo.UseVisualStyleBackColor = true;
            this.btn_mo.Click += new System.EventHandler(this.btn_mo_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Location = new System.Drawing.Point(160, 240);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(56, 23);
            this.bt_xoa.TabIndex = 6;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Location = new System.Drawing.Point(90, 240);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(56, 23);
            this.bt_sua.TabIndex = 5;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_them
            // 
            this.bt_them.Location = new System.Drawing.Point(20, 240);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(58, 23);
            this.bt_them.TabIndex = 4;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // tbx_makho
            // 
            this.tbx_makho.Location = new System.Drawing.Point(86, 190);
            this.tbx_makho.Name = "tbx_makho";
            this.tbx_makho.Size = new System.Drawing.Size(99, 20);
            this.tbx_makho.TabIndex = 3;
            // 
            // tbx_TenDM
            // 
            this.tbx_TenDM.Location = new System.Drawing.Point(86, 68);
            this.tbx_TenDM.Name = "tbx_TenDM";
            this.tbx_TenDM.Size = new System.Drawing.Size(136, 20);
            this.tbx_TenDM.TabIndex = 1;
            // 
            // tbx_ghichu
            // 
            this.tbx_ghichu.Location = new System.Drawing.Point(86, 103);
            this.tbx_ghichu.Multiline = true;
            this.tbx_ghichu.Name = "tbx_ghichu";
            this.tbx_ghichu.Size = new System.Drawing.Size(136, 72);
            this.tbx_ghichu.TabIndex = 2;
            // 
            // tbx_MaDN
            // 
            this.tbx_MaDN.Location = new System.Drawing.Point(86, 34);
            this.tbx_MaDN.Name = "tbx_MaDN";
            this.tbx_MaDN.Size = new System.Drawing.Size(99, 20);
            this.tbx_MaDN.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã Kho";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ghi Chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên DM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã DM";
            // 
            // group_dmsp
            // 
            this.group_dmsp.Controls.Add(this.dgv_dmsanpham);
            this.group_dmsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_dmsp.Location = new System.Drawing.Point(262, 50);
            this.group_dmsp.Name = "group_dmsp";
            this.group_dmsp.Size = new System.Drawing.Size(488, 288);
            this.group_dmsp.TabIndex = 12;
            this.group_dmsp.TabStop = false;
            this.group_dmsp.Text = "Danh Mục SP";
            // 
            // dgv_dmsanpham
            // 
            this.dgv_dmsanpham.AllowUserToAddRows = false;
            this.dgv_dmsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dmsanpham.Location = new System.Drawing.Point(6, 25);
            this.dgv_dmsanpham.Name = "dgv_dmsanpham";
            this.dgv_dmsanpham.Size = new System.Drawing.Size(476, 263);
            this.dgv_dmsanpham.TabIndex = 10;
            this.dgv_dmsanpham.TabStop = false;
            this.dgv_dmsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dmsanpham_CellClick);
            this.dgv_dmsanpham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_dmsanpham_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh Mục Sản Phẩm";
            // 
            // tbx_timkiem
            // 
            this.tbx_timkiem.Location = new System.Drawing.Point(445, 17);
            this.tbx_timkiem.Name = "tbx_timkiem";
            this.tbx_timkiem.Size = new System.Drawing.Size(160, 20);
            this.tbx_timkiem.TabIndex = 8;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.Location = new System.Drawing.Point(611, 15);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(67, 23);
            this.btn_timkiem.TabIndex = 9;
            this.btn_timkiem.Text = "Tìm Kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lammoi.Location = new System.Drawing.Point(684, 15);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(63, 23);
            this.btn_lammoi.TabIndex = 10;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // DanhMucSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 347);
            this.Controls.Add(this.btn_lammoi);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.tbx_timkiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.group_dmsp);
            this.Controls.Add(this.group_qldmsp);
            this.Controls.Add(this.bt_quaylai);
            this.Name = "DanhMucSP";
            this.Text = "DanhMucSP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DanhMucSP_FormClosed);
            this.Load += new System.EventHandler(this.DanhMucSP_Load);
            this.group_qldmsp.ResumeLayout(false);
            this.group_qldmsp.PerformLayout();
            this.group_dmsp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dmsanpham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_quaylai;
        private System.Windows.Forms.GroupBox group_qldmsp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox group_dmsp;
        private System.Windows.Forms.DataGridView dgv_dmsanpham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_makho;
        private System.Windows.Forms.TextBox tbx_TenDM;
        private System.Windows.Forms.TextBox tbx_ghichu;
        private System.Windows.Forms.TextBox tbx_MaDN;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.TextBox tbx_timkiem;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.Button btn_mo;
    }
}