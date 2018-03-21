using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_QLKH
{
    public partial class ThemTaiKhoan : Form
    {
        public ThemTaiKhoan()
        {
            InitializeComponent();
        }
        public static string Username = "";
        accessData acc = new accessData();

        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_MaNV, "SELECT MANV FROM NHANVIEN");
            acc.AutoComplete(tbx_QuyenHan, "SELECT QUYENHAN FROM DANGNHAP");

            dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP");
            dgvThemTK.ClearSelection();
            // INSERT

            //Dộ rộng cột
            dgvThemTK.Columns[0].Width = 120;
            dgvThemTK.Columns[1].Width = 105;
            dgvThemTK.Columns[2].Width = 100;
            dgvThemTK.Columns[3].Width = 120;
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (tbx_TDN.Text.Trim() == "" || tbx_MK.Text.Trim() == "" || tbx_MaNV.Text.Trim() == "" || tbx_QuyenHan.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!,", "Thông Báo!");
                tbx_TDN.Focus();
            }
            else
            {
                DataTable dttk = new DataTable();
                dttk = acc.CheckSql("select * from DANGNHAP where USERNAME ='" + tbx_TDN.Text + "'");
                DataTable dtnv = new DataTable();
                dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_MaNV.Text + "'");
                if (dttk.Rows.Count > 0 || dtnv.Rows.Count < 1 )
                {
                    MessageBox.Show("Tài Khoản đã tồn tại Hoặc Mã Nhân Viên không tồn tại!", "Lỗi");
                    tbx_MaNV.Clear();
                    tbx_TDN.Clear();
                    tbx_TDN.Focus();
                }
                else
                {
                    acc.Them_TaiKhoan(tbx_TDN.Text, tbx_MK.Text, tbx_MaNV.Text, tbx_QuyenHan.Text);
                    dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP");
                    tbx_MaNV.Clear();
                    tbx_MK.Clear();
                    tbx_TDN.Clear();
                    tbx_QuyenHan.Clear();
                    dgvThemTK.ClearSelection();
                }
            }          
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            dgvThemTK.BeginEdit(true);
            if (tbx_TDN.Text.Trim() == "" || tbx_MK.Text.Trim() == "" || tbx_MaNV.Text.Trim() == "" || tbx_QuyenHan.Text.Trim() == "" || dgvThemTK.SelectedCells == null)
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_TDN.Focus();
            }
            else
            {
                DataTable dtnv = new DataTable();
                dtnv = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_MaNV.Text + "'");
                if (dtnv.Rows.Count < 1 || tbx_TDN.Text != dgvThemTK.CurrentRow.Cells["USERNAME"].Value.ToString().Trim())
                {
                    MessageBox.Show("Tên Đăng Nhập đã bị thay đổi Hoặc Mã Nhân Viên không tồn tại!", "Lỗi");
                    tbx_TDN.Text = dgvThemTK.CurrentRow.Cells["USERNAME"].Value.ToString().Trim();
                    tbx_MaNV.Text = dgvThemTK.CurrentRow.Cells["MANV"].Value.ToString().Trim();

                }
                else
                {
                    if (tbx_MaNV.Text == dgvThemTK.CurrentRow.Cells["MANV"].Value.ToString() && tbx_MK.Text == dgvThemTK.CurrentRow.Cells["PASSWORD"].Value.ToString().Trim() && tbx_TDN.Text == dgvThemTK.CurrentRow.Cells["USERNAME"].Value.ToString().Trim() && tbx_QuyenHan.Text == dgvThemTK.CurrentRow.Cells["QUYENHAN"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Toàn Bộ Thông Tin Kho Hàng Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.CapNhat_TaiKhoan(tbx_TDN.Text, tbx_MK.Text, tbx_MaNV.Text, tbx_QuyenHan.Text);
                        dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP");
                        tbx_MaNV.Clear();
                        tbx_MK.Clear();
                        tbx_TDN.Clear();
                        tbx_QuyenHan.Clear();
                        dgvThemTK.ClearSelection();
                    }
                }               
            }
            dgvThemTK.EndEdit();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_TDN.Text.Trim() == "" || dgvThemTK.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Tên Đăng Nhập Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                tbx_TDN.Focus();
            }
            else
            {
                if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa tài Khoản Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    acc.Xoa_TaiKhoan(tbx_TDN.Text);
                    dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP");
                    tbx_MaNV.Clear();
                    tbx_MK.Clear();
                    tbx_TDN.Clear();
                    tbx_QuyenHan.Clear();
                    dgvThemTK.ClearSelection();
                }
                else
                {

                }
            }
        }
        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            if ( tbx_timkiem.Text.Trim() == "")
            {
                MessageBox.Show("Đề Nghị Bạn Nhập Từ Khóa Càn Tìm!", "Thông Báo!");
                return;
            }
            else
            {
                dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP Where USERNAME like '%" + tbx_timkiem.Text + "%' OR PASSWORD like '%" + tbx_timkiem.Text + "%' OR MANV like '%" + tbx_timkiem.Text + "%' OR QUYENHAN like '%" + tbx_timkiem.Text + "%' ");
                tbx_timkiem.Clear();
                dgvThemTK.ClearSelection();
            }
        }

        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            dgvThemTK.DataSource = acc.Select_Data("Select  * from DANGNHAP");
            dgvThemTK.ClearSelection();
            tbx_MaNV.Clear();
            tbx_MK.Clear();
            tbx_TDN.Clear();
            tbx_QuyenHan.Clear();
        }

        private void dgvThemTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_TDN.Text = dgvThemTK.CurrentRow.Cells["USERNAME"].Value.ToString().Trim();
                tbx_MK.Text = dgvThemTK.CurrentRow.Cells["PASSWORD"].Value.ToString().Trim();
                tbx_MaNV.Text = dgvThemTK.CurrentRow.Cells["MANV"].Value.ToString().Trim();
                tbx_QuyenHan.Text = dgvThemTK.CurrentRow.Cells["QUYENHAN"].Value.ToString().Trim();
            }
        }

        private void dgvThemTK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                bt_xoa_Click(sender, e);
            }
        }
    }
}
