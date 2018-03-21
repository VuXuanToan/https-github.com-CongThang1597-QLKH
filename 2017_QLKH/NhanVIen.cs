using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_QLKH
{
    public partial class NhanVIen : Form
    {
        public NhanVIen()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();
        public static string filepath = "";


        // Xóa text trong TextBox
        public void ClearText()
        {
            tbx_MaNV.Clear();
            tbx_TenNV.Clear();
            tbx_Email.Clear();
            tbx_DienThoai.Clear();
            tbx_DiaChi.Clear();
            tbx_luong.Clear();
            tbx_MaBP.Clear();
            tbx_chucvu.Clear();
            rbtn_Nam.Checked = true;
            pc_nhanvien.Image = null;
            dateTimePicker_NS.Text = DateTime.Now.ToShortDateString();
            tbx_MaNV.Focus();
            filepath = "";
            tbx_MaNV.Enabled = false;
        }

       
        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void NhanVIen_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_MaNV, "SELECT MANV FROM NHANVIEN");
            acc.AutoComplete(tbx_MaBP, "SELECT MABP FROM BOPHAN");
            acc.AutoComplete(tbx_chucvu, "SELECT CHUCVU FROM NHANVIEN");

            dgvNhanVien.DataSource = acc.Select_Data("Select * from NHANVIEN");
            dgvNhanVien.ClearSelection();
            tbx_MaNV.Enabled = false;
            rbtn_Nam.Checked = true;

            dgvNhanVien.Columns["MANV"].Width = 70;
            dgvNhanVien.Columns["GT"].Width = 60;
            dgvNhanVien.Columns["TENNV"].Width = 150;
            dgvNhanVien.Columns["MABP"].Width = 80;
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImages = new OpenFileDialog();
            PictureBox objpt = new PictureBox();
            if (ofdImages.ShowDialog() == DialogResult.OK)
            {
                filepath = ofdImages.FileName;
                //MessageBox.Show(filepath);
                pc_nhanvien.Image = Image.FromFile(filepath.ToString());
                pc_nhanvien.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                filepath = "";
                //MessageBox.Show(filepath);
                pc_nhanvien.Image = null;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_TenNV.Text.Trim() == "" || tbx_Email.Text.Trim() == "" || tbx_DienThoai.Text.Trim() == "" || tbx_DiaChi.Text.Trim() == "" || tbx_luong.Text.Trim() == "" || tbx_MaBP.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_MaNV.Focus();
            }
            else
            { 
                DataTable dtnv = new DataTable();
                DataTable dtbp = new DataTable();
                dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_MaNV.Text + "'");
                dtbp = acc.CheckSql("select * from BOPHAN where MABP ='" + tbx_MaBP.Text + "'");
                if (dtnv.Rows.Count > 0 || dtbp.Rows.Count < 1)
                {
                    MessageBox.Show("Nhân Viên đã tồn tại Hoặc Phòng Ban không tồn tại!", "Lỗi");
                    tbx_MaNV.Clear();
                    tbx_MaNV.Focus();
                    tbx_MaBP.Clear();
                }
                else
                {
                    string gt = "NAM";
                    if (rbtn_Nu.Checked == true)
                    {
                        gt = "NỮ";
                    }
                    if (tbx_TenNV.Text == dgvNhanVien.CurrentRow.Cells["TENNV"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Nhân Viên Này Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.Them_NhanVien(tbx_MaNV.Text, tbx_TenNV.Text, tbx_Email.Text, dateTimePicker_NS.Value, gt, tbx_DienThoai.Text, tbx_chucvu.Text, filepath, tbx_DiaChi.Text, float.Parse(tbx_luong.Text), tbx_MaBP.Text);
                        dgvNhanVien.DataSource = acc.Select_Data("Select  * from NHANVIEN");
                        ClearText();
                        dgvNhanVien.ClearSelection();
                    }
                }                    
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgvNhanVien.BeginEdit(true);
            if (tbx_MaNV.Text.Trim() == "" || tbx_luong.Text.Trim() == "" || tbx_MaBP.Text.Trim() == "" /* || tbx_TenNV.Text.Trim() == "" || tbx_Email.Text.Trim() == "" || tbx_DienThoai.Text.Trim() == "" || tbx_DiaChi.Text.Trim() == "" || tbx_luong.Text.Trim() == "" */)
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin. Tối Thiểu Mã NV và Lương Và MaBP!", "Thông Báo!");
                tbx_MaNV.Focus();
            }
            else
            {
                DataTable dtbp = new DataTable();
                dtbp = acc.CheckSql("select * from BOPHAN where MABP ='" + tbx_MaBP.Text + "'");
            if (dtbp.Rows.Count < 1 || tbx_MaNV.Text != dgvNhanVien.CurrentRow.Cells["MANV"].Value.ToString().Trim())
            {
                MessageBox.Show("Mã Nhân Viên không thể thay đổi Hoặc Phòng Ban không tồn tại!", "Lỗi");
            }
            else
            {
                string gt = "NAM";
                if (rbtn_Nu.Checked == true)
                {
                    gt = "NỮ";
                }
                if (filepath == dgvNhanVien.CurrentRow.Cells["HINHANH"].Value.ToString() && gt == dgvNhanVien.CurrentRow.Cells["GT"].Value.ToString() && tbx_TenNV.Text == dgvNhanVien.CurrentRow.Cells["TENNV"].Value.ToString().Trim() && tbx_MaBP.Text == dgvNhanVien.CurrentRow.Cells["MABP"].Value.ToString().Trim() && tbx_luong.Text == dgvNhanVien.CurrentRow.Cells["LUONG"].Value.ToString().Trim() && tbx_Email.Text == dgvNhanVien.CurrentRow.Cells["EMAIL"].Value.ToString().Trim() && tbx_DienThoai.Text == dgvNhanVien.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim() && tbx_DiaChi.Text == dgvNhanVien.CurrentRow.Cells["DIACHI"].Value.ToString().Trim() && tbx_chucvu.Text == dgvNhanVien.CurrentRow.Cells["CHUCVU"].Value.ToString().Trim())
                {
                    MessageBox.Show("Toàn Bộ Thông Tin Nhân Viên Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                }
                else
                {
                    acc.CapNhat_NhanVien(tbx_MaNV.Text, tbx_TenNV.Text, tbx_Email.Text, dateTimePicker_NS.Value, gt, tbx_DienThoai.Text, tbx_chucvu.Text, filepath, tbx_DiaChi.Text, float.Parse(tbx_luong.Text), tbx_MaBP.Text);
                    dgvNhanVien.DataSource = acc.Select_Data("Select  * from NHANVIEN");
                    dgvNhanVien.ClearSelection();
                    ClearText();
                }
            }

            }
            dgvNhanVien.EndEdit();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_MaNV.Text.Trim() == "" || dgvNhanVien.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã Nhân Viên Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                tbx_MaNV.Focus();
            }
            else
            {
                DataTable dtbp = new DataTable();
                dtbp = acc.CheckSql("select * from BOPHAN where NQL ='" + tbx_MaNV.Text + "'");
                DataTable dtnv = new DataTable();
                dtnv = acc.CheckSql("select * from DANGNHAP where MANV ='" + tbx_MaNV.Text + "'");
                if (dtbp.Rows.Count > 0  || dtnv.Rows.Count > 0 /*|| tbx_MaNV.Text != dgvNhanVien.CurrentRow.Cells["MANV"].Value.ToString() */)
                {
                    MessageBox.Show("Mã Nhân Viên đã bị thay đổi Hoặc Mã Nhân Viên Đang Tốn Tại Ơ Bảng Bộ Phận, Đăng Nhập. Vui Lòng Xóa MANV ở Bảng Liên Quan Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {

                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Nhân Viên Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_NhanVien(tbx_MaNV.Text);
                        dgvNhanVien.DataSource = acc.Select_Data("Select  * from NHANVIEN");
                        dgvNhanVien.ClearSelection();
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
            dgvNhanVien.DataSource = acc.Select_Data("Select  * from NHANVIEN");
            dgvNhanVien.ClearSelection();
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
                dgvNhanVien.DataSource = acc.Select_Data("Select  * from NHANVIEN Where MANV like '%" + tbx_timkiem.Text + "%' OR TENNV like '%" + tbx_timkiem.Text + "%' OR EMAIL like '%" + tbx_timkiem.Text + "%' OR NS like '%" + tbx_timkiem.Text + "%' OR GT like N'%" + tbx_timkiem.Text + "%' OR DIENTHOAI like '%" + tbx_timkiem.Text + "%' OR CHUCVU like '%" + tbx_timkiem.Text + "%' OR DIACHI like '%" + tbx_timkiem.Text + "%' OR LUONG like '%" + tbx_timkiem.Text + "%' OR MABP like '%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dgvNhanVien.ClearSelection();
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_MaNV.Text = dgvNhanVien.CurrentRow.Cells["MANV"].Value.ToString().Trim();
                tbx_TenNV.Text = dgvNhanVien.CurrentRow.Cells["TENNV"].Value.ToString().Trim();
                tbx_Email.Text = dgvNhanVien.CurrentRow.Cells["EMAIL"].Value.ToString().Trim();
                tbx_DienThoai.Text = dgvNhanVien.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim();
                tbx_DiaChi.Text = dgvNhanVien.CurrentRow.Cells["DIACHI"].Value.ToString().Trim();
                tbx_luong.Text = dgvNhanVien.CurrentRow.Cells["LUONG"].Value.ToString().Trim();
                tbx_MaBP.Text = dgvNhanVien.CurrentRow.Cells["MABP"].Value.ToString().Trim();
                if (dgvNhanVien.CurrentRow.Cells["GT"].Value.ToString() == "Nam")
                {
                    rbtn_Nam.Checked = true;
                }
                else
                {
                    rbtn_Nu.Checked = true;
                }
                tbx_chucvu.Text = dgvNhanVien.CurrentRow.Cells["CHUCVU"].Value.ToString().Trim();
                dateTimePicker_NS.Text = dgvNhanVien.CurrentRow.Cells["NS"].Value.ToString().Trim();
                filepath = dgvNhanVien.CurrentRow.Cells["HINHANH"].Value.ToString();
                pc_nhanvien.ImageLocation = filepath;
                pc_nhanvien.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void dgvNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        private void tbx_luong_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_suamanv_Click(object sender, EventArgs e)
        {
            tbx_MaNV.Enabled = true;
        }

        private void NhanVIen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
