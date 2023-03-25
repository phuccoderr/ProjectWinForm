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
    public partial class frmDanhMuc : Form
    {
        public static bool cothaydoi = false;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DanhMuc dm = new DanhMuc();
            dm.MaDM = txtMa.Text;
            dm.TenDM = txtTenDanhMuc.Text;
            frmSanPham.danhsachDM.Add(dm);
            HienThiDanhMuc();
            cothaydoi = true;
        }
        void HienThiDanhMuc()
        {
            lstDanhMuc.Items.Clear();
            foreach (DanhMuc dm in frmSanPham.danhsachDM)
            {
                lstDanhMuc.Items.Add(dm);
            }
        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                txtMa.Text = dm.MaDM;
                txtTenDanhMuc.Text = dm.TenDM;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                lstDanhMuc.Items.Remove(dm);
                cothaydoi = true;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (cothaydoi == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult= DialogResult.Cancel;
            }
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMuc();
        }
    }
}
