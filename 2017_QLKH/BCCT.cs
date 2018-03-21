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
    public partial class BCCT : Form
    {
        public static string ThoiGianXBC = "";
        public BCCT()
        {
            InitializeComponent();
            lb_Time.Text = DateTime.Now.ToString(" ddd - yyyy.MM.dd HH:mm");
        }

        private void lb_nhanvien_Click(object sender, EventArgs e)
        {

        }

        private void NhapNgay_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhapNgayXBC NGXBC = new NhapNgayXBC();
            NGXBC.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu Main = new MainMenu();
            Main.ShowDialog();
        }

        private void NhapNam_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhapNamXBC NNXBC = new NhapNamXBC();
            NNXBC.ShowDialog();       
        }

        private void HomNay_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = DateTime.Now.ToString(" ddd - yyyy.MM.dd HH:mm");
        }

        private void Q1_T1_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q1_T1.Text;
        }

        private void Q1_T2_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q1_T2.Text;
        }

        private void Q1_T3_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q1_T3.Text;
        }

        private void Q1_Q1_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = "Quý 1";
        }

        private void Q2_T4_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q2_T4.Text;
        }

        private void Q2_T5_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q2_T5.Text;
        }

        private void Q2_T6_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q2_T6.Text;
        }

        private void Q2_Q2_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = "Quý 2";
        }

        private void Q3_T7_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q3_T7.Text;
        }

        private void Q3_T8_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q3_T8.Text;
        }

        private void Q3_T9_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q3_T9.Text;
        }

        private void Q3_Q3_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = "Quý 3";
        }

        private void Q4_T10_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q4_T10.Text;
        }

        private void Q4_T11_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q4_T11.Text;
        }

        private void Q4_T12_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = Q4_T12.Text;
        }

        private void Q4_Q4_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text = "Quý 4";
        }

        private void NamNay_Click(object sender, EventArgs e)
        {
            lb_NTQN.Text ="Năm" + DateTime.Now.ToString(" yyyy");
        }

        private void BCCT_Load(object sender, EventArgs e)
        {
            lb_NTQN.Text = ThoiGianXBC;
        }

        private void BCCT_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
