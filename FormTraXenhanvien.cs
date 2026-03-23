using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class FormTraXenhanvien : Form
    {
        string connStr = @"Server=localhost;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public FormTraXenhanvien()
        {
            InitializeComponent();
        }

        private void FormTraXenhanvien_Load(object sender, EventArgs e)
        {
            LoadDuLieuTraXe();
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand(@"
                        SELECT COUNT(*) 
                        FROM HopDong
                        WHERE GETDATE() BETWEEN NgayBatDau AND NgayKetThucDuKien", conn);
                    lblDangThue.Text = cmd1.ExecuteScalar().ToString();

                    SqlCommand cmd2 = new SqlCommand(@"
                        SELECT COUNT(*) 
                        FROM HopDong
                        WHERE DATEDIFF(DAY, GETDATE(), NgayKetThucDuKien) = 1", conn);
                    lblSapDenHan.Text = cmd2.ExecuteScalar().ToString();

                    SqlCommand cmd3 = new SqlCommand(@"
                        SELECT COUNT(*) 
                        FROM HopDong
                        WHERE GETDATE() > NgayKetThucDuKien", conn);
                    lblQuaHan.Text = cmd3.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thống kê: " + ex.Message);
            }
        }

        private void LoadDuLieuTraXe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            TraXeID,
                            HopDongID,
                            NgayTraXe,
                            NguoiNhan,
                            SoNgayTre,
                            PhiTraTre,
                            MoTaHuHong,
                            PhiHuHong,
                            TongTienThanhToan
                        FROM TraXe";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTraXe.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu trả xe: " + ex.Message);
            }
        }

        private void dgvTraXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

     
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            trangchunhanvien f = new trangchunhanvien();
            f.Show();
            this.Hide();
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

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            FormQuanLyHopDongnhanvien f = new FormQuanLyHopDongnhanvien();
            f.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}