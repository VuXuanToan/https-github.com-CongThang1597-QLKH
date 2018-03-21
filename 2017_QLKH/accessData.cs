using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _2017_QLKH
{
    class accessData
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommand cmd;

        // Chuỗi Kết Nối
        public void getconnection()
        {
            string sql = @"Data Source=TOAN2210-JR\SQLEXPRESS;Initial Catalog=QLKH;Integrated Security=True";
            con = new SqlConnection(sql);
        }

        //  Mở Kết nối
        public void OpenConnect()
        {
            getconnection();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }

        // Đóng kết nối
        public void CloseConnect()
        {
            getconnection();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        // CHeck Query database
        public DataTable CheckSql(string sql)
        {
            OpenConnect();
            dt = new DataTable();
            cmd = new SqlCommand(sql, con);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            CloseConnect();
            return dt;
        }

        // Lấy Dữ Liệu Table cho Datagridview
        public DataTable Select_Data(string query)
        {
            dt = new DataTable();
            OpenConnect();
            cmd = new SqlCommand(query, con);
           // cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            CloseConnect();
            return dt;
        }
        public bool executenonquery(String sql)
        {
            OpenConnect();
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
            return true;
        }
        public SqlDataReader ExecuteReader(String sql)
        {
            OpenConnect();
            SqlCommand cmd=new SqlCommand(sql,con);
            SqlDataReader reader=cmd.ExecuteReader();
            return reader;
        }
        public int executeScalar(string sql)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            int n = (int)cmd.ExecuteScalar();
            con.Close();
            cmd.Dispose();
            return n;

        }
        public SqlDataAdapter executeDatatable(string sql)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand = cmd;
            return sda;
        }

        // lấy dữ liệu Auto Gợi ý
        public void getData(AutoCompleteStringCollection dataCollection, string sql)
        {
            OpenConnect();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataCollection.Add(row[0].ToString().Trim());
            }
        }

        // Auto Gợi Ý Textbox
        public void AutoComplete(TextBox tbx_textbox, string sql)
        {
            tbx_textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbx_textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection, sql);
            tbx_textbox.AutoCompleteCustomSource = DataCollection;
        }

        // Thêm Tài Khoản Mới
        public SqlCommand Them_TaiKhoan(string username, string password, string manv, string quyenhan)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_TAIKHOAN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@manv", manv));
            cmd.Parameters.Add(new SqlParameter("@quyenhan", quyenhan));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

         //Cập Nhật Tài Khoản
        public SqlCommand CapNhat_TaiKhoan(string username, string password, string manv, string quyenhan)
        {
            OpenConnect();
            cmd = new SqlCommand("UPDATE_TAIKHOAN", con);
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@manv", manv));
            cmd.Parameters.Add(new SqlParameter("@quyenhan", quyenhan));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Tài Khoản
        public SqlCommand Xoa_TaiKhoan(string username)
        {
            OpenConnect();
            cmd = new SqlCommand("DELETE_TAIKHOAN", con);
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Cập Nhật Lương Theo Điều Kiện
        public SqlCommand CapNhat_Luong(string MANV, float LUONG)
        {
            OpenConnect();
            cmd = new SqlCommand(@"UPDATE NHANVIEN SET  LUONG = @LUONG WHERE MANV = @MANV", con);
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            cmd.Parameters.Add(new SqlParameter("@LUONG", LUONG));
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //  Xóa Lương
        public SqlCommand Xoa_Luong(string MANV)
        {
            OpenConnect();
            cmd = new SqlCommand(@"DELETE NHANVIEN WHERE MANV = @MANV", con);
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Nhân Viên Mới
        public SqlCommand Them_NhanVien(string MANV, string TENNV, string EMAIL, DateTime NS, string GT, string DIENTHOAI, string CHUCVU, string HINHANH, string DIACHI, float LUONG, string MABP)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_NHANVIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            cmd.Parameters.Add(new SqlParameter("@TENNV", TENNV));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", EMAIL));
            cmd.Parameters.Add(new SqlParameter("@NS", NS));
            cmd.Parameters.Add(new SqlParameter("@GT", GT.ToString()));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@CHUCVU", CHUCVU.ToString()));
            cmd.Parameters.Add(new SqlParameter("@HINHANH", HINHANH));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@LUONG",LUONG));
            cmd.Parameters.Add(new SqlParameter("@MABP", MABP));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        // Thêm sản phẩm mới
        public SqlCommand Them_SanPham(string MASP, string TENSP, string MANCC, float GIA, string MADANHMUC, string SERIAL, DateTime NGAYSANXUAT, DateTime HANSUDUNG, string GHICHU, int SOLUONG, string PHANLOAI,string HINHANH)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_SANPHAM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@TENSP", TENSP));
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@GIA", GIA));
            cmd.Parameters.Add(new SqlParameter("@MADANHMUC", MADANHMUC));
            cmd.Parameters.Add(new SqlParameter("@SERIAL", SERIAL));
            cmd.Parameters.Add(new SqlParameter("@NGAYSANXUAT", NGAYSANXUAT));
            cmd.Parameters.Add(new SqlParameter("@HANSUDUNG", HANSUDUNG));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@PHANLOAI", PHANLOAI));
            cmd.Parameters.Add(new SqlParameter("@HINHANH", HINHANH));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        // Thêm khách hàng mới
        public SqlCommand Them_KhachHang(string MAKH, string TENKH, string DIACHI, string GIOITINH, string DIENTHOAI, string EMAIL,string FAX)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_KHACHHANG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MAKH", MAKH));
            cmd.Parameters.Add(new SqlParameter("@TENKH", TENKH));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@GIOITINH", GIOITINH));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", EMAIL));
            cmd.Parameters.Add(new SqlParameter("@FAX", FAX));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Nhân Viên
        public SqlCommand CapNhat_NhanVien(string MANV, string TENNV, string EMAIL, DateTime NS, string GT, string DIENTHOAI, string CHUCVU, string HINHANH, string DIACHI, float LUONG, string MABP)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_NHANVIEN", con);
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            cmd.Parameters.Add(new SqlParameter("@TENNV", TENNV));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", EMAIL));
            cmd.Parameters.Add(new SqlParameter("@NS", NS));
            cmd.Parameters.Add(new SqlParameter("@GT", GT));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@CHUCVU", CHUCVU));
            cmd.Parameters.Add(new SqlParameter("@HINHANH", HINHANH));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@LUONG", LUONG));
            cmd.Parameters.Add(new SqlParameter("@MABP", MABP));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        // Cập nhật sản phẩm 
        public SqlCommand CapNhat_SanPham(string MASP, string TENSP, string MANCC, float GIA, string MADANHMUC, string SERIAL, DateTime NGAYSANXUAT, DateTime HANSUDUNG, string GHICHU, int SOLUONG, string PHANLOAI, string HINHANH)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_SANPHAM", con);
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@TENSP", TENSP));
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@GIA", GIA));
            cmd.Parameters.Add(new SqlParameter("@MADANHMUC", MADANHMUC));
            cmd.Parameters.Add(new SqlParameter("@SERIAL", SERIAL));
            cmd.Parameters.Add(new SqlParameter("@NGAYSANXUAT", NGAYSANXUAT));
            cmd.Parameters.Add(new SqlParameter("@HANSUDUNG", HANSUDUNG));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@PHANLOAI", PHANLOAI));
            cmd.Parameters.Add(new SqlParameter("@HINHANH", HINHANH));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Cập nhật khách hàng
        public SqlCommand CapNhat_KhachHang(string MAKH, string TENKH, string DIACHI, string GIOITINH, string DIENTHOAI, string EMAIL, string FAX)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_KHACHHANG", con);
            cmd.Parameters.Add(new SqlParameter("@MAKH", MAKH));
            cmd.Parameters.Add(new SqlParameter("@TENKH", TENKH));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@GIOITINH", GIOITINH));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@EMAIL", EMAIL));
            cmd.Parameters.Add(new SqlParameter("@FAX", FAX));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        public SqlCommand CapNhat_NguoiDung(string MANV,string HINHANH)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_NGUOIDUNG", con);
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            cmd.Parameters.Add(new SqlParameter("@HINHANH", HINHANH));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Nhân Viên
        public SqlCommand Xoa_NhanVien(string MANV)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_NHANVIEN", con);
            cmd.Parameters.Add(new SqlParameter("@MANV", MANV));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        // Xóa sản phẩm
        public SqlCommand Xoa_SanPham(string MASP)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_SANPHAM", con);
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        // Xóa khách hàng
        public SqlCommand Xoa_KhachHang(string MAKH)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_KHACHHANG", con);
            cmd.Parameters.Add(new SqlParameter("@MAKH", MAKH));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Bộ Phận Mới
        public SqlCommand Them_BoPhan(string MABP, string TENBP, string DIENTHOAI, string MAKHO, string NQL)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_BOPHAN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MABP", MABP));
            cmd.Parameters.Add(new SqlParameter("@TENBP", TENBP));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@NQL", NQL));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Bộ Phận
        public SqlCommand CapNhat_BoPhan(string MABP, string TENBP, string DIENTHOAI, string MAKHO, string NQL)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_BOPHAN", con);
            cmd.Parameters.Add(new SqlParameter("@MABP", MABP));
            cmd.Parameters.Add(new SqlParameter("@TENBP", TENBP));
            cmd.Parameters.Add(new SqlParameter("@DIENTHOAI", DIENTHOAI));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@NQL", NQL));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Bộ Phận
        public SqlCommand Xoa_BoPhan(string MABP)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_BOPHAN", con);
            cmd.Parameters.Add(new SqlParameter("@MABP", MABP));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Nhà Cung Cấp Mới
        public SqlCommand Them_NhaCC(string MANCC, string TENNHACC, string DIACHI, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_NHACC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@TENNHACC", TENNHACC));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Nhà Cung Cấp
        public SqlCommand CapNhat_NhaCC(string MANCC, string TENNHACC, string DIACHI, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_NHACC", con);
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@TENNHACC", TENNHACC));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", DIACHI));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Nhà Cung Cấp
        public SqlCommand Xoa_NhaCC(string MANCC)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_NHACC", con);
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Kho Hàng Mới
        public SqlCommand Them_Kho(string MAKHO, string TENKHO, int TONGSODMSP, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_KHOHANG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@TENKHO", TENKHO));
            cmd.Parameters.Add(new SqlParameter("@TONGSODMSP", TONGSODMSP));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Kho Hàng
        public SqlCommand CapNhat_Kho(string MAKHO, string TENKHO, int TONGSODMSP, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_KHOHANG", con);
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@TENKHO", TENKHO));
            cmd.Parameters.Add(new SqlParameter("@TONGSODMSP", TONGSODMSP));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Kho Hàng
        public SqlCommand Xoa_Kho(string MAKHO)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_KHOHANG", con);
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Danh Mục Mới
        public SqlCommand Them_DanhMuc(string MADANHMUC, string TENDANHMUC, string GHICHU, string MAKHO)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_DANHMUC", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MADANHMUC", MADANHMUC));
            cmd.Parameters.Add(new SqlParameter("@TENDANHMUC", TENDANHMUC));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Danh Mục
        public SqlCommand CapNhat_DanhMuc(string MADANHMUC, string TENDANHMUC, string GHICHU, string MAKHO)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_DANHMUC", con);
            cmd.Parameters.Add(new SqlParameter("@MADANHMUC", MADANHMUC));
            cmd.Parameters.Add(new SqlParameter("@TENDANHMUC", TENDANHMUC));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Danh Mục
        public SqlCommand Xoa_DanhMuc(string MADANHMUC)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_DANHMUC", con);
            cmd.Parameters.Add(new SqlParameter("@MADANHMUC", MADANHMUC));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Nhập Mới

        public SqlCommand Them_Nhap(string MAPN, string MAKHO, string MANCC, string NVNHAP, DateTime NGAYNHAP, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_NHAP", con); 
            cmd.Parameters.Add(new SqlParameter("@MAPN", MAPN));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@NVNHAP", NVNHAP));
            cmd.Parameters.Add(new SqlParameter("@NGAYNHAP", NGAYNHAP));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
        public SqlCommand Them_CtNhap(string MAPN, string MASP,int SOLUONG, float TONGTIEN)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_CTNHAP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MAPN", MAPN));
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@TONGTIEN", TONGTIEN));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Nhập
        public SqlCommand CapNhat_Nhap(string MAPN,string MASP,string MAKHO,string MANCC,string NVNHAP, DateTime NGAYNHAP,int SOLUONG,float TONGTIEN,string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_NHAP", con);
            cmd.Parameters.Add(new SqlParameter("@MAPN", MAPN));
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@MANCC", MANCC));
            cmd.Parameters.Add(new SqlParameter("@NVNHAP", NVNHAP));
            cmd.Parameters.Add(new SqlParameter("@NGAYNHAP", NGAYNHAP));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@TONGTIEN", TONGTIEN));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Nhập
        public SqlCommand Xoa_Nhap(string MAPN)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_NHAP", con);
            cmd.Parameters.Add(new SqlParameter("@MAPN", MAPN));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Thêm Xuất Mới
        public SqlCommand Them_Xuat(string MAPX, string MASP, string MAKHO, string MAKH, string NVXUAT, DateTime NGAYXUAT, int SOLUONG, float TONGTIEN, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("THEM_XUAT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MAPX", MAPX));
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@MAKH", MAKH));
            cmd.Parameters.Add(new SqlParameter("@NVXUAT", NVXUAT));
            cmd.Parameters.Add(new SqlParameter("@NGAYXUAT", NGAYXUAT));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@TONGTIEN", TONGTIEN));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        //Cập Nhật Xuất
        public SqlCommand CapNhat_Xuat(string MAPX, string MASP, string MAKHO, string MAKH, string NVXUAT, DateTime NGAYXUAT, int SOLUONG, float TONGTIEN, string GHICHU)
        {
            OpenConnect();
            cmd = new SqlCommand("CAPNHAT_XUAT", con);
            cmd.Parameters.Add(new SqlParameter("@MAPX", MAPX));
            cmd.Parameters.Add(new SqlParameter("@MASP", MASP));
            cmd.Parameters.Add(new SqlParameter("@MAKHO", MAKHO));
            cmd.Parameters.Add(new SqlParameter("@MAKH", MAKH));
            cmd.Parameters.Add(new SqlParameter("@NVXUAT", NVXUAT));
            cmd.Parameters.Add(new SqlParameter("@NGAYXUAT", NGAYXUAT));
            cmd.Parameters.Add(new SqlParameter("@SOLUONG", SOLUONG));
            cmd.Parameters.Add(new SqlParameter("@TONGTIEN", TONGTIEN));
            cmd.Parameters.Add(new SqlParameter("@GHICHU", GHICHU));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }

        // Xóa Xuất
        public SqlCommand Xoa_Xuat(string MAPX)
        {
            OpenConnect();
            cmd = new SqlCommand("XOA_XUAT", con);
            cmd.Parameters.Add(new SqlParameter("@MAPX", MAPX));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            CloseConnect();
            return cmd;
        }
    }
}