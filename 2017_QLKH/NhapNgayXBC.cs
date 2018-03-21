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
    public partial class NhapNgayXBC : Form
    {
        public static string ThoiGianXBC = "";
        public NhapNgayXBC()
        {
            InitializeComponent();
        }

        private void bt_XacNhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            BCCT BC = new BCCT();
            BCCT.ThoiGianXBC = dtp_nhapngay.Value.ToString("yyyy-mm-dd");
            BC.ShowDialog();
        }
    }
}
