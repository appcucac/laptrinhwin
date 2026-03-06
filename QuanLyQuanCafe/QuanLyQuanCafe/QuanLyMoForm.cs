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
    public partial class QuanLyMoForm : Form
    {
        Database db = new Database();

        public QuanLyMoForm()
        {
            InitializeComponent();
        }

        private void QuanLyMoForm_Load(object sender, EventArgs e)
        {
            dgvMon.AutoGenerateColumns = true;
            dgvMon.Columns.Clear();

            LoadLoaiMon();
            LoadDanhSachMon();

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Còn bán");
            cboTrangThai.Items.Add("Ngừng bán");
            cboTrangThai.SelectedIndex = 0;

            txtMaMon.ReadOnly = true;
        }

        private void LoadLoaiMon()
        {
            string query = "SELECT MaLoai, TenLoai FROM LoaiMon";
            DataTable dt = db.ExecuteQuery(query);

            cboLoaiMon.DataSource = dt;
            cboLoaiMon.DisplayMember = "TenLoai";
            cboLoaiMon.ValueMember = "MaLoai";
        }

        private void LoadDanhSachMon()
        {
            string query = @"
        SELECT 
            m.MaMon,
            m.TenMon,
            m.MaLoai,
            lm.TenLoai,
            m.DonGia,
            m.DonViTinh,
            CASE 
                WHEN m.TrangThai = 1 THEN N'Còn bán'
                ELSE N'Ngừng bán'
            END AS TrangThai
        FROM Mon m
        INNER JOIN LoaiMon lm ON m.MaLoai = lm.MaLoai";

            DataTable dt = db.ExecuteQuery(query);
            dgvMon.DataSource = dt;

   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenMon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên món.");
                txtTenMon.Focus();
                return;
            }

            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá.");
                txtDonGia.Focus();
                return;
            }

            if (txtDonViTinh.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.");
                txtDonViTinh.Focus();
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là số.");
                txtDonGia.Focus();
                return;
            }

            try
            {
                string query = @"
                    INSERT INTO Mon(TenMon, MaLoai, DonGia, DonViTinh, TrangThai)
                    VALUES(@TenMon, @MaLoai, @DonGia, @DonViTinh, @TrangThai)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenMon", txtTenMon.Text.Trim()),
                    new SqlParameter("@MaLoai", cboLoaiMon.SelectedValue),
                    new SqlParameter("@DonGia", donGia),
                    new SqlParameter("@DonViTinh", txtDonViTinh.Text.Trim()),
                    new SqlParameter("@TrangThai", cboTrangThai.Text == "Còn bán" ? 1 : 0)
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm món thành công.");
                    LoadDanhSachMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn món cần sửa.");
                return;
            }

            if (txtTenMon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên món.");
                txtTenMon.Focus();
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là số.");
                txtDonGia.Focus();
                return;
            }

            try
            {
                string query = @"
                    UPDATE Mon
                    SET TenMon = @TenMon,
                        MaLoai = @MaLoai,
                        DonGia = @DonGia,
                        DonViTinh = @DonViTinh,
                        TrangThai = @TrangThai
                    WHERE MaMon = @MaMon";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenMon", txtTenMon.Text.Trim()),
                    new SqlParameter("@MaLoai", cboLoaiMon.SelectedValue),
                    new SqlParameter("@DonGia", donGia),
                    new SqlParameter("@DonViTinh", txtDonViTinh.Text.Trim()),
                    new SqlParameter("@TrangThai", cboTrangThai.Text == "Còn bán" ? 1 : 0),
                    new SqlParameter("@MaMon", txtMaMon.Text.Trim())
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Sửa món thành công.");
                    LoadDanhSachMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Sửa món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa món: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn có chắc muốn xóa món này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No)
                return;

            try
            {
                string query = "DELETE FROM Mon WHERE MaMon = @MaMon";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaMon", txtMaMon.Text.Trim())
                };

                int result = db.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa món thành công.");
                    LoadDanhSachMon();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa món thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa món này. " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtDonGia.Clear();
            txtDonViTinh.Clear();
            txtTimKiem.Clear();

            if (cboLoaiMon.Items.Count > 0)
                cboLoaiMon.SelectedIndex = 0;

            cboTrangThai.SelectedIndex = 0;
            txtTenMon.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            string query = @"
        SELECT 
            m.MaMon,
            m.TenMon,
            m.MaLoai,
            lm.TenLoai,
            m.DonGia,
            m.DonViTinh,
            CASE 
                WHEN m.TrangThai = 1 THEN N'Còn bán'
                ELSE N'Ngừng bán'
            END AS TrangThai
        FROM Mon m
        INNER JOIN LoaiMon lm ON m.MaLoai = lm.MaLoai
        WHERE m.TenMon LIKE @TuKhoa";

            SqlParameter[] parameters =
            {
        new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
    };

            dgvMon.DataSource = db.ExecuteQuery(query, parameters);
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaMon.Text = dgvMon.Rows[e.RowIndex].Cells["MaMon"].Value.ToString();
                txtTenMon.Text = dgvMon.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();
                txtDonGia.Text = dgvMon.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                txtDonViTinh.Text = dgvMon.Rows[e.RowIndex].Cells["DonViTinh"].Value.ToString();

                cboLoaiMon.SelectedValue = dgvMon.Rows[e.RowIndex].Cells["MaLoai"].Value;
                cboTrangThai.Text = dgvMon.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
            }
        }
    }
}