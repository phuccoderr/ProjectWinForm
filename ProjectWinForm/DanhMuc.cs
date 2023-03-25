using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWinForm
{
    public class DanhMuc
    {
        private Dictionary<string, SanPham> dsSP =
            new Dictionary<string, SanPham>();
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public void ThemSP(SanPham p)
        {
            if (dsSP.ContainsKey(p.MaSP) == false)
            {
                dsSP.Add(p.MaSP, p);
                p.Nhom = this;
            } 
        }
        public Dictionary<string,SanPham> SanPhams
        {
            get { return dsSP; }
            set { dsSP = value; }
        }
        public override string ToString()
        {
            return this.TenDM;
        }
    }
}
