using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _2017_QLKH
{
    public partial class NhapXuat : Form
    {
        public NhapXuat()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();
        int key = 0;


        public void ClearText()
        {
            tbx_MaPhieuX_N.Clear();
            tbx_MaKho.Clear();
            tbx_MaKH_NCC.Clear();
            tbx_MaSP.Clear();
            tbx_NVXuat_Nhap.Clear();
            tbx_soluong.Clear();
            tbx_GhiChu.Clear();
            tbx_TongTien.Clear();
            tbx_dongia.Clear();
            dgv_NhapXuat.ClearSelection();
            tbx_MaPhieuX_N.Enabled = false;
        }
        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void bt_nhap_Click(object sender, EventArgs e)
        {
            Nhap_load();
        }

        public void Nhap_load()
        {
            dgv_NhapXuat.DataSource = acc.Select_Data("SELECT N.MAPN, CTN.MASP, N.MAKHO, N.MANCC, N.NVNHAP, N.NGAYNHAP, CTN.SOLUONG,SP.GIA, CTN.TONGTIEN, N.GHICHU FROM PHIEUNHAPKHO N, CHITIETPHIEUNHAP CTN, SANPHAM SP WHERE N.MAPN = CTN.MAPN and CTN.MASP = SP.MASP");
            panel_QTX.Show();
            key = 1;
            lb_MaPX.Text = "Mã PN";
            lb_MaKH.Text = "Mã NCC";
            lb_NV_xuat.Text = "NV Nhập";
            lb_ngay_xuat.Text = "Ngày Nhập";
            ClearText();
            tbx_MaPhieuX_N.Focus();
            bt_nhap.BackColor = System.Drawing.Color.Coral;
            bt_xuat.BackColor = System.Drawing.Color.AliceBlue;
        }

        private void bt_xuat_Click(object sender, EventArgs e)
        {
            Xuat_Load();
        }

        public void Xuat_Load()
        {
            dgv_NhapXuat.DataSource = acc.Select_Data("SELECT X.MAPX, CTX.MASP, X.MAKHO, X.MAKH, X.NVXUAT, X.NGAYXUAT, CTX.SOLUONG,SP.GIA ,CTX.TONGTIEN, X.GHICHU FROM PHIEUXUAT X, CHITIETPHIEUXUAT CTX, SANPHAM SP WHERE X.MAPX = CTX.MAPX and CTX.MASP = SP.MASP");
            panel_QTX.Show();
            key = 2;
            lb_MaPX.Text = "Mã PX";
            lb_MaKH.Text = "Mã KH";
            lb_NV_xuat.Text = "NV Xuất";
            lb_ngay_xuat.Text = "Ngày Xuất";
            ClearText();
            tbx_MaPhieuX_N.Focus();
            bt_xuat.BackColor = System.Drawing.Color.Coral;
            bt_nhap.BackColor = System.Drawing.Color.AliceBlue;
        }

        private void NhapXuat_Load(object sender, EventArgs e)
        {
            bt_nhap_Click(sender, e);
            // key = 1: Nhập, key = 2: Xuất
            if (key == 1)
            {
                // Nhập
                acc.AutoComplete(tbx_MaPhieuX_N, "SELECT MAPN FROM PHIEUNHAPKHO");
                acc.AutoComplete(tbx_MaKH_NCC, "SELECT MANCC FROM NHACUNGCAP");
            }
            if (key == 2)
            {
                // Xuất
                acc.AutoComplete(tbx_MaPhieuX_N, "SELECT MAPX FROM PHIEUXUAT");
                acc.AutoComplete(tbx_MaKH_NCC, "SELECT MAKH FROM KHACHHANG");
            }
            acc.AutoComplete(tbx_MaKho, "SELECT MAKHO FROM KHOHANG");
            acc.AutoComplete(tbx_MaSP, "SELECT MASP FROM SANPHAM");
            acc.AutoComplete(tbx_NVXuat_Nhap, "SELECT MANV FROM NHANVIEN");
        }

        private void NhapXuat_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void dgv_NhapXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (key == 1)
                {
                    tbx_MaPhieuX_N.Text = dgv_NhapXuat.CurrentRow.Cells["MAPN"].Value.ToString().Trim();
                    tbx_MaSP.Text = dgv_NhapXuat.CurrentRow.Cells["MASP"].Value.ToString().Trim();
                    tbx_MaKho.Text = dgv_NhapXuat.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
                    tbx_MaKH_NCC.Text = dgv_NhapXuat.CurrentRow.Cells["MANCC"].Value.ToString().Trim();
                    tbx_NVXuat_Nhap.Text = dgv_NhapXuat.CurrentRow.Cells["NVNHAP"].Value.ToString().Trim();
                    tbx_soluong.Text = dgv_NhapXuat.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim();
                    tbx_dongia.Text = dgv_NhapXuat.CurrentRow.Cells["GIA"].Value.ToString().Trim();
                    tbx_TongTien.Text = dgv_NhapXuat.CurrentRow.Cells["TONGTIEN"].Value.ToString().Trim();
                    tbx_GhiChu.Text = dgv_NhapXuat.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
                    dateTimePicker_ngayN_X.Text = dgv_NhapXuat.CurrentRow.Cells["NGAYNHAP"].Value.ToString().Trim();
                }
                if (key == 2)
                {
                    tbx_MaPhieuX_N.Text = dgv_NhapXuat.CurrentRow.Cells["MAPX"].Value.ToString().Trim();
                    tbx_MaSP.Text = dgv_NhapXuat.CurrentRow.Cells["MASP"].Value.ToString().Trim();
                    tbx_MaKho.Text = dgv_NhapXuat.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
                    tbx_MaKH_NCC.Text = dgv_NhapXuat.CurrentRow.Cells["MAKH"].Value.ToString().Trim();
                    tbx_NVXuat_Nhap.Text = dgv_NhapXuat.CurrentRow.Cells["NVXUAT"].Value.ToString().Trim();
                    tbx_soluong.Text = dgv_NhapXuat.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim();
                    tbx_dongia.Text = dgv_NhapXuat.CurrentRow.Cells["GIA"].Value.ToString().Trim();
                    tbx_TongTien.Text = dgv_NhapXuat.CurrentRow.Cells["TONGTIEN"].Value.ToString().Trim();
                    tbx_GhiChu.Text = dgv_NhapXuat.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
                    dateTimePicker_ngayN_X.Text = dgv_NhapXuat.CurrentRow.Cells["NGAYXUAT"].Value.ToString().Trim();
                }

            }
        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            tbx_MaPhieuX_N.Enabled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_MaKho.Text.Trim() == "" || tbx_MaKH_NCC.Text.Trim() == "" || tbx_MaSP.Text.Trim() == "" || tbx_soluong.Text.Trim() == "" || tbx_NVXuat_Nhap.Text.Trim() == "" || tbx_dongia.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_MaPhieuX_N.Focus();
            }
            else
            {
                if (key == 1)
                {
                    Nhap_Nhap();
                }
                if (key == 2)
                {
                    Xuat_Xuat();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_NhapXuat.BeginEdit(true);
            if (tbx_MaPhieuX_N.Text.Trim() == "" || tbx_MaKho.Text.Trim() == "" || tbx_MaKH_NCC.Text.Trim() == "" || tbx_MaSP.Text.Trim() == "" || tbx_soluong.Text.Trim() == "" || tbx_NVXuat_Nhap.Text.Trim() == "" || tbx_dongia.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin Hoặc Chọn Dòng Bạn Muốn Sửa. Tối Thiểu MÃ PHIẾU + MAKHO + MASP + MAKH HOẶC MANCC!", "Thông Báo!");
                tbx_MaPhieuX_N.Focus();
            }
            else
            {
                // Nhập
                if (key == 1)
                {
                    DataTable dtkh = new DataTable();
                    DataTable dtkho = new DataTable();
                    DataTable dtsp = new DataTable();
                    DataTable dtnv = new DataTable();
                    dtkh = acc.CheckSql("select * from KHACHHANG where MAKH ='" + tbx_MaKH_NCC.Text + "'");
                    dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
                    dtsp = acc.CheckSql("select * from SANPHAM where MASP ='" + tbx_MaSP.Text + "'");
                    dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NVXuat_Nhap.Text + "'");
                    if (tbx_MaPhieuX_N.Text != dgv_NhapXuat.CurrentRow.Cells["MAPN"].Value.ToString().Trim() || dtkho.Rows.Count < 1 || dtkh.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã Phiếu đã bị thay đổi Hoặc Mã Kho, Mã SP, Mã NV, Mã KH không tồn tại!", "Lỗi");
                    }
                    else
                    {
                        int sl = Convert.ToInt32(tbx_soluong.Text);
                        float gia = float.Parse(tbx_dongia.Text);
                        float tong = (sl * gia);
                        tbx_TongTien.Text = tong.ToString();
                        acc.CapNhat_Nhap(tbx_MaPhieuX_N.Text, tbx_MaSP.Text, tbx_MaKho.Text, tbx_MaKH_NCC.Text, tbx_NVXuat_Nhap.Text, dateTimePicker_ngayN_X.Value, Convert.ToInt32(tbx_soluong.Text), float.Parse(tbx_TongTien.Text), tbx_GhiChu.Text);
                        bt_nhap_Click(sender, e);
                    }
                }
                // Xuất
                if (key == 2)
                {
                    DataTable dtncc = new DataTable();
                    DataTable dtkho = new DataTable();
                    DataTable dtsp = new DataTable();
                    DataTable dtnv = new DataTable();
                    dtncc = acc.CheckSql("select * from NHACUNGCAP where MANCC ='" + tbx_MaKH_NCC.Text + "'");
                    dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
                    dtsp = acc.CheckSql("select * from SANPHAM where MASP ='" + tbx_MaSP.Text + "'");
                    dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NVXuat_Nhap.Text + "'");
                    if (tbx_MaPhieuX_N.Text != dgv_NhapXuat.CurrentRow.Cells["MAPX"].Value.ToString().Trim() || dtkho.Rows.Count < 1 || dtncc.Rows.Count < 1)
                    {
                        MessageBox.Show("Mã Phiếu đã bị thay đổi Hoặc Mã Kho, Mã SP, Mã NV, Mã KH không tồn tại!", "Lỗi");
                    }
                    else
                    {
                        int sl = Convert.ToInt32(tbx_soluong.Text);
                        float gia = float.Parse(tbx_dongia.Text);
                        float tong = (sl * gia);
                        tbx_TongTien.Text = tong.ToString();
                        acc.CapNhat_Xuat(tbx_MaPhieuX_N.Text, tbx_MaSP.Text, tbx_MaKho.Text, tbx_MaKH_NCC.Text, tbx_NVXuat_Nhap.Text, dateTimePicker_ngayN_X.Value, Convert.ToInt32(tbx_soluong.Text), float.Parse(tbx_TongTien.Text), tbx_GhiChu.Text);
                        bt_xuat_Click(sender, e);
                    }
                }
            }
            dgv_NhapXuat.EndEdit();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

            if (tbx_MaPhieuX_N.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Mã Phiếu Hoặc Chọn Dòng Bạn Muốn Xóa!", "Thông Báo!");
                tbx_MaPhieuX_N.Focus();
            }
            else
            {
                if (key == 1)
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Bộ Phận Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_Nhap(tbx_MaPhieuX_N.Text);
                        bt_nhap_Click(sender, e);
                    }
                    else
                    {

                    }
                }
                if (key == 2)
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Bộ Phận Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_Xuat(tbx_MaPhieuX_N.Text);
                        bt_xuat_Click(sender, e);
                    }
                    else
                    {

                    }
                }

            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            if (tbx_timkiem.Text.Trim() == "")
            {
                MessageBox.Show("Đề Nghị Bạn Nhập Từ Khóa Càn Tìm!", "Thông Báo!");
                return;
            }
            else
            {
                if (key == 1)
                {
                    dgv_NhapXuat.DataSource = acc.Select_Data("SELECT N.MAPN, CTN.MASP, N.MAKHO, N.MANCC, N.NVNHAP, N.NGAYNHAP, CTN.SOLUONG,SP.GIA, CTN.TONGTIEN, N.GHICHU FROM PHIEUNHAPKHO N, CHITIETPHIEUNHAP CTN, SANPHAM SP WHERE N.MAPN = CTN.MAPN and CTN.MASP = SP.MASP AND N.MAPN like N'%" + tbx_timkiem.Text + "%' OR CTN.MASP like N'%" + tbx_timkiem.Text + "%' OR N.MAKHO like N'%" + tbx_timkiem.Text + "%' OR N.MANCC like N'%" + tbx_timkiem.Text + "%' OR N.NVNHAP like N'%" + tbx_timkiem.Text + "%' OR N.NGAYNHAP like N'%" + tbx_timkiem.Text + "%' OR CTN.SOLUONG like N'%" + tbx_timkiem.Text + "%' OR CTN.TONGTIEN like N'%" + tbx_timkiem.Text + "%' OR N.GHICHU like N'%" + tbx_timkiem.Text + "%' OR SP.GIA like N'%" + tbx_timkiem.Text + "%'");
                    tbx_timkiem.Clear();
                    dgv_NhapXuat.ClearSelection();
                }
                if (key == 2)
                {
                    dgv_NhapXuat.DataSource = acc.Select_Data("SELECT X.MAPX, CTX.MASP, X.MAKHO, X.MAKH, X.NVXUAT, X.NGAYXUAT, CTX.SOLUONG,SP.GIA ,CTX.TONGTIEN, X.GHICHU FROM PHIEUXUAT X, CHITIETPHIEUXUAT CTX, SANPHAM SP WHERE X.MAPX = CTX.MAPX and CTX.MASP = SP.MASP AND X.MAPX like N'%" + tbx_timkiem.Text + "%' OR CTX.MASP like N'%" + tbx_timkiem.Text + "%' OR X.MAKHO like N'%" + tbx_timkiem.Text + "%' OR X.MAKH like N'%" + tbx_timkiem.Text + "%' OR X.NVXUAT like N'%" + tbx_timkiem.Text + "%' OR X.NGAYXUAT like N'%" + tbx_timkiem.Text + "%' OR CTX.SOLUONG like N'%" + tbx_timkiem.Text + "%' OR CTX.TONGTIEN like N'%" + tbx_timkiem.Text + "%' OR X.GHICHU like N'%" + tbx_timkiem.Text + "%' OR SP.GIA like N'%" + tbx_timkiem.Text + "%'");
                    tbx_timkiem.Clear();
                    dgv_NhapXuat.ClearSelection();
                    bt_xuat_Click(sender, e);
                }
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            if (key == 1)
            {
                bt_nhap_Click(sender, e);
            }
            if (key == 2)
            {
                bt_xuat_Click(sender, e);
            }
        }

        private void dgv_NhapXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        public void Nhap_Nhap()
        {
            DataTable dtkho = new DataTable();
            DataTable dtsp = new DataTable();
            DataTable dtnv = new DataTable();
            DataTable dtncc = new DataTable();
            DataTable dtnhap = new DataTable();
            dtnhap = acc.CheckSql("select * from PHIEUNHAPKHO where MAPN ='" + tbx_MaPhieuX_N.Text + "'");
            dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NVXuat_Nhap.Text + "'");
            dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
            dtsp = acc.CheckSql("select * from SANPHAM where MASP ='" + tbx_MaSP.Text + "'");
            dtncc = acc.CheckSql("select * from NHACUNGCAP where MANCC ='" + tbx_MaKH_NCC.Text + "'");
            if (dtnhap.Rows.Count > 0 || dtnv.Rows.Count < 1 || dtkho.Rows.Count < 1 || dtsp.Rows.Count < 1 || dtncc.Rows.Count < 1)
            {
                MessageBox.Show("Phiếu Nhập đã tồn tại Hoặc Mã Nhân Viên, Mã Kho, Mã Sản Phẩm, Mã Nhà Cung Cấp không tồn tại!", "Lỗi");
                tbx_MaPhieuX_N.Clear();
                tbx_MaPhieuX_N.Focus();
                tbx_MaKho.Clear();
                tbx_NVXuat_Nhap.Clear();
                tbx_MaKho.Clear();
                tbx_MaKH_NCC.Clear();
                tbx_MaSP.Clear();
            }
            else
            {
                if (tbx_MaPhieuX_N.Text == dgv_NhapXuat.CurrentRow.Cells["MAPN"].Value.ToString() && tbx_MaSP.Text == dgv_NhapXuat.CurrentRow.Cells["MASP"].Value.ToString().Trim() && tbx_MaKho.Text == dgv_NhapXuat.CurrentRow.Cells["MAKHO"].Value.ToString().Trim() && tbx_MaKH_NCC.Text == dgv_NhapXuat.CurrentRow.Cells["MANCC"].Value.ToString().Trim() && tbx_NVXuat_Nhap.Text == dgv_NhapXuat.CurrentRow.Cells["NVNHAP"].Value.ToString().Trim() && tbx_dongia.Text == dgv_NhapXuat.CurrentRow.Cells["GIA"].Value.ToString().Trim() && tbx_GhiChu.Text == dgv_NhapXuat.CurrentRow.Cells["GHICHU"].Value.ToString().Trim() && tbx_soluong.Text == dgv_NhapXuat.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim() && tbx_TongTien.Text == dgv_NhapXuat.CurrentRow.Cells["TONGTIEN"].Value.ToString().Trim() && dateTimePicker_ngayN_X.Text == dgv_NhapXuat.CurrentRow.Cells["NGAYNHAP"].Value.ToString().Trim())
                {
                    MessageBox.Show("Toàn Bộ Thông Tin Bộ Phận Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                }
                else
                {
                    int sl = Convert.ToInt32(tbx_soluong.Text);
                    float gia = float.Parse(tbx_dongia.Text);
                    float tong = (sl * gia);
                    tbx_TongTien.Text = tong.ToString();
                    acc.Them_Nhap(tbx_MaPhieuX_N.Text, tbx_MaKho.Text, tbx_MaKH_NCC.Text, tbx_NVXuat_Nhap.Text, dateTimePicker_ngayN_X.Value, tbx_GhiChu.Text);
                    acc.Them_CtNhap(tbx_MaPhieuX_N.Text, tbx_MaSP.Text,Convert.ToInt32(tbx_soluong.Text), float.Parse(tbx_TongTien.Text));
                    Nhap_load();
                }
            }
        }

        public void Xuat_Xuat()
        {
            DataTable dtkho = new DataTable();
            DataTable dtsp = new DataTable();
            DataTable dtnv = new DataTable();
            DataTable dtncc = new DataTable();
            DataTable dtnhap = new DataTable();
            dtnhap = acc.CheckSql("select * from PHIEUXUAT where MAPX ='" + tbx_MaPhieuX_N.Text + "'");
            dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NVXuat_Nhap.Text + "'");
            dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
            dtsp = acc.CheckSql("select * from SANPHAM where MASP ='" + tbx_MaSP.Text + "'");
            dtncc = acc.CheckSql("select * from KHACHHANG where MAKH ='" + tbx_MaKH_NCC.Text + "'");
            if (dtnhap.Rows.Count > 0 || dtnv.Rows.Count < 1 || dtkho.Rows.Count < 1 || dtsp.Rows.Count < 1 || dtncc.Rows.Count < 1)
            {
                MessageBox.Show("Phiếu Xuất đã tồn tại Hoặc Mã Nhân Viên, Mã Kho, Mã Sản Phẩm, Mã Khách Hàng không tồn tại!", "Lỗi");
                tbx_MaPhieuX_N.Clear();
                tbx_MaPhieuX_N.Focus();
                tbx_MaKho.Clear();
                tbx_NVXuat_Nhap.Clear();
                tbx_MaKho.Clear();
                tbx_MaKH_NCC.Clear();
                tbx_MaSP.Clear();
            }
            else
            {
                if (tbx_MaPhieuX_N.Text == dgv_NhapXuat.CurrentRow.Cells["MAPX"].Value.ToString() && tbx_MaSP.Text == dgv_NhapXuat.CurrentRow.Cells["MASP"].Value.ToString().Trim() && tbx_MaKho.Text == dgv_NhapXuat.CurrentRow.Cells["MAKHO"].Value.ToString().Trim() && tbx_MaKH_NCC.Text == dgv_NhapXuat.CurrentRow.Cells["MAKH"].Value.ToString().Trim() && tbx_NVXuat_Nhap.Text == dgv_NhapXuat.CurrentRow.Cells["NVXUAT"].Value.ToString().Trim() && tbx_dongia.Text == dgv_NhapXuat.CurrentRow.Cells["GIA"].Value.ToString().Trim() && tbx_GhiChu.Text == dgv_NhapXuat.CurrentRow.Cells["GHICHU"].Value.ToString().Trim() && tbx_soluong.Text == dgv_NhapXuat.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim() && tbx_TongTien.Text == dgv_NhapXuat.CurrentRow.Cells["TONGTIEN"].Value.ToString().Trim() && dateTimePicker_ngayN_X.Text == dgv_NhapXuat.CurrentRow.Cells["NGAYXUAT"].Value.ToString().Trim())
                {
                    MessageBox.Show("Toàn Bộ Thông Tin Bộ Phận Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                }
                else
                {
                    int sl = Convert.ToInt32(tbx_soluong.Text);
                    float gia = float.Parse(tbx_dongia.Text);
                    float tong = (sl * gia);
                    tbx_TongTien.Text = tong.ToString();
                    acc.Them_Xuat(tbx_MaPhieuX_N.Text, tbx_MaSP.Text, tbx_MaKho.Text, tbx_MaKH_NCC.Text, tbx_NVXuat_Nhap.Text, dateTimePicker_ngayN_X.Value, Convert.ToInt32(tbx_soluong.Text), float.Parse(tbx_TongTien.Text), tbx_GhiChu.Text);
                    Xuat_Load();
                }
            }
        }

        private void NhapXuat_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
