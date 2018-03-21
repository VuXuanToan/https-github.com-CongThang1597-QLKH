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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        accessData acc = new accessData();

        public void ClearText()
        {
            tbx_makh.Clear();
            tbx_tenkh.Clear();
            tbx_diachi.Clear();
            tbx_gioitinh.Clear();
            tbx_dienthoai.Clear();
            tbx_email.Clear();
            tbx_fax.Clear();
            tbx_makh.Enabled = false;
            dataGridView1.ClearSelection();
            tbx_makh.Focus();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            acc.AutoComplete(tbx_makh, "SELECT MAKH FROM KHACHHANG");
            dataGridView1.DataSource = acc.Select_Data("SELECT * FROM KHACHHANG");
            ClearText();
        }

      

        private void btn1_Click_1(object sender, EventArgs e)
        {
            if (tbx_makh.Text.Trim() == "" || tbx_tenkh.Text.Trim() == "" || tbx_diachi.Text.Trim() == "" || tbx_dienthoai.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ Thông Tin!,", "Thông Báo!");
                tbx_makh.Focus();
            }
            else
            {
                DataTable dtkho = new DataTable();
                dtkho = acc.CheckSql("select * from KHACHHANG where MAKH ='" + tbx_makh.Text + "'");
                if (dtkho.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Kho Hàng đã tồn tại!", "Lỗi");
                    ClearText();
                }
                else
                {
                    acc.Them_KhachHang(tbx_makh.Text, tbx_tenkh.Text, tbx_diachi.Text, tbx_gioitinh.Text, tbx_dienthoai.Text, tbx_email.Text, tbx_fax.Text);
                    KhachHang_Load(sender, e);
                }
            }
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.BeginEdit(true);
            if (tbx_makh.Text == "" || tbx_tenkh.Text == "" || tbx_diachi.Text == "" || tbx_gioitinh.Text == "" || tbx_dienthoai.Text == "" || tbx_email.Text == "" || tbx_fax.Text == "")
            {
                MessageBox.Show("Chọn Dòng Bạn Muốn Sửa", "Thông Báo!");
                tbx_makh.Focus();
            }
            else
            {
                if (tbx_makh.Text != dataGridView1.CurrentRow.Cells["MAKH"].Value.ToString().Trim() || tbx_makh.Text == "")
                {
                    MessageBox.Show("Mã Kho chưa được nhập hoặc đã bị thay đổi!", "Lỗi");
                }
                else
                {
                    if (tbx_tenkh.Text == dataGridView1.CurrentRow.Cells["TENKH"].Value.ToString().Trim() && tbx_makh.Text == dataGridView1.CurrentRow.Cells["MAKH"].Value.ToString().Trim() && tbx_diachi.Text == dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString().Trim() && tbx_gioitinh.Text == dataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Trim() && tbx_dienthoai.Text == dataGridView1.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim() && tbx_email.Text == dataGridView1.CurrentRow.Cells["EMAIL"].Value.ToString().Trim() && tbx_fax.Text == dataGridView1.CurrentRow.Cells["FAX"].Value.ToString().Trim())
                    {
                        MessageBox.Show("Toàn Bộ Thông Tin Kho Hàng Đã Tồn Tại. Vui Lòng Sủa Lại!", "Thông Báo!");
                    }
                    else
                    {
                        acc.CapNhat_KhachHang(tbx_makh.Text, tbx_tenkh.Text, tbx_diachi.Text, tbx_gioitinh.Text, tbx_dienthoai.Text, tbx_email.Text, tbx_fax.Text);
                        KhachHang_Load(sender, e);
                    }
                }
            }
            dataGridView1.EndEdit();
        }
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            KhachHang_Load(sender, e);
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
                dataGridView1.DataSource = acc.Select_Data("Select  * from KHACHHANG Where MAKH like N'%" + tbx_timkiem.Text + "%' OR TENKH like N'%" + tbx_timkiem.Text + "%' OR DIACHI like N'%" + tbx_timkiem.Text + "%' OR GIOITINH like N'%" + tbx_timkiem.Text + "%' OR DIENTHOAI like N'%" + tbx_timkiem.Text + "%' OR EMAIL like N'%" + tbx_timkiem.Text + "%'");
                tbx_timkiem.Clear();
                dataGridView1.ClearSelection();
            }
        }


     

        private void btn_mo_Click_1(object sender, EventArgs e)
        {
            tbx_makh.Enabled = true;
            tbx_makh.Focus();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                tbx_makh.Text = dataGridView1.CurrentRow.Cells["MAKH"].Value.ToString().Trim();
                tbx_tenkh.Text = dataGridView1.CurrentRow.Cells["TENKH"].Value.ToString().Trim();
                tbx_diachi.Text = dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString().Trim();
                tbx_gioitinh.Text = dataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Trim();
                tbx_dienthoai.Text = dataGridView1.CurrentRow.Cells["DIENTHOAI"].Value.ToString().Trim();
                tbx_email.Text = dataGridView1.CurrentRow.Cells["EMAIL"].Value.ToString().Trim();
                tbx_fax.Text = dataGridView1.CurrentRow.Cells["FAX"].Value.ToString().Trim();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                btn3_Click(sender, e);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {

            if (tbx_makh.Text.Trim() == "" || dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("Hãy Nhập Mã Kho Muốn Xóa Hoặc Chọn Dòng Muốm Xóa!,", "Cảnh Báo!");
                btn_mo_Click_1(sender, e);
            }
            else
            {
                DataTable dtpx = new DataTable();
                dtpx = acc.CheckSql("select * from PHIEUXUAT where MAKH ='" + tbx_makh.Text + "'");

                if (dtpx.Rows.Count > 0  /* || tbx_MaBP.Text != dgv_BoPhan.CurrentRow.Cells["MABP"].Value.ToString().Trim() */)
                {
                    MessageBox.Show("Mã Kho đã bị thay đổi Hoặc Đang Tốn Tại Ơ Bảng PHIEUXUAT, PHIEUNHAPKHO, DANHMUC,BOPHAN. Vui Lòng Xóa MAKHO ở Bảng Liên Quan Trước Khi Thực Hiện Tao Tác!", "Lỗi");
                }
                else
                {
                    if (MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Kho Hàng Này?", "Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        acc.Xoa_KhachHang(tbx_makh.Text);
                        KhachHang_Load(sender, e);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void bt_quaylai_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }

    }
}
