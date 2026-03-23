using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class trangchunhanvien : Form
    {
        string connStr = @"Server=localhost;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";
        public trangchunhanvien()
        {
            InitializeComponent();
        }

        private void trangchunhanvien_Load(object sender, EventArgs e)
        {
            // Hiển thị ngày
            lblDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");

            // Load thống kê
            LoadThongKe();

            // ===== THÊM DÒNG NÀY =====
            LoadXeDangThue();

            LoadTinhTrangXe();

            LoadTongDoanhThu();

            LoadHopDongSapHetHan();
        }

        void LoadThongKe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 🔵 Tổng xe
                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Xe", conn);
                    int tongXe = Convert.ToInt32(cmd1.ExecuteScalar());
                    lblTongXe.Text = tongXe.ToString();

                    // 🟢 Xe đang thuê (tính theo Hợp Đồng)
                    SqlCommand cmd2 = new SqlCommand(@"
                SELECT COUNT(DISTINCT XeID)
                FROM HopDong
                WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThucDuKien", conn);
                    int xeDangThue = Convert.ToInt32(cmd2.ExecuteScalar());
                    lblXeDangThue.Text = xeDangThue.ToString();

                    // 🟡 Xe bảo trì (giữ nguyên)
                    SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Xe WHERE TrangThai = 2", conn);
                    int xeBaoTri = Convert.ToInt32(cmd4.ExecuteScalar());
                    lblXeBaoTri.Text = xeBaoTri.ToString();

                    // 🟢 Xe còn trống = Tổng - Đang thuê - Bảo trì
                    int xeConTrong = tongXe - xeDangThue - xeBaoTri;
                    if (xeConTrong < 0) xeConTrong = 0;

                    lblXeConTrong.Text = xeConTrong.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dashboard: " + ex.Message);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        // ===== QUẢN LÝ XE =====
        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            formquanlyxenhanvien f = new formquanlyxenhanvien();
            f.Show();
            this.Hide();
        }

        // ===== KHÁCH HÀNG =====
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormQuanLyKhachHangnhanvien f = new FormQuanLyKhachHangnhanvien();
            f.Show();
            this.Hide();
        }

        // ===== TRẢ XE =====
        private void btnTraXe_Click(object sender, EventArgs e)
        {
            FormTraXenhanvien f = new FormTraXenhanvien();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Hide();
            }
        }

        void LoadHopDongSapHetHan()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string query = @"
            SELECT 
                HopDong.HopDongID AS [Mã hợp đồng],
                KhachHang.HoTen AS [Khách hàng],
                Xe.BienSo AS [Biển số xe],
                HopDong.NgayKetThucDuKien AS [Ngày trả dự kiến]
            FROM HopDong
            JOIN Xe ON HopDong.XeID = Xe.XeID
            JOIN KhachHang ON HopDong.KhachHangID = KhachHang.KhachHangID
            WHERE DATEDIFF(DAY, GETDATE(), HopDong.NgayKetThucDuKien) = 1
              AND HopDong.TrangThai = N'Có hiệu lực'
            ORDER BY HopDong.NgayKetThucDuKien ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataHopDongSapHetHan.DataSource = null;
                dataHopDongSapHetHan.DataSource = dt;
                dataHopDongSapHetHan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi HĐ sắp hết hạn: " + ex.Message);
            }
        }

        void LoadXeDangThue()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string query = @"
            SELECT DISTINCT
                Xe.XeID AS [Mã xe],
                Xe.BienSo AS [Biển số]
            FROM HopDong
            JOIN Xe ON HopDong.XeID = Xe.XeID
            WHERE GETDATE() BETWEEN HopDong.NgayBatDau AND HopDong.NgayKetThucDuKien
              AND HopDong.TrangThai = N'Có hiệu lực'
            ORDER BY Xe.XeID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataXeDangThue.DataSource = null;
                dataXeDangThue.DataSource = dt;
                dataXeDangThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load xe đang thuê: " + ex.Message);
            }
        }

        void LoadTinhTrangXe()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                int tongXe, dangThue, baoTri, xeTrong;

                // 🔵 Tổng xe
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Xe", conn);
                tongXe = Convert.ToInt32(cmd1.ExecuteScalar());

                // 🔴 Xe đang thuê (THEO HỢP ĐỒNG)
                SqlCommand cmd2 = new SqlCommand(@"
            SELECT COUNT(DISTINCT XeID)
            FROM HopDong
            WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThucDuKien", conn);
                dangThue = Convert.ToInt32(cmd2.ExecuteScalar());

                // 🟡 Xe bảo trì
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Xe WHERE TrangThai = 2", conn);
                baoTri = Convert.ToInt32(cmd3.ExecuteScalar());

                // 🟢 Xe trống
                xeTrong = tongXe - dangThue - baoTri;
                if (xeTrong < 0) xeTrong = 0;

                // 🎯 ĐỔ VÀO CHART
                chartTinhTrangXe.Series[0].Points.Clear();
                chartTinhTrangXe.Series[0]["PieLabelStyle"] = "Outside";
                chartTinhTrangXe.Series[0].IsValueShownAsLabel = true;

                chartTinhTrangXe.Series[0].Points.AddXY("Trống", xeTrong);
                chartTinhTrangXe.Series[0].Points.AddXY("Đang thuê", dangThue);
                chartTinhTrangXe.Series[0].Points.AddXY("Bảo trì", baoTri);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chart: " + ex.Message);
            }
        }

        void LoadTongDoanhThu()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                string query = @"
            SELECT SUM(
                DATEDIFF(DAY, NgayBatDau, NgayKetThucDuKien) * GiaThueNgay
            )
            FROM HopDong";

                SqlCommand cmd = new SqlCommand(query, conn);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal tong = Convert.ToDecimal(result);
                    lblTongDoanhThu.Text = tong.ToString("N0") + " VNĐ";
                }
                else
                {
                    lblTongDoanhThu.Text = "0 VNĐ";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi doanh thu: " + ex.Message);
            }
        }

        private void dataXeDangThue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataHopDongSapHetHan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}