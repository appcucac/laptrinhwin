using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class formquanlyxenhanvien : Form
    {
        public formquanlyxenhanvien()
        {
            InitializeComponent();
        }

        
        
        private void lblTongXe_Click(object sender, EventArgs e)
        {

        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            trangchunhanvien f = new trangchunhanvien();
            f.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormQuanLyKhachHangnhanvien f = new FormQuanLyKhachHangnhanvien();
            f.Show();
            this.Hide();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            FormQuanLyHopDongnhanvien f = new FormQuanLyHopDongnhanvien();
            f.Show();
            this.Hide();
        }

        private void btnTraXe_Click(object sender, EventArgs e)
        {
            FormTraXenhanvien f = new FormTraXenhanvien();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
