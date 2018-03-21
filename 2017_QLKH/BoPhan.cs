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
    public partial class BoPhan : Form
    {
        public BoPhan()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();

        public void ClearText()
        {
            tbx_MaBP.Clear();
            tbx_TenBP.Clear();
            tbx_Dienthoai.Clear();
            tbx_MaKho.Clear();
            tbx_NQL.Clear();
            dgv_BoPhan.ClearSelection();
            tbx_MaBP.Focus();
            tbx_MaBP.Enabled = false;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_TenBP.Text.Trim() == "" || tbx_Dienthoai.Text.Trim() == "" || tbx_MaKho.Text.Trim() == "" || tbx_NQL.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_MaBP.Focus();
            }
            else
            {
                DataTable dtkho = new DataTable();
                DataTable dtbp = new DataTable();
                DataTable dtnql = new DataTable();
                dtnql = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NQL.Text + "'");
                dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
                dtbp = acc.CheckSql("select * from BOPHAN where MABP ='" + tbx_MaBP.Text + "'");
                if (dtbp.Rows.Count > 0 || dtkho.Rows.Count < 1 || dtnql.Rows.Count < 1)
                {
                    MessageBox.Show("Bộ Phận đã tồn tại Hoặc Kho Hàng không tồn tại Hoặc Người Quản Lý không tồn tại!", "Lỗi");
                    tbx_MaBP.Clear();
                    tbx_MaBP.Focus();
                    tbx_MaKho.Clear();
                    tbx_NQL.Clear();
                }
                else
                {
                    if (tbx_MaBP.Text == dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString() && tbx_TenBP.Text == dgv_BoPhan.CurrentRow.Cells["TENBP"].Value.ToString().Trim() && tbx_MaKho.Text == dgv_BoPhan.CurrentRow.Cells["MAKHO"].Value.ToString().Trim() && tbx_NQL.Text == dgv_BoPhan.CurrentRow.Cells["NQL"].Value.ToString().Trim() && tbx_Dienthoai.Text == dgv_BoPhan.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Toàn Bộ Thông Tin Bộ Phận Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.Them_BoPhan(tbx_MaBP.Text, tbx_TenBP.Text, tbx_Dienthoai.Text, tbx_MaKho.Text, tbx_NQL.Text);
                        BoPhan_Load(sender, e);
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_BoPhan.BeginEdit(true);
            if (tbx_MaBP.Text.Trim() == "" || tbx_NQL.Text.Trim() == "" || tbx_MaKho.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin Hoặc Chọn Dòng Bạn Muốn Sửa. Tối Thiểu MABP + MAKHO + NQL!", "Thông Báo!");
                tbx_MaBP.Focus();
            }
            else
            {
                DataTable dtkho = new DataTable();
                DataTable dtnql = new DataTable();
                dtnql = acc.CheckSql("select * from NHANVIEN where MANV ='" + tbx_NQL.Text + "'");
                dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_MaKho.Text + "'");
                if (tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() || dtkho.Rows.Count < 1 || dtnql.Rows.Count < 1)
                {
                    MessageBox.Show("Mã Bộ Phận đã bị thay đổi Hoặc Kho Hàng không tồn tại Hoặc Người Quản Lý không tồn tại!", "Lỗi");
                    tbx_NQL.Text = dgv_BoPhan.CurrentRow.Cells["NQL"].Value.ToString().Trim();
                    tbx_MaBP.Text = dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim();
                    tbx_MaKho.Text = dgv_BoPhan.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
                }
                else
                {
                    acc.CapNhat_BoPhan(tbx_MaBP.Text, tbx_TenBP.Text, tbx_Dienthoai.Text, tbx_MaKho.Text, tbx_NQL.Text);
                    BoPhan_Load(sender, e);
                }

            }
            dgv_BoPhan.EndEdit();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_MaBP.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Mã Bộ Phận Hoặc Chọn Dòng Bạn Muốn Xóa!", "Thông Báo!");
                tbx_MaBP.Focus();
            }
            else
            {
                DataTable dtnv = new DataTable();
                dtnv = acc.CheckSql("select * from NHANVIEN where MABP ='" + tbx_MaBP.Text + "'");
                if (dtnv.Rows.Count > 0 /* || tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() */)
                {
                    MessageBox.Show("Mã Bộ Phận đã bị thay đổi Hoặc Mã Bộ Phận Đang Tốn Tại Ơ Bảng Nhân Viên. Vui Lòng Xóa MABP ở Bảng Nhân Viên Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Bộ Phận Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_BoPhan(tbx_MaBP.Text);
                        BoPhan_Load(sender, e);
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
                dgv_BoPhan.DataSource = acc.Select_Data("Select  * from BOPHAN Where MABP like N'%" + tbx_timkiem.Text + "%' OR TENBP like N'%" + tbx_timkiem.Text + "%' OR DIENTHOAI like N'%" + tbx_timkiem.Text + "%' OR MAKHO like N'%" + tbx_timkiem.Text + "%' OR NQL like N'%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dgv_BoPhan.ClearSelection();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            BoPhan_Load(sender, e);
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void BoPhan_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_MaBP, "SELECT MABP FROM BOPHAN");
            acc.AutoComplete(tbx_MaKho, "SELECT MAKHO FROM KHOHANG");
            acc.AutoComplete(tbx_NQL, "SELECT MANV FROM NHANVIEN");

            dgv_BoPhan.DataSource = acc.Select_Data("SELECT * FROM BOPHAN");

            dgv_BoPhan.Columns[0].Width = 120;
            dgv_BoPhan.Columns[1].Width = 130;
            dgv_BoPhan.Columns[2].Width = 120;
            dgv_BoPhan.Columns[3].Width = 120;
            dgv_BoPhan.Columns[4].Width = 120;
            dgv_BoPhan.ClearSelection();
            ClearText();
        }

        private void dgv_BoPhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            tbx_MaBP.Enabled = true;
            tbx_MaBP.Focus();
        }

        private void dgv_BoPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_MaBP.Text = dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim();
                tbx_TenBP.Text = dgv_BoPhan.CurrentRow.Cells["TENBP"].Value.ToString().Trim();
                tbx_Dienthoai.Text = dgv_BoPhan.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim();
                tbx_MaKho.Text = dgv_BoPhan.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
                tbx_NQL.Text = dgv_BoPhan.CurrentRow.Cells["NQL"].Value.ToString().Trim();
            }
        }

        private void BoPhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
