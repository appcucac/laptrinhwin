using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Login : Form
    {
        Database db = new Database();

        public Login()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn thoát không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDangNhap == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.");
                txtTenDangNhap.Focus();
                return;
            }

            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                txtMatKhau.Focus();
                return;
            }

            try
            {
                string query = @"
                    SELECT tk.TenDangNhap, tk.Quyen, nv.HoTen, nv.MaNV
                    FROM TaiKhoan tk
                    INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                    WHERE tk.TenDangNhap = @TenDangNhap
                      AND tk.MatKhau = @MatKhau
                      AND tk.TrangThai = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", tenDangNhap),
                    new SqlParameter("@MatKhau", matKhau)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    string quyen = dt.Rows[0]["Quyen"].ToString().Trim();
                    string hoTen = dt.Rows[0]["HoTen"].ToString().Trim();
                    int maNV = Convert.ToInt32(dt.Rows[0]["MaNV"]);

                    if (quyen == "Admin")
                    {
                        MessageBox.Show("Đăng nhập Admin thành công!");

                        MainForm f = new MainForm(quyen, hoTen, maNV);
                        this.Hide();
                        f.ShowDialog();
                        this.Show();

                        txtMatKhau.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản nhân viên sẽ dùng giao diện riêng, hiện tại chỉ đăng nhập Admin.");
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message);
            }
        }
    }
}