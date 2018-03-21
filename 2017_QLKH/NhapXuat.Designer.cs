namespace _2017_QLKH
{
    partial class NhapXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapXuat));
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.tbx_timkiem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.dgv_NhapXuat = new System.Windows.Forms.DataGridView();
            this.btn_mo = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.dateTimePicker_ngayN_X = new System.Windows.Forms.DateTimePicker();
            this.tbx_dongia = new System.Windows.Forms.TextBox();
            this.lb_Dongia = new System.Windows.Forms.Label();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.tbx_GhiChu = new System.Windows.Forms.TextBox();
            this.tbx_TongTien = new System.Windows.Forms.TextBox();
            this.tbx_soluong = new System.Windows.Forms.TextBox();
            this.tbx_NVXuat_Nhap = new System.Windows.Forms.TextBox();
            this.tbx_MaKH_NCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_MaKho = new System.Windows.Forms.TextBox();
            this.tbx_MaSP = new System.Windows.Forms.TextBox();
            this.tbx_MaPhieuX_N = new System.Windows.Forms.TextBox();
            this.lb_ghichu = new System.Windows.Forms.Label();
            this.lb_Tongtien = new System.Windows.Forms.Label();
            this.lb_SL = new System.Windows.Forms.Label();
            this.lb_ngay_xuat = new System.Windows.Forms.Label();
            this.btn_quaylai = new System.Windows.Forms.Button();
            this.bt_nhap = new System.Windows.Forms.Button();
            this.bt_xuat = new System.Windows.Forms.Button();
            this.lb_NV_xuat = new System.Windows.Forms.Label();
            this.lb_MaKH = new System.Windows.Forms.Label();
            this.lb_MaKho = new System.Windows.Forms.Label();
            this.lb_MaPX = new System.Windows.Forms.Label();
            this.panel_QTX = new System.Windows.Forms.Panel();
            this.lb_MaSP = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhapXuat)).BeginInit();
            this.panel_QTX.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(404, 30);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(67, 23);
            this.btn_lammoi.TabIndex = 16;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // tbx_timkiem
            // 
            this.tbx_timkiem.Location = new System.Drawing.Point(79, 32);
            this.tbx_timkiem.Name = "tbx_timkiem";
            this.tbx_timkiem.Size = new System.Drawing.Size(239, 20);
            this.tbx_timkiem.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_lammoi);
            this.groupBox2.Controls.Add(this.btn_timkiem);
            this.groupBox2.Controls.Add(this.tbx_timkiem);
            this.groupBox2.Controls.Add(this.dgv_NhapXuat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(289, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 410);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Nhập Xuất";
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Location = new System.Drawing.Point(324, 30);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(67, 23);
            this.btn_timkiem.TabIndex = 15;
            this.btn_timkiem.Text = "Tìm Kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // dgv_NhapXuat
            // 
            this.dgv_NhapXuat.AllowUserToAddRows = false;
            this.dgv_NhapXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhapXuat.Location = new System.Drawing.Point(6, 66);
            this.dgv_NhapXuat.Name = "dgv_NhapXuat";
            this.dgv_NhapXuat.Size = new System.Drawing.Size(539, 333);
            this.dgv_NhapXuat.TabIndex = 15;
            this.dgv_NhapXuat.TabStop = false;
            this.dgv_NhapXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_NhapXuat_CellClick);
            this.dgv_NhapXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_NhapXuat_KeyDown);
            // 
            // btn_mo
            // 
            this.btn_mo.Location = new System.Drawing.Point(191, 7);
            this.btn_mo.Name = "btn_mo";
            this.btn_mo.Size = new System.Drawing.Size(37, 23);
            this.btn_mo.TabIndex = 13;
            this.btn_mo.Text = "Mở";
            this.btn_mo.UseVisualStyleBackColor = true;
            this.btn_mo.Click += new System.EventHandler(this.btn_mo_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(94, 299);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(52, 23);
            this.btn_sua.TabIndex = 11;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // dateTimePicker_ngayN_X
            // 
            this.dateTimePicker_ngayN_X.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ngayN_X.Location = new System.Drawing.Point(87, 132);
            this.dateTimePicker_ngayN_X.Name = "dateTimePicker_ngayN_X";
            this.dateTimePicker_ngayN_X.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker_ngayN_X.TabIndex = 5;
            // 
            // tbx_dongia
            // 
            this.tbx_dongia.Location = new System.Drawing.Point(87, 183);
            this.tbx_dongia.Name = "tbx_dongia";
            this.tbx_dongia.Size = new System.Drawing.Size(123, 20);
            this.tbx_dongia.TabIndex = 7;
            // 
            // lb_Dongia
            // 
            this.lb_Dongia.AutoSize = true;
            this.lb_Dongia.Location = new System.Drawing.Point(12, 186);
            this.lb_Dongia.Name = "lb_Dongia";
            this.lb_Dongia.Size = new System.Drawing.Size(53, 13);
            this.lb_Dongia.TabIndex = 20;
            this.lb_Dongia.Text = "Đơn Giá";
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(167, 299);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(52, 23);
            this.btn_xoa.TabIndex = 12;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(21, 299);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(52, 23);
            this.btn_them.TabIndex = 10;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // tbx_GhiChu
            // 
            this.tbx_GhiChu.Location = new System.Drawing.Point(87, 237);
            this.tbx_GhiChu.Multiline = true;
            this.tbx_GhiChu.Name = "tbx_GhiChu";
            this.tbx_GhiChu.Size = new System.Drawing.Size(141, 45);
            this.tbx_GhiChu.TabIndex = 9;
            // 
            // tbx_TongTien
            // 
            this.tbx_TongTien.Location = new System.Drawing.Point(87, 211);
            this.tbx_TongTien.Name = "tbx_TongTien";
            this.tbx_TongTien.Size = new System.Drawing.Size(141, 20);
            this.tbx_TongTien.TabIndex = 8;
            // 
            // tbx_soluong
            // 
            this.tbx_soluong.Location = new System.Drawing.Point(87, 157);
            this.tbx_soluong.Name = "tbx_soluong";
            this.tbx_soluong.Size = new System.Drawing.Size(123, 20);
            this.tbx_soluong.TabIndex = 6;
            // 
            // tbx_NVXuat_Nhap
            // 
            this.tbx_NVXuat_Nhap.Location = new System.Drawing.Point(87, 106);
            this.tbx_NVXuat_Nhap.Name = "tbx_NVXuat_Nhap";
            this.tbx_NVXuat_Nhap.Size = new System.Drawing.Size(141, 20);
            this.tbx_NVXuat_Nhap.TabIndex = 4;
            // 
            // tbx_MaKH_NCC
            // 
            this.tbx_MaKH_NCC.Location = new System.Drawing.Point(87, 82);
            this.tbx_MaKH_NCC.Name = "tbx_MaKH_NCC";
            this.tbx_MaKH_NCC.Size = new System.Drawing.Size(98, 20);
            this.tbx_MaKH_NCC.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nhập _ Xuất Hàng Hóa";
            // 
            // tbx_MaKho
            // 
            this.tbx_MaKho.Location = new System.Drawing.Point(87, 57);
            this.tbx_MaKho.Name = "tbx_MaKho";
            this.tbx_MaKho.Size = new System.Drawing.Size(98, 20);
            this.tbx_MaKho.TabIndex = 2;
            // 
            // tbx_MaSP
            // 
            this.tbx_MaSP.Location = new System.Drawing.Point(87, 33);
            this.tbx_MaSP.Name = "tbx_MaSP";
            this.tbx_MaSP.Size = new System.Drawing.Size(98, 20);
            this.tbx_MaSP.TabIndex = 1;
            // 
            // tbx_MaPhieuX_N
            // 
            this.tbx_MaPhieuX_N.Location = new System.Drawing.Point(87, 9);
            this.tbx_MaPhieuX_N.Name = "tbx_MaPhieuX_N";
            this.tbx_MaPhieuX_N.Size = new System.Drawing.Size(98, 20);
            this.tbx_MaPhieuX_N.TabIndex = 0;
            // 
            // lb_ghichu
            // 
            this.lb_ghichu.AutoSize = true;
            this.lb_ghichu.Location = new System.Drawing.Point(12, 240);
            this.lb_ghichu.Name = "lb_ghichu";
            this.lb_ghichu.Size = new System.Drawing.Size(52, 13);
            this.lb_ghichu.TabIndex = 8;
            this.lb_ghichu.Text = "Ghi Chú";
            // 
            // lb_Tongtien
            // 
            this.lb_Tongtien.AutoSize = true;
            this.lb_Tongtien.Location = new System.Drawing.Point(11, 214);
            this.lb_Tongtien.Name = "lb_Tongtien";
            this.lb_Tongtien.Size = new System.Drawing.Size(65, 13);
            this.lb_Tongtien.TabIndex = 7;
            this.lb_Tongtien.Text = "Tổng Tiền";
            // 
            // lb_SL
            // 
            this.lb_SL.AutoSize = true;
            this.lb_SL.Location = new System.Drawing.Point(12, 160);
            this.lb_SL.Name = "lb_SL";
            this.lb_SL.Size = new System.Drawing.Size(61, 13);
            this.lb_SL.TabIndex = 6;
            this.lb_SL.Text = "Số Lượng";
            // 
            // lb_ngay_xuat
            // 
            this.lb_ngay_xuat.AutoSize = true;
            this.lb_ngay_xuat.Location = new System.Drawing.Point(12, 134);
            this.lb_ngay_xuat.Name = "lb_ngay_xuat";
            this.lb_ngay_xuat.Size = new System.Drawing.Size(66, 13);
            this.lb_ngay_xuat.TabIndex = 5;
            this.lb_ngay_xuat.Text = "Ngày Xuất";
            // 
            // btn_quaylai
            // 
            this.btn_quaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quaylai.Image = ((System.Drawing.Image)(resources.GetObject("btn_quaylai.Image")));
            this.btn_quaylai.Location = new System.Drawing.Point(16, 5);
            this.btn_quaylai.Name = "btn_quaylai";
            this.btn_quaylai.Size = new System.Drawing.Size(52, 35);
            this.btn_quaylai.TabIndex = 21;
            this.btn_quaylai.UseVisualStyleBackColor = true;
            this.btn_quaylai.Click += new System.EventHandler(this.bt_quaylai_Click);
            // 
            // bt_nhap
            // 
            this.bt_nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_nhap.Location = new System.Drawing.Point(14, 19);
            this.bt_nhap.Name = "bt_nhap";
            this.bt_nhap.Size = new System.Drawing.Size(124, 44);
            this.bt_nhap.TabIndex = 18;
            this.bt_nhap.Text = "Nhập Hàng";
            this.bt_nhap.UseVisualStyleBackColor = true;
            this.bt_nhap.Click += new System.EventHandler(this.bt_nhap_Click);
            // 
            // bt_xuat
            // 
            this.bt_xuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xuat.Location = new System.Drawing.Point(138, 19);
            this.bt_xuat.Name = "bt_xuat";
            this.bt_xuat.Size = new System.Drawing.Size(114, 44);
            this.bt_xuat.TabIndex = 19;
            this.bt_xuat.Text = "Xuất Hàng";
            this.bt_xuat.UseVisualStyleBackColor = true;
            this.bt_xuat.Click += new System.EventHandler(this.bt_xuat_Click);
            // 
            // lb_NV_xuat
            // 
            this.lb_NV_xuat.AutoSize = true;
            this.lb_NV_xuat.Location = new System.Drawing.Point(12, 109);
            this.lb_NV_xuat.Name = "lb_NV_xuat";
            this.lb_NV_xuat.Size = new System.Drawing.Size(54, 13);
            this.lb_NV_xuat.TabIndex = 4;
            this.lb_NV_xuat.Text = "NV Xuất";
            // 
            // lb_MaKH
            // 
            this.lb_MaKH.AutoSize = true;
            this.lb_MaKH.Location = new System.Drawing.Point(12, 85);
            this.lb_MaKH.Name = "lb_MaKH";
            this.lb_MaKH.Size = new System.Drawing.Size(45, 13);
            this.lb_MaKH.TabIndex = 3;
            this.lb_MaKH.Text = "Mã KH";
            // 
            // lb_MaKho
            // 
            this.lb_MaKho.AutoSize = true;
            this.lb_MaKho.Location = new System.Drawing.Point(12, 60);
            this.lb_MaKho.Name = "lb_MaKho";
            this.lb_MaKho.Size = new System.Drawing.Size(50, 13);
            this.lb_MaKho.TabIndex = 2;
            this.lb_MaKho.Text = "Mã Kho";
            // 
            // lb_MaPX
            // 
            this.lb_MaPX.AutoSize = true;
            this.lb_MaPX.Location = new System.Drawing.Point(12, 12);
            this.lb_MaPX.Name = "lb_MaPX";
            this.lb_MaPX.Size = new System.Drawing.Size(44, 13);
            this.lb_MaPX.TabIndex = 0;
            this.lb_MaPX.Text = "Mã PX";
            // 
            // panel_QTX
            // 
            this.panel_QTX.Controls.Add(this.btn_mo);
            this.panel_QTX.Controls.Add(this.btn_sua);
            this.panel_QTX.Controls.Add(this.dateTimePicker_ngayN_X);
            this.panel_QTX.Controls.Add(this.tbx_dongia);
            this.panel_QTX.Controls.Add(this.lb_Dongia);
            this.panel_QTX.Controls.Add(this.btn_xoa);
            this.panel_QTX.Controls.Add(this.btn_them);
            this.panel_QTX.Controls.Add(this.tbx_GhiChu);
            this.panel_QTX.Controls.Add(this.tbx_TongTien);
            this.panel_QTX.Controls.Add(this.tbx_soluong);
            this.panel_QTX.Controls.Add(this.tbx_NVXuat_Nhap);
            this.panel_QTX.Controls.Add(this.tbx_MaKH_NCC);
            this.panel_QTX.Controls.Add(this.tbx_MaKho);
            this.panel_QTX.Controls.Add(this.tbx_MaSP);
            this.panel_QTX.Controls.Add(this.tbx_MaPhieuX_N);
            this.panel_QTX.Controls.Add(this.lb_ghichu);
            this.panel_QTX.Controls.Add(this.lb_Tongtien);
            this.panel_QTX.Controls.Add(this.lb_SL);
            this.panel_QTX.Controls.Add(this.lb_ngay_xuat);
            this.panel_QTX.Controls.Add(this.lb_NV_xuat);
            this.panel_QTX.Controls.Add(this.lb_MaKH);
            this.panel_QTX.Controls.Add(this.lb_MaKho);
            this.panel_QTX.Controls.Add(this.lb_MaSP);
            this.panel_QTX.Controls.Add(this.lb_MaPX);
            this.panel_QTX.Location = new System.Drawing.Point(11, 66);
            this.panel_QTX.Name = "panel_QTX";
            this.panel_QTX.Size = new System.Drawing.Size(244, 333);
            this.panel_QTX.TabIndex = 0;
            // 
            // lb_MaSP
            // 
            this.lb_MaSP.AutoSize = true;
            this.lb_MaSP.Location = new System.Drawing.Point(12, 36);
            this.lb_MaSP.Name = "lb_MaSP";
            this.lb_MaSP.Size = new System.Drawing.Size(44, 13);
            this.lb_MaSP.TabIndex = 1;
            this.lb_MaSP.Text = "Mã SP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_QTX);
            this.groupBox1.Controls.Add(this.bt_nhap);
            this.groupBox1.Controls.Add(this.bt_xuat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 410);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xuất _ Nhập";
            // 
            // NhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_quaylai);
            this.Controls.Add(this.groupBox1);
            this.Name = "NhapXuat";
            this.Text = "NhapXuat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NhapXuat_FormClosed_1);
            this.Load += new System.EventHandler(this.NhapXuat_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhapXuat)).EndInit();
            this.panel_QTX.ResumeLayout(false);
            this.panel_QTX.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.TextBox tbx_timkiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.DataGridView dgv_NhapXuat;
        private System.Windows.Forms.Button btn_mo;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ngayN_X;
        private System.Windows.Forms.TextBox tbx_dongia;
        private System.Windows.Forms.Label lb_Dongia;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox tbx_GhiChu;
        private System.Windows.Forms.TextBox tbx_TongTien;
        private System.Windows.Forms.TextBox tbx_soluong;
        private System.Windows.Forms.TextBox tbx_NVXuat_Nhap;
        private System.Windows.Forms.TextBox tbx_MaKH_NCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_MaKho;
        private System.Windows.Forms.TextBox tbx_MaSP;
        private System.Windows.Forms.TextBox tbx_MaPhieuX_N;
        private System.Windows.Forms.Label lb_ghichu;
        private System.Windows.Forms.Label lb_Tongtien;
        private System.Windows.Forms.Label lb_SL;
        private System.Windows.Forms.Label lb_ngay_xuat;
        private System.Windows.Forms.Button btn_quaylai;
        private System.Windows.Forms.Button bt_nhap;
        private System.Windows.Forms.Button bt_xuat;
        private System.Windows.Forms.Label lb_NV_xuat;
        private System.Windows.Forms.Label lb_MaKH;
        private System.Windows.Forms.Label lb_MaKho;
        private System.Windows.Forms.Label lb_MaPX;
        private System.Windows.Forms.Panel panel_QTX;
        private System.Windows.Forms.Label lb_MaSP;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}