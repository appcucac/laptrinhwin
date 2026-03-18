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
    public partial class trangchunhanvien : Form
    {
        public trangchunhanvien()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        
       
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            FormQuanLyHopDongnhanvien f = new FormQuanLyHopDongnhanvien();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            formquanlyxenhanvien f = new formquanlyxenhanvien();
            f.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormQuanLyKhachHangnhanvien f = new FormQuanLyKhachHangnhanvien();
            f.Show();
            this.Hide();
        }

        private void btnTraXe_Click(object sender, EventArgs e)
        {
            FormTraXenhanvien f = new FormTraXenhanvien();
            f.Show();
            this.Hide();
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tb == DialogResult.Yes)
            {
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
        }
    }
}
