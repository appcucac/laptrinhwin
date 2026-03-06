using System;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class MainForm : Form
    {
        private string quyen;
        private string hoTen;
        private int maNV;

        public MainForm(string quyen, string hoTen, int maNV)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.hoTen = hoTen;
            this.maNV = maNV;
        }

        private void MoFormCon(Form formCon)
        {
            panelNoiDung.Controls.Clear();

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panelNoiDung.Controls.Add(formCon);
            formCon.Show();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblXinChao.Text = "Xin chào Admin: " + hoTen;
            lblQuyen.Text = "Quyền: " + quyen;
            this.Text = "Hệ thống quản lý quán cafe - Admin";
        }

        private void lblXinChao_Click(object sender, EventArgs e)
        {
        }

        private void lblQuyen_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyMon_Click(object sender, EventArgs e)
        {
            QuanLyMoForm f = new QuanLyMoForm();
            MoFormCon(f);
        }

        private void btnQuanLyLoaiMon_Click(object sender, EventArgs e)
        {
            QuanLyLoaiMonForm f = new QuanLyLoaiMonForm();
            MoFormCon(f);
        }

        private void btnQuanLyBan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form Quản lý bàn");
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form Quản lý nhân viên");
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form Quản lý tài khoản");
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở form Thống kê");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}