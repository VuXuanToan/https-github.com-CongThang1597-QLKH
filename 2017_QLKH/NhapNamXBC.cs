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
    public partial class NhapNamXBC : Form
    {
        public static string ThoiGianXBC = "";
        public NhapNamXBC()
        {
            InitializeComponent();
        }

        private void bt_XacNhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCCT BC = new BCCT();
            BCCT.ThoiGianXBC = tbx_Nam.Text;
            BC.ShowDialog();
        }
    }
}
