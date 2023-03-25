using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWinForm
{
    public partial class frmSanPham : Form
    {
        public static List<DanhMuc> danhsachDM = new List<DanhMuc>();
        public static List<SanPham> dsSP = new List<SanPham>();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLiDM_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmDM = new frmDanhMuc();
            if (frmDM.ShowDialog() == DialogResult.OK)
            {
                HienThiDanhMucLenComboBox();
            }
        }

        

        private void HienThiDanhMucLenComboBox()
        {
            cboDanhMuc.Items.Clear();
            foreach (DanhMuc dm in danhsachDM)
            {
                cboDanhMuc.Items.Add(dm);
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("bạn chưa chọn danh mục !!");

            } 
            DanhMuc dm = cboDanhMuc.SelectedItem as DanhMuc;
            SanPham sp = new SanPham();
            sp.MaSP = txtMaSP.Text;
            sp.TenSP = txtTenSP.Text;
            sp.DonGia = double.Parse(txtDonGia.Text);
            sp.XuatXu = txtXuatXu.Text;
            sp.HanDung = dtpHanDung.Value;
            dm.ThemSP(sp);
            dsSP.Add(sp);
            hienthisanphamlstbox();
            xoachitietsanpham();
        }
        private void xoachitietsanpham()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtXuatXu.Text = "";
            txtMaSP.Focus();
        }
        private void hienthisanphamlstbox()
        {
            lstSanPham.Items.Clear();
            foreach (SanPham sp in dsSP)
            {
                lstSanPham.Items.Add(sp);
            }
        }
        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSanPham.SelectedIndex == -1)
            {
                return;
            }
            SanPham sp = lstSanPham.SelectedItem as SanPham;
            cboDanhMuc.SelectedItem = sp;
            txtMaSP.Text = sp.MaSP;
            txtTenSP.Text = sp.TenSP;
            txtDonGia.Text = sp.DonGia + "";
            txtXuatXu.Text = sp.XuatXu;
            dtpHanDung.Value = sp.HanDung;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("ban can chon de xoa sanpham");
                return;
            }
            SanPham sp = lstSanPham.SelectedItem as SanPham;
            lstSanPham.Items.Remove(sp);
            DialogResult ret = MessageBox.Show("ban co chac chan muon xoa ["+sp.TenSP+"] ", "hoi xoa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                dsSP.Remove(sp);
                hienthisanphamlstbox();
            }
        }
    }
}
