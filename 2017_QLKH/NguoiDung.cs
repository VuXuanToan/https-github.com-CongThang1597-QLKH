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
    public partial class NguoiDung : Form
    {
        accessData acc = new accessData();
        public static string QuyenHan = "";
        public static string TenDangNhap = "";
        public static string filepath = "";
        public static string MaNV = "";
        public NguoiDung()
        {
            InitializeComponent();
        }
        public DataTable SelectThongTin(string TDN)
        {
            SqlDataReader a = acc.ExecuteReader("SELECT TENNV, NS, GT, DIENTHOAI, CHUCVU, HINHANH FROM NHANVIEN, DANGNHAP WHERE NHANVIEN.MANV = DANGNHAP.MANV AND DANGNHAP.USERNAME='" + TDN + "'");
            while (a.Read())
            {
                lbxNameUser.Text = a["TENNV"].ToString();
                lbxNS.Text = a["NS"].ToString();
                lbxGT.Text = a["GT"].ToString(); 
                lbxDT.Text = a["DIENTHOAI"].ToString();
                lbxCV.Text = a["CHUCVU"].ToString();
                filepath = a["HINHANH"].ToString();
            }
            return null;
        }

        private void NguoiDung_Load(object sender, EventArgs e)
        {
            lbxUserName.Text = TenDangNhap;
            SelectThongTin(TenDangNhap);
            pc_nguoidung.ImageLocation = filepath;
            pc_nguoidung.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_luu.Enabled = false;
        }


        private void btThemUser_Click(object sender, EventArgs e)
        {
            if (QuyenHan.Trim() == "ADMIN" || QuyenHan.Trim() == "Admin" || QuyenHan.Trim() == "admin")
            {
                ThemTaiKhoan Them = new ThemTaiKhoan();
                Them.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn Phải là ADMIN thì mới thực hiện được thao tác này!");
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            string filepath = null;
            OpenFileDialog ofdImages = new OpenFileDialog();
            PictureBox objpt = new PictureBox();
            if (ofdImages.ShowDialog() == DialogResult.OK)
            {
                filepath = ofdImages.FileName;
                //MessageBox.Show(filepath);
                pc_nguoidung.Image = Image.FromFile(filepath.ToString());
                pc_nguoidung.SizeMode = PictureBoxSizeMode.StretchImage;
                btn_luu.Enabled = true;
            }
            else
            {
                filepath = "";
                //MessageBox.Show(filepath);
                btn_luu.Enabled = false;
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(filepath.Length > 0)
            {
                acc.CapNhat_NguoiDung(MaNV, filepath);
                btn_luu.Enabled = false;
            }
            
        }
    }
}
