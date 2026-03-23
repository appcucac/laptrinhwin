using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class FormQuanLyKhachHangnhanvien : Form
    {
        string connStr = @"Server=localhost;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public FormQuanLyKhachHangnhanvien()
        {
            InitializeComponent();
        }

        void LoadThongKe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM KhachHang", conn);
                    lblTongKhachHang.Text = cmd1.ExecuteScalar().ToString();

                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM HopDong", conn);
                    lblTongLuotThue.Text = cmd2.ExecuteScalar().ToString();

                    SqlCommand cmd3 = new SqlCommand(@"
                        SELECT ISNULL(SUM(
                            DATEDIFF(DAY, NgayBatDau, NgayKetThucDuKien) * GiaThueNgay
                        ),0) 
                        FROM HopDong", conn);

                    decimal tong = Convert.ToDecimal(cmd3.ExecuteScalar());
                    lblTongDoanhThu.Text = tong.ToString("#,##0") + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        void LoadDanhSachKhach(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                         KhachHangID AS [Mã KH],
                         HoTen AS [Họ tên],
                         SoDienThoai AS [Số điện thoại],
                         CCCD AS [CCCD],
                         DiaChi AS [Địa chỉ],
                        CASE 
                        WHEN TrangThai = 1 THEN N'Hoạt động'
                        ELSE N'Ngưng'
                        END AS [Trạng thái]
                        FROM KhachHang
                        WHERE HoTen LIKE @kw 
                        OR SoDienThoai LIKE @kw 
                        OR CCCD LIKE @kw";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khách hàng: " + ex.Message);
            }
        }

        private void FormQuanLyKhachHangnhanvien_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhach();
            LoadThongKe();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachKhach(txtTimKiem.Text);
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataKhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            trangchunhanvien f = new trangchunhanvien();
            f.Show();
            this.Hide();
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
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

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            FormThemKhachHang f = new FormThemKhachHang();
            f.Show();
        }
    }
}