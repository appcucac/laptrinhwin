using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class FormTraXenhanvien : Form
    {
        // Chuỗi kết nối
        string connStr = @"Server=localhost\Dung28225;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public FormTraXenhanvien()
        {
            InitializeComponent();
            this.Load += FormTraXenhanvien_Load;
        }

        private void FormTraXenhanvien_Load(object sender, EventArgs e)
        {
            LoadDuLieuTraXe();
        }

        private void LoadDuLieuTraXe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"SELECT 
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
    }
}