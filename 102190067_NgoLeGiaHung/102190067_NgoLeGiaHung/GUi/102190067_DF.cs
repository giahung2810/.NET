using _102190067_NgoLeGiaHung.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190067_NgoLeGiaHung.GUi
{
    public partial class _102190067_DF : Form
    {
        public delegate void MyDel(string ncc, string dc, string name);
        public MyDel d { get; set; }
        public string MSSV { get; set; }
        public _102190067_DF(string m)
        {
            InitializeComponent();
            SetCBBNCC();
            SetCBBTinh();
        }

        public void SetCBBNCC()
        {
            foreach (NCC l in BLL.BLL.Instance.GetAllNCC_BLL())
            {
                CBBNCC.Items.Add(new CBBItems
                {
                    Value = l.MaNCC,
                    Text = l.TenNCC,
                });
            }
        }
        public void SetCBBTinh()
        {
            foreach (DiaChi l in BLL.BLL.Instance.GetAllDiaChi_BLL())
            {
                CBBTinh.Items.Add(new CBBItems1
                {
                    Value = l.MaTinh,
                    Text = l.TenTinh,
                });
            }
        }
        public void ShowInf(string MaSP)
        {
            txtMaSP.Enabled = false;
            txtMaSP.Text = BLL.BLL.Instance.GetSPbyMaSP(MaSP).MaSP;
            txtTenSP.Text = BLL.BLL.Instance.GetSPbyMaSP(MaSP).TenSP;
            txtGia.Text = Convert.ToString(BLL.BLL.Instance.GetSPbyMaSP(MaSP).GiaNhap);
            //comboBoxClass.Text = Convert.ToString(BLL_QLSV.Instance.GetLSHbyID(BLL_QLSV.Instance.GetSVbyMSSV(MSSV).ID_Lop).NameLop);
            Date.Value = BLL.BLL.Instance.GetSPbyMaSP(MaSP).NgayNhap;
            CBBTinh.Text = Convert.ToString(BLL.BLL._Instance.GetDCbyMaTinh(BLL.BLL._Instance.GetSPbyMaSP(MaSP).NCC.MaTinh).TenTinh);
            CBBNCC.Text = Convert.ToString(BLL.BLL._Instance.GetNCCbyMaNCC(BLL.BLL._Instance.GetSPbyMaSP(MaSP).MaNCC).TenNCC);
            txtSoLuong.Text = Convert.ToString(BLL.BLL.Instance.GetSPbyMaSP(MaSP).SoLuongSP);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SP s = new SP();
            if (txtMaSP.Text == "" || txtTenSP.Text == "" ||txtGia.Text =="" || txtSoLuong.Text == "" || Date.Value == null || CBBTinh.Text == null || CBBNCC.Text == null ) MessageBox.Show("ERROR");

            else
            {

                s.MaSP = txtMaSP.Text;
                s.TenSP = txtTenSP.Text;
                /*NCC data = new NCC();
                data.TenNCC = CBBNCC.Text;*/
                s.MaNCC = ((CBBItems)CBBNCC.SelectedItem).Value;
                s.GiaNhap = float.Parse(txtGia.Text);
                s.SoLuongSP = Convert.ToInt32(txtSoLuong.Text);
                s.NgayNhap = Date.Value;
                /*DiaChi dc = new DiaChi();
                dc.TenTinh = CBBTinh.Text;*/
                //s.NCC.MaTinh = ((CBBItems1)CBBTinh.SelectedItem).Value;
            }

            BLL.BLL.Instance.ExecuteDB(s);
            d("ALL", "ALL","");
            this.Dispose();
        }
    }
}
