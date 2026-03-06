namespace QuanLyQuanCafe
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnQuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.btnQuanLyNhanVien = new System.Windows.Forms.Button();
            this.btnQuanLyBan = new System.Windows.Forms.Button();
            this.btnQuanLyLoaiMon = new System.Windows.Forms.Button();
            this.btnQuanLyMon = new System.Windows.Forms.Button();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblQuyen);
            this.panel1.Controls.Add(this.lblXinChao);
            this.panel1.Controls.Add(this.lblTieuDe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 57);
            this.panel1.TabIndex = 0;
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(494, 35);
            this.lblQuyen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(73, 13);
            this.lblQuyen.TabIndex = 2;
            this.lblQuyen.Text = "Quyền: Admin";
            this.lblQuyen.Click += new System.EventHandler(this.lblQuyen_Click);
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Location = new System.Drawing.Point(494, 15);
            this.lblXinChao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(84, 13);
            this.lblXinChao.TabIndex = 1;
            this.lblXinChao.Text = "Xin chào: Admin";
            this.lblXinChao.Click += new System.EventHandler(this.lblXinChao_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(127, 22);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(178, 13);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ QUÁN CAFE";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDangXuat);
            this.panel2.Controls.Add(this.btnThongKe);
            this.panel2.Controls.Add(this.btnQuanLyTaiKhoan);
            this.panel2.Controls.Add(this.btnQuanLyNhanVien);
            this.panel2.Controls.Add(this.btnQuanLyBan);
            this.panel2.Controls.Add(this.btnQuanLyLoaiMon);
            this.panel2.Controls.Add(this.btnQuanLyMon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 359);
            this.panel2.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(16, 248);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(135, 37);
            this.btnDangXuat.TabIndex = 7;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(16, 207);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(135, 37);
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống kê doanh thu";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnQuanLyTaiKhoan
            // 
            this.btnQuanLyTaiKhoan.Location = new System.Drawing.Point(16, 166);
            this.btnQuanLyTaiKhoan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuanLyTaiKhoan.Name = "btnQuanLyTaiKhoan";
            this.btnQuanLyTaiKhoan.Size = new System.Drawing.Size(135, 37);
            this.btnQuanLyTaiKhoan.TabIndex = 4;
            this.btnQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQuanLyTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQuanLyTaiKhoan.Click += new System.EventHandler(this.btnQuanLyTaiKhoan_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(16, 124);
            this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(135, 37);
            this.btnQuanLyNhanVien.TabIndex = 3;
            this.btnQuanLyNhanVien.Text = "Quản lý nhân viên";
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = true;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyBan
            // 
            this.btnQuanLyBan.Location = new System.Drawing.Point(16, 83);
            this.btnQuanLyBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuanLyBan.Name = "btnQuanLyBan";
            this.btnQuanLyBan.Size = new System.Drawing.Size(135, 37);
            this.btnQuanLyBan.TabIndex = 2;
            this.btnQuanLyBan.Text = "Quản lý bàn";
            this.btnQuanLyBan.UseVisualStyleBackColor = true;
            this.btnQuanLyBan.Click += new System.EventHandler(this.btnQuanLyBan_Click);
            // 
            // btnQuanLyLoaiMon
            // 
            this.btnQuanLyLoaiMon.Location = new System.Drawing.Point(16, 41);
            this.btnQuanLyLoaiMon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuanLyLoaiMon.Name = "btnQuanLyLoaiMon";
            this.btnQuanLyLoaiMon.Size = new System.Drawing.Size(135, 37);
            this.btnQuanLyLoaiMon.TabIndex = 1;
            this.btnQuanLyLoaiMon.Text = "Quản lý loại món";
            this.btnQuanLyLoaiMon.UseVisualStyleBackColor = true;
            this.btnQuanLyLoaiMon.Click += new System.EventHandler(this.btnQuanLyLoaiMon_Click);
            // 
            // btnQuanLyMon
            // 
            this.btnQuanLyMon.Location = new System.Drawing.Point(16, 0);
            this.btnQuanLyMon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuanLyMon.Name = "btnQuanLyMon";
            this.btnQuanLyMon.Size = new System.Drawing.Size(135, 37);
            this.btnQuanLyMon.TabIndex = 0;
            this.btnQuanLyMon.Text = "Quản lý món";
            this.btnQuanLyMon.UseVisualStyleBackColor = true;
            this.btnQuanLyMon.Click += new System.EventHandler(this.btnQuanLyMon_Click);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoiDung.Location = new System.Drawing.Point(165, 57);
            this.panelNoiDung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(543, 359);
            this.panelNoiDung.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 416);
            this.Controls.Add(this.panelNoiDung);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuanLyMon;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnQuanLyTaiKhoan;
        private System.Windows.Forms.Button btnQuanLyNhanVien;
        private System.Windows.Forms.Button btnQuanLyBan;
        private System.Windows.Forms.Button btnQuanLyLoaiMon;
        private System.Windows.Forms.Panel panelNoiDung;
    }
}