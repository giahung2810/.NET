using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190067_NgoLeGiaHung_GK
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(int id, string name);
        public MyDel d { get; set; }
        public int ID_Kho { get; set; }
        public Form2(int k)
        {
            InitializeComponent();
            ID_Kho = k;
            SetCBB();
            SetGUI();
            SetcbbTrangThai();
        }
        public void SetCBB()
        {
            foreach (Khuvuc i in CSDL_OOP.Instance.GetAllKhuvuc())
            {
                cbbKhuvuc.Items.Add(new CBBItem
                {
                    Value = i.ID_KV,
                    Text = i.DiaChi
                });
            }
        }
        public void SetcbbTrangThai()
        {
            cbbTrangThai.Items.AddRange(new string[] { "FULL", "NotFULL", "KHD" });
        }
        public void SetGUI()
        {
            if (ID_Kho != 0)
            {
                tbIDKho.Text = CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).ID_Kho.ToString();
                tbTen.Text = CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).Ten;
                cbbTrangThai.Text = Convert.ToString(CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).TrangThai);
                tbDienTich.Text = CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).DienTich.ToString();
                //cbbKhuvuc.Text = Convert.ToString(CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).ID_KV);
                foreach(Khuvuc i in CSDL_OOP.Instance.GetAllKhuvuc())
                {
                    if (i.ID_KV == CSDL_OOP.Instance.GetKhobyID_Kho(ID_Kho).ID_KV)
                    {
                        cbbKhuvuc.Text = i.DiaChi;
                    }
                }
            }
            else
            {
                tbIDKho.Text = "";
                tbTen.Text = "";
                cbbTrangThai.Text = "";
                tbDienTich.Text = "";
                cbbKhuvuc.Text = "";
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbIDKho.Text == "" || tbTen.Text == "" || cbbKhuvuc.SelectedItem.ToString() == "" || tbDienTich.Text == "" || cbbTrangThai.SelectedItem.ToString() == "") MessageBox.Show("ERROR");
            else
            {
                Kho s = new Kho();
                s.ID_Kho = Convert.ToInt32(tbIDKho.Text);
                s.Ten = tbTen.Text;
                Khuvuc data = new Khuvuc();
                data.DiaChi = cbbKhuvuc.SelectedItem.ToString();
                foreach (Khuvuc i in CSDL_OOP.Instance.GetAllKhuvuc())
                {
                    if (i.DiaChi == data.DiaChi)
                    {
                        s.ID_KV = i.ID_KV;
                    }
                }
                s.DienTich = Convert.ToDouble(tbDienTich.Text);
                s.TrangThai = Convert.ToString(cbbTrangThai.SelectedItem.ToString());
                CSDL_OOP.Instance.ExecuteDB(s);
                d(0, null);
                this.Dispose();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
