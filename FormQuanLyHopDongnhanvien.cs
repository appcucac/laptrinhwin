using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlythuexe2
{
    public partial class FormQuanLyHopDongnhanvien : Form
    {
        string connStr = @"Server=localhost\Dung28225;Database=QuanLyThueXe;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public FormQuanLyHopDongnhanvien()
        {
            InitializeComponent();
        }

        private void FormQuanLyHopDongnhanvien_Load(object sender, EventArgs e)
        {
            LoadTatCaHopDong();
        }

        // Hiển thị tất cả hợp đồng
        void LoadTatCaHopDong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            hd.HopDongID AS N'Mã hợp đồng',
                            kh.HoTen AS N'Tên khách hàng',
                            x.BienSo AS N'Biển số xe',
                            nd.TenDangNhap AS N'Người lập',
                            hd.NgayBatDau AS N'Ngày bắt đầu',
                            hd.NgayKetThucDuKien AS N'Ngày kết thúc dự kiến',
                            hd.GiaThueNgay AS N'Giá thuê ngày',
                            hd.TienCoc AS N'Tiền cọc',
                            hd.TrangThai AS N'Trạng thái'
                        FROM HopDong hd
                        INNER JOIN KhachHang kh ON hd.KhachHangID = kh.KhachHangID
                        INNER JOIN Xe x ON hd.XeID = x.XeID
                        INNER JOIN NguoiDung nd ON hd.NguoiDungID = nd.NguoiDungID
                        ORDER BY hd.HopDongID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHopDong.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load hợp đồng: " + ex.Message);
            }
        }

        private void btnLapHopDong_Click(object sender, EventArgs e)
        {
            FormLapHopDong f = new FormLapHopDong();
            f.Show();
            this.Hide();
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
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadTatCaHopDong();
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
            LoadTatCaHopDong();
        }

        private void btnTraXe_Click(object sender, EventArgs e)
        {
            FormTraXenhanvien f = new FormTraXenhanvien();
            f.Show();
            this.Hide();
        }
        
    }
}