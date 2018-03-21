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
    public partial class KhoHang : Form
    {
        public KhoHang()
        {
            InitializeComponent();
        }
        accessData acc = new accessData();

        public void ClearText()
        {
            tbx_makho.Clear();
            tbx_tenkho.Clear();
            tbx_tongdmsp.Clear();
            tbx_ghichu.Clear();
            tbx_makho.Enabled = false;
            dgv_khohang.ClearSelection();
            tbx_makho.Focus();
        }

        private void KhoHang_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_makho, "SELECT MAKHO FROM KHOHANG");
            dgv_khohang.DataSource = acc.Select_Data("SELECT * FROM KHOHANG");
            ClearText();

            dgv_khohang.Columns[0].Width = 100;
            dgv_khohang.Columns[0].Width = 100;
            dgv_khohang.Columns[0].Width = 100;
            dgv_khohang.Columns[0].Width = 115;
        }

        private void bt_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (tbx_tenkho.Text.Trim() == "" || tbx_tongdmsp.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!,", "Thông Báo!");
                tbx_makho.Focus();
            }
            else
            {
                DataTable dtkho = new DataTable();
                dtkho = acc.CheckSql("select * from KHOHANG where MAKHO ='" + tbx_makho.Text + "'");
                if (dtkho.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Kho Hàng đã tồn tại!", "Lỗi");
                    ClearText();
                }
                else
                {
                    acc.Them_Kho(tbx_makho.Text, tbx_tenkho.Text, Convert.ToInt32(tbx_tongdmsp.Text), tbx_ghichu.Text);
                    KhoHang_Load(sender, e);
                }       
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_khohang.BeginEdit(true);
            if (tbx_makho.Text == "" || tbx_tenkho.Text == "" || tbx_tongdmsp.Text == "")
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa và Hãy Nhập Đầy Đủ Thông Tin!", "Thông Báo!");
                tbx_makho.Focus();
            }
            else
            {
            if (tbx_makho.Text != dgv_khohang.CurrentRow.Cells["MAKHO"].Value.ToString().Trim() || tbx_makho.Text == "")
            {
                MessageBox.Show("Mã Kho chưa được nhập hoặc đã bị thay đổi!", "Lỗi");
            }
            else
            {
                if (tbx_tenkho.Text == dgv_khohang.CurrentRow.Cells["TENKHO"].Value.ToString().Trim() && tbx_tongdmsp.Text == dgv_khohang.CurrentRow.Cells["TONGSODMSP"].Value.ToString().Trim() && tbx_ghichu.Text == dgv_khohang.CurrentRow.Cells["GHICHU"].Value.ToString().Trim())
                {
                    MessageBox.Show("Toàn Bộ Thông Tin Kho Hàng Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                }
                else
                {
                    acc.CapNhat_Kho(tbx_makho.Text, tbx_tenkho.Text, Convert.ToInt32(tbx_tongdmsp.Text), tbx_ghichu.Text);
                    KhoHang_Load(sender, e);
                }
            }
            }
            dgv_khohang.EndEdit();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (tbx_makho.Text.Trim() == "" || dgv_khohang.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã Kho Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                btn_mo_Click(sender, e);
            }
            else
            {
                DataTable dtpx = new DataTable();
                dtpx = acc.CheckSql("select * from PHIEUXUAT where MAKHO ='" + tbx_makho.Text + "'");
                DataTable dtnk = new DataTable();
                dtnk = acc.CheckSql("select * from PHIEUNHAPKHO where MAKHO ='" + tbx_makho.Text + "'");
                DataTable dtdm = new DataTable();
                dtdm = acc.CheckSql("select * from DANHMUC where MAKHO ='" + tbx_makho.Text + "'");
                DataTable dtbp = new DataTable();
                dtbp = acc.CheckSql("select * from BOPHAN where MAKHO ='" + tbx_makho.Text + "'");
                if (dtpx.Rows.Count > 0 || dtnk.Rows.Count > 0 || dtdm.Rows.Count > 0 || dtbp.Rows.Count > 0 /* || tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() */)
                {
                    MessageBox.Show("Mã Kho đã bị thay đổi Hoặc Đang Tốn Tại Ơ Bảng PHIEUXUAT, PHIEUNHAPKHO, DANHMUC,BOPHAN. Vui Lòng Xóa MAKHO ở Bảng Liên Quan Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Kho Hàng Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_Kho(tbx_makho.Text);
                        KhoHang_Load(sender, e);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            KhoHang_Load(sender, e);
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
                dgv_khohang.DataSource = acc.Select_Data("Select  * from KHOHANG Where MAKHO like N'%" + tbx_timkiem.Text + "%' OR TENKHO like N'%" + tbx_timkiem.Text + "%' OR TONGSODMSP like N'%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dgv_khohang.ClearSelection();
            }
        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            tbx_makho.Enabled = true;
            tbx_makho.Focus();
        }

        private void dgv_khohang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_makho.Text = dgv_khohang.CurrentRow.Cells["MAKHO"].Value.ToString().Trim();
                tbx_tenkho.Text = dgv_khohang.CurrentRow.Cells["TENKHO"].Value.ToString().Trim();
                tbx_tongdmsp.Text = dgv_khohang.CurrentRow.Cells["TONGSODMSP"].Value.ToString().Trim();
                tbx_ghichu.Text = dgv_khohang.CurrentRow.Cells["GHICHU"].Value.ToString().Trim();
            }
        }

        private void dgv_khohang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                btn_xoa_Click(sender, e);
            }
        }

        private void KhoHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
