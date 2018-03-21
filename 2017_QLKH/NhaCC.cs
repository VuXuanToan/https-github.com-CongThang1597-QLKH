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
    public partial class NhaCC : Form
    {
        public NhaCC()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();

        public void ClearText()
        {
            tbx_MaNCC.Clear();
            tbx_TenNCC.Clear();
            tbx_Diachi.Clear();
            tbx_Ghichu.Clear();
            tbx_MaNCC.Focus();
            dgv_nhacungcap.ClearSelection();
            tbx_MaNCC.Enabled = false;
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void NhaCC_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_MaNCC, "SELECT MANCC FROM NHACUNGCAP");
            dgv_nhacungcap.DataSource = acc.Select_Data("SELECT * FROM NHACUNGCAP");
            ClearText();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_TenNCC.Text.Trim() == "" || tbx_Diachi.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!,", "Thông Báo!");
                tbx_MaNCC.Focus();
            }
            else
            {
                DataTable dtncc = new DataTable();
                dtncc = acc.CheckSql("select * from NHACUNGCAP where MANCC ='" + tbx_MaNCC.Text + "'");
                if (dtncc.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Nhà Cung Cấp đã tồn tại!", "Lỗi");
                    tbx_MaNCC.Clear();
                    tbx_MaNCC.Focus();
                }
                else
                {
                    if (tbx_TenNCC.Text == dgv_nhacungcap.CurrentRow.Cells["TENNHACC"].Value.ToString().Trim() && tbx_Ghichu.Text == dgv_nhacungcap.CurrentRow.Cells["GHICHU"].Value.ToString().Trim() && tbx_Diachi.Text == dgv_nhacungcap.CurrentRow.Cells["DIACHI"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Toàn Bộ Thông Tin Nhà Cung Cấp Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.Them_NhaCC(tbx_MaNCC.Text, tbx_TenNCC.Text, tbx_Diachi.Text, tbx_Ghichu.Text);
                        NhaCC_Load(sender, e);
                    }
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_MaNCC.Text.Trim() == "" || dgv_nhacungcap.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã Nhà Cung Cấp Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                tbx_MaNCC.Focus();
            }
            else
            {
                DataTable dtsp = new DataTable();
                dtsp = acc.CheckSql("select * from SANPHAM where MANCC ='" + tbx_MaNCC.Text + "'");
                DataTable dtnk = new DataTable();
                dtnk = acc.CheckSql("select * from PHIEUNHAPKHO where MANCC ='" + tbx_MaNCC.Text + "'");
                if (dtsp.Rows.Count > 0 || dtnk.Rows.Count > 0 /* || tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() */)
                {
                    MessageBox.Show("Mã Nhà Cung Cấp đã bị thay đổi Hoặc Mã Nhà Cung Cấp Đang Tốn Tại Ơ Bảng Sản Phẩm, Phiếu Xuất. Vui Lòng Xóa MANCC ở Bảng Sản Phẩm, Phiếu Xuất Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Nhà Cung Cấp Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_NhaCC(tbx_MaNCC.Text);
                        NhaCC_Load(sender, e);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_nhacungcap.BeginEdit(true);
            if (tbx_MaNCC.Text == "" || tbx_TenNCC.Text == "" || tbx_Diachi.Text == "")
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_MaNCC.Focus();
            }
            else
            {
                if (tbx_MaNCC.Text != dgv_nhacungcap.CurrentRow.Cells["MANCC"].Value.ToString().Trim() || tbx_MaNCC.Text == "")
                {
                    MessageBox.Show("Mã Nhà Cung Cấp chưa được nhập hoặc đã bị thay đổi!", "Lỗi");
                }
                else
                {
                    acc.CapNhat_NhaCC(tbx_MaNCC.Text, tbx_TenNCC.Text, tbx_Diachi.Text, tbx_Ghichu.Text);
                    NhaCC_Load(sender, e);
                }
            }
            dgv_nhacungcap.EndEdit();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            NhaCC_Load(sender, e);
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
                dgv_nhacungcap.DataSource = acc.Select_Data("Select  * from NHACUNGCAP Where MANCC like N'%" + tbx_timkiem.Text + "%' OR TENNHACC like N'%" + tbx_timkiem.Text + "%' OR DIACHI like N'%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dgv_nhacungcap.ClearSelection();
            }
        }

        private void dgv_nhacungcap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        private void dgv_nhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_MaNCC.Text = dgv_nhacungcap.CurrentRow.Cells["MANCC"].Value.ToString().Trim();
                tbx_TenNCC.Text = dgv_nhacungcap.CurrentRow.Cells["TENNHACC"].Value.ToString().Trim();
                tbx_Diachi.Text = dgv_nhacungcap.CurrentRow.Cells["DIACHI"].Value.ToString().Trim();
                tbx_Ghichu.Text = dgv_nhacungcap.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
            }
        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            tbx_MaNCC.Enabled = true;
            tbx_MaNCC.Focus();
        }

        private void NhaCC_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
