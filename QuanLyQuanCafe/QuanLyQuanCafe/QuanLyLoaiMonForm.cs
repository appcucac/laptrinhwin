using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyQuanCafe
{
    public partial class QuanLyLoaiMonForm : Form
    {
        Database db = new Database();

        public QuanLyLoaiMonForm()
        {
            InitializeComponent();
        }

        private void QuanLyLoaiMonForm_Load(object sender, EventArgs e)
        {
            dgvLoaiMon.AutoGenerateColumns = true;
            dgvLoaiMon.Columns.Clear();
            dgvLoaiMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadDanhSachLoaiMon();
            txtMaLoai.ReadOnly = true;
        }

        private void LoadDanhSachLoaiMon()
        {
            string query = @"
        SELECT MaLoai, TenLoai, MoTa
        FROM LoaiMon";

            DataTable dt = db.ExecuteQuery(query);
            dgvLoaiMon.DataSource = dt;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại món.");
                txtTenLoai.Focus();
                return;
            }

            try
            {
                string query = @"
                    INSERT INTO LoaiMon(TenLoai, MoTa)
                    VALUES(@TenLoai, @MoTa)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenLoai", txtTenLoai.Text.Trim()),
                    new SqlParameter("@MoTa", txtMoTa.Text.Trim())
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm loại món thành công.");
                    LoadDanhSachLoaiMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Thêm loại món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm loại món: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn loại món cần sửa.");
                return;
            }

            if (txtTenLoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại món.");
                txtTenLoai.Focus();
                return;
            }

            try
            {
                string query = @"
                    UPDATE LoaiMon
                    SET TenLoai = @TenLoai,
                        MoTa = @MoTa
                    WHERE MaLoai = @MaLoai";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenLoai", txtTenLoai.Text.Trim()),
                    new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                    new SqlParameter("@MaLoai", txtMaLoai.Text.Trim())
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Sửa loại món thành công.");
                    LoadDanhSachLoaiMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Sửa loại món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa loại món: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn loại món cần xóa.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa loại món này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No)
                return;

            try
            {
                string query = "DELETE FROM LoaiMon WHERE MaLoai = @MaLoai";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaLoai", txtMaLoai.Text.Trim())
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa loại món thành công.");
                    LoadDanhSachLoaiMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa loại món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa loại món này. " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            txtTenLoai.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                LoadDanhSachLoaiMon();
                return;
            }

            string query = @"
                SELECT MaLoai, TenLoai, MoTa
                FROM LoaiMon
                WHERE TenLoai LIKE @TuKhoa";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TuKhoa", "%" + txtTimKiem.Text.Trim() + "%")
            };

            dgvLoaiMon.DataSource = db.ExecuteQuery(query, parameters);
        }

        private void dgvLoaiMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaLoai.Text = dgvLoaiMon.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = dgvLoaiMon.Rows[e.RowIndex].Cells["TenLoai"].Value.ToString();
                txtMoTa.Text = dgvLoaiMon.Rows[e.RowIndex].Cells["MoTa"].Value.ToString();
            }
        }
    }
}