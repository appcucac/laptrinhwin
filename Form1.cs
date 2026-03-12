using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối SQL Server
        string connStr = @"Server=localhost\Dung28225;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // ================= ĐĂNG NHẬP =================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox4.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT VaiTro FROM NguoiDung WHERE TenDangNhap=@user AND MatKhau=@pass";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int vaiTro = Convert.ToInt32(result);

                        MessageBox.Show("Đăng nhập thành công!");

                        if (vaiTro == 1)
                        {
                            Form2 f = new Form2();
                            f.Show();
                        }
                        else if (vaiTro == 2)
                        {
                            trangchunhanvien f = new trangchunhanvien();
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("Vai trò không hợp lệ!");
                            return;
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // ===== Event trống tránh lỗi Designer =====
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2TextBox4_IconRightClick(object sender, EventArgs e) { }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }
    }
}