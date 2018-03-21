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
    public partial class DanhMucSP : Form
    {
        public DanhMucSP()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();

        public void ClearText()
        {
            tbx_MaDN.Clear();
            tbx_TenDM.Clear();
            tbx_ghichu.Clear();
            tbx_makho.Clear();
            tbx_MaDN.Enabled = false;
            dgv_dmsanpham.ClearSelection();
            tbx_MaDN.Focus();
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu Menu = new MainMenu();
            Menu.ShowDialog();
        }

        private void DanhMucSP_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_MaDN, "SELECT MADANHMUC FROM DANHMUC");
            acc.AutoComplete(tbx_makho, "SELECT MAKHO FROM KHOHANG");

            dgv_dmsanpham.DataSource = acc.Select_Data("SELECT * FROM DANHMUC");
            ClearText();

            dgv_dmsanpham.Columns[0].Width = 100;
            dgv_dmsanpham.Columns[1].Width = 100;
            dgv_dmsanpham.Columns[2].Width = 130;
            dgv_dmsanpham.Columns[3].Width = 100;

        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (tbx_TenDM.Text.Trim() == "" || tbx_makho.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!,", "Thông Báo!");
                tbx_MaDN.Focus();
            }
            else
            {
                DataTable dtdm = new DataTable();
                dtdm = acc.CheckSql("select * from DANHMUC where MADANHMUC ='" + tbx_MaDN.Text + "'");
                DataTable dtkho = new DataTable();
                dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_makho.Text + "'");
                if (dtdm.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Danh Mục SP đã tồn tại Hoặc mã Kho Chưa Tồn Tại!", "Lỗi");
                    tbx_MaDN.Clear();
                    tbx_MaDN.Focus();
                }
                else
                {
                    acc.Them_DanhMuc(tbx_MaDN.Text, tbx_TenDM.Text, tbx_ghichu.Text, tbx_makho.Text);
                    DanhMucSP_Load(sender, e);
               }
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            dgv_dmsanpham.BeginEdit(true);
            if (tbx_MaDN.Text == "" || tbx_makho.Text == "" || tbx_TenDM.Text == "")
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_MaDN.Focus();
            }
            else
            {
            if (tbx_MaDN.Text != dgv_dmsanpham.CurrentRow.Cells["MADANHMUC"].Value.ToString().Trim() || tbx_MaDN.Text == "")
            {
                MessageBox.Show("Mã Danh Mục SP chưa được nhập hoặc đã bị thay đổi!", "Lỗi");
            }
            else
            {
                if (tbx_TenDM.Text == dgv_dmsanpham.CurrentRow.Cells["TENDANHMUC"].Value.ToString().Trim() && tbx_ghichu.Text == dgv_dmsanpham.CurrentRow.Cells["GHICHU"].Value.ToString().Trim() && tbx_makho.Text == dgv_dmsanpham.CurrentRow.Cells["MAKHO"].Value.ToString().Trim())
                {
                    MessageBox.Show("Toàn Bộ Thông Tin Danh Mục SP Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                }
                else
                {

                    acc.CapNhat_DanhMuc(tbx_MaDN.Text, tbx_TenDM.Text, tbx_ghichu.Text, tbx_makho.Text);
                    DanhMucSP_Load(sender, e);
                }
            }
            }
            dgv_dmsanpham.EndEdit();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_MaDN.Text.Trim() == "" || dgv_dmsanpham.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã Danh Mục SP Muốn Xóa Hoặc Chọn Dòng Muốn Xóa!,", "Cảnh Báo!");
                tbx_MaDN.Focus();
            }
            else
            {
                DataTable dtsp = new DataTable();
                dtsp = acc.CheckSql("select * from SANPHAM where MADANHMUC ='" + tbx_MaDN.Text + "'");
                if (dtsp.Rows.Count > 0 /* || tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() */)
                {
                    MessageBox.Show("Mã Nhà Cung Cấp đã bị thay đổi Hoặc Mã Nhà Cung Cấp Đang Tốn Tại Ơ Bảng Sản Phẩm, Phiếu Xuất. Vui Lòng Xóa MANCC ở Bảng Sản Phẩm, Phiếu Xuất Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Nhà Cung Cấp Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_DanhMuc(tbx_MaDN.Text);
                        DanhMucSP_Load(sender, e);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            tbx_MaDN.Enabled = true;
            tbx_MaDN.Focus();
        }

        private void dgv_dmsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_MaDN.Text = dgv_dmsanpham.CurrentRow.Cells["MADANHMUC"].Value.ToString().Trim();
                tbx_TenDM.Text = dgv_dmsanpham.CurrentRow.Cells["TENDANHMUC"].Value.ToString().Trim();
                tbx_ghichu.Text = dgv_dmsanpham.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
                tbx_makho.Text = dgv_dmsanpham.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
            }
        }

        private void dgv_dmsanpham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                bt_xoa_Click(sender, e);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            DanhMucSP_Load(sender, e);
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
                dgv_dmsanpham.DataSource = acc.Select_Data("Select  * from DANHMUC Where MADANHMUC like N'%" + tbx_timkiem.Text + "%' OR TENDANHMUC like N'%" + tbx_timkiem.Text + "%' OR GHICHU like N'%" + tbx_timkiem.Text + "%'  OR MAKHO like N'%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dgv_dmsanpham.ClearSelection();
            }
        }

        private void DanhMucSP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
