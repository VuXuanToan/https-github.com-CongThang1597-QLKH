using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_QLKH
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();
        public static string filepath = "";

        // Xoa text trong TextBox
        public void ClearText()
        {
            tbx_masp.Clear();
            tbx_tensp.Clear();
            tbx_mancc.Clear();
            tbx_madm.Clear();
            tbx_serial.Clear();
            tbx_sl.Clear();
            tbx_phanloai.Clear();
            tbx_ghichu.Clear();
            tbx_timkiem.Clear();
            tbx_gia.Clear();
            pc_sanpham.Image = null;
            dateTimePicker_sd.Text = DateTime.Now.ToString("MM/dd/yyyy");
            tbx_masp.Focus();
            filepath = "";
            tbx_masp.Enabled = false;
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void SanPham_Load_1(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_masp, "SELECT MASP FROM SANPHAM");
            acc.AutoComplete(tbx_mancc, "SELECT MANCC FROM NHACUNGCAP");
            acc.AutoComplete(tbx_madm, "SELECT MADANHMUC FROM DANHMUC");

            dgvsanpham.DataSource = acc.Select_Data("Select * from SANPHAM");
            dgvsanpham.ClearSelection();
            tbx_masp.Enabled = false;
        }
        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImages = new OpenFileDialog();
            PictureBox objpt = new PictureBox();
            if (ofdImages.ShowDialog() == DialogResult.OK)
            {
                filepath = ofdImages.FileName;
                //MessageBox.Show(filepath);
                pc_sanpham.Image = Image.FromFile(filepath.ToString());
                pc_sanpham.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                filepath = "";
                //MessageBox.Show(filepath);
                pc_sanpham.Image = null;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_masp.Text.Trim() == "" || tbx_madm.Text.Trim() == "" || tbx_mancc.Text.Trim() == "" || tbx_sl.Text.Trim() == "" || tbx_gia.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_masp.Focus();
            }
            else
            {
                DataTable dtsp = new DataTable();
                DataTable dtncc = new DataTable();
                DataTable dtdm = new DataTable();
                dtsp = acc.CheckSql("select * from SANPHAM where MASP ='" + tbx_masp.Text + "'");
                dtncc = acc.CheckSql("select * from NHACUNGCAP where MANCC ='" + tbx_mancc.Text + "'");
                dtdm = acc.CheckSql("select * from DANHMUC where MADANHMUC ='" + tbx_madm.Text + "'");
                if (dtsp.Rows.Count > 0 || dtncc.Rows.Count < 1 || dtdm.Rows.Count < 1)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại Hoặc nhà cung cấp Hoặc danh mục không tồn tại!", "Lỗi");
                    tbx_masp.Clear();
                    tbx_mancc.Clear();
                    tbx_madm.Clear();
                    tbx_masp.Focus();

                }
                else
                {

                    if (tbx_masp.Text == dgvsanpham.CurrentRow.Cells["MASP"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Sản phẩm Này Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.Them_SanPham(tbx_masp.Text, tbx_tensp.Text, tbx_mancc.Text, float.Parse(tbx_gia.Text), tbx_madm.Text, tbx_serial.Text, dateTimePicker_sx.Value, dateTimePicker_sd.Value, tbx_ghichu.Text, int.Parse(tbx_sl.Text), tbx_phanloai.Text, filepath);
                        dgvsanpham.DataSource = acc.Select_Data("Select  * from SANPHAM");
                        ClearText();
                        dgvsanpham.ClearSelection();
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgvsanpham.BeginEdit(true);
            if (tbx_masp.Text.Trim() == "" || tbx_tensp.Text.Trim() == "" || tbx_mancc.Text.Trim() == "" || tbx_madm.Text.Trim() == ""/* || tbx_TenNV.Text.Trim() == "" || tbx_Email.Text.Trim() == "" || tbx_DienThoai.Text.Trim() == "" || tbx_DiaChi.Text.Trim() == "" || tbx_luong.Text.Trim() == "" */)
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin. Tối Thiểu Mã Danh Mục và Tên Sản Phẩm và Mã Danh Mục!", "Thông Báo!");
                tbx_masp.Focus();
            }
            else
            {
                DataTable dtpn = new DataTable();
                dtpn = acc.CheckSql("select * from DANHMUC where MADANHMUC ='" + tbx_madm.Text + "'");
                DataTable dtpx = new DataTable();
                dtpx = acc.CheckSql("select * from NHACUNGCAP where MANCC ='" + tbx_mancc.Text + "'");
                if (dtpn.Rows.Count < 1 || dtpx.Rows.Count < 1 || tbx_masp.Text != dgvsanpham.CurrentRow.Cells["MASP"].Value.ToString().Trim())
                {
                    MessageBox.Show("Mã Sản Phẩm không thể thay đổi Hoặc Danh Mục hoặc Nhà Cung Cấp không tồn tại!", "Lỗi");
                }
                else
                {
                    
                    if (filepath == dgvsanpham.CurrentRow.Cells["HINHANH"].Value.ToString() && tbx_masp.Text == dgvsanpham.CurrentRow.Cells["MASP"].Value.ToString() && tbx_tensp.Text == dgvsanpham.CurrentRow.Cells["TENSP"].Value.ToString().Trim() && tbx_mancc.Text == dgvsanpham.CurrentRow.Cells["MANCC"].Value.ToString().Trim() && tbx_gia.Text == dgvsanpham.CurrentRow.Cells["GIA"].Value.ToString().Trim() && tbx_madm.Text == dgvsanpham.CurrentRow.Cells["MADANHMUC"].Value.ToString().Trim() && tbx_serial.Text == dgvsanpham.CurrentRow.Cells["SERIAL"].Value.ToString().Trim() && tbx_sl.Text == dgvsanpham.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim() && tbx_phanloai.Text == dgvsanpham.CurrentRow.Cells["PHANLOAI"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Toàn Bộ Thông Tin Sản Phẩm Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.CapNhat_SanPham(tbx_masp.Text, tbx_tensp.Text, tbx_mancc.Text, float.Parse(tbx_gia.Text), tbx_madm.Text, tbx_serial.Text, dateTimePicker_sx.Value, dateTimePicker_sd.Value, tbx_ghichu.Text, int.Parse(tbx_sl.Text), tbx_phanloai.Text, filepath);
                        dgvsanpham.DataSource = acc.Select_Data("Select  * from SANPHAM");
                        dgvsanpham.ClearSelection();
                        ClearText();
                    }
                }

            }
            dgvsanpham.EndEdit();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_masp.Text.Trim() == "" || dgvsanpham.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã sản phẩm Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                tbx_masp.Focus();
            }
            else
            {
                DataTable dtpn = new DataTable();
                dtpn = acc.CheckSql("select * from CHITIETPHIEUNHAP where MASP ='" + tbx_masp.Text + "'");
                DataTable dtpx = new DataTable();
                dtpx = acc.CheckSql("select * from CHITIETPHIEUXUAT where MASP ='" + tbx_masp.Text + "'");
                if (dtpn.Rows.Count > 0 || dtpx.Rows.Count > 0 /*|| tbx_MaNV.Text != dgvNhanVien.CurrentRow.Cells["MANV"].Value.ToString() */)
                {
                    MessageBox.Show("Mã sản phẩm đã bị thay đổi Hoặc Mã sản phẩm Đang Tốn Tại ở Bảng chi tiết phiếu nhập, chi tiết phiếu xất. Vui Lòng Xóa MASP ở Bảng Liên Quan Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {

                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Nhân Viên Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //acc.Xoa_SanPham(tbx_masp.Text);
                        dgvsanpham.DataSource = acc.Select_Data("Select  * from SANPHAM");
                        dgvsanpham.ClearSelection();
                        ClearText();
                    }
                    else
                    {

                    }
                }
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            dgvsanpham.DataSource = acc.Select_Data("Select  * from SANPHAM");
            dgvsanpham.ClearSelection();
            ClearText();
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
                dgvsanpham.DataSource = acc.Select_Data("Select  * from SANPHAM Where MASP like '%" + tbx_timkiem.Text + "%' OR TENSP like '%" + tbx_timkiem.Text + "%' OR MANCC like '%" + tbx_timkiem.Text + "%' OR MADANHMUC like '%" + tbx_timkiem.Text + "%' ");
                tbx_timkiem.Clear();
                dgvsanpham.ClearSelection();
            }
        }

        private void dgvsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_masp.Text = dgvsanpham.CurrentRow.Cells["MASP"].Value.ToString().Trim();
                tbx_tensp.Text = dgvsanpham.CurrentRow.Cells["TENSP"].Value.ToString().Trim();
                tbx_mancc.Text = dgvsanpham.CurrentRow.Cells["MANCC"].Value.ToString().Trim();
                tbx_gia.Text = dgvsanpham.CurrentRow.Cells["GIA"].Value.ToString().Trim();
                tbx_madm.Text = dgvsanpham.CurrentRow.Cells["MADANHMUC"].Value.ToString().Trim();
                tbx_serial.Text = dgvsanpham.CurrentRow.Cells["SERIAL"].Value.ToString().Trim();
                tbx_ghichu.Text = dgvsanpham.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
                tbx_phanloai.Text = dgvsanpham.CurrentRow.Cells["PHANLOAI"].Value.ToString().Trim();
                tbx_sl.Text = dgvsanpham.CurrentRow.Cells["SOLUONG"].Value.ToString().Trim();
                dateTimePicker_sx.Text = dgvsanpham.CurrentRow.Cells["NGAYSANXUAT"].Value.ToString().Trim();
                dateTimePicker_sd.Text = dgvsanpham.CurrentRow.Cells["HANSUDUNG"].Value.ToString().Trim();
                filepath = dgvsanpham.CurrentRow.Cells["HINHANH"].Value.ToString();
                pc_sanpham.ImageLocation = filepath;
                pc_sanpham.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void dgvsanpham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        private void tbx_luong_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void btn_suamanv_Click_1(object sender, EventArgs e)
        {
            tbx_masp.Enabled = true;
        }

      

        private void SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
