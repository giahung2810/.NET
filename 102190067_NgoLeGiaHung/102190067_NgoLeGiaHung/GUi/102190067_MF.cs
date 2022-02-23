using _102190067_NgoLeGiaHung.DTO;
using _102190067_NgoLeGiaHung.GUi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190067_NgoLeGiaHung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBBNCC();
            SetCBBTinh();
            CBBNCC.SelectedIndex = 0;
            CBBTinh.SelectedIndex = 0;
        }
        public void SetCBBNCC()
        {
            CBBNCC.Items.Add(new CBBItems
            {
                Value = 0,
                Text = "ALL"
            });
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

            CBBTinh.Items.Add(new CBBItems1
            {
                Value = "0",
                Text = "ALL"
            });
            foreach (DiaChi l in BLL.BLL.Instance.GetAllDiaChi_BLL())
            {
                CBBTinh.Items.Add(new CBBItems1
                {
                    Value = l.MaTinh,
                    Text = l.TenTinh,
                });
            }
        }
        public void ShowSP(string ncc,string dc, string name)
        {
            dataGridView1.DataSource = BLL.BLL.Instance.ShowSPGridView(BLL.BLL.Instance.GetListSP_BLL(ncc,dc,name));
        }

        private void CBBTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(((CBBItems1)CBBTinh.SelectedItem).Text == "ALL")
            {
                SetCBBNCC();
                CBBNCC.SelectedIndex = 0;
            }*/
            string tentinh = ((CBBItems1)CBBTinh.SelectedItem).Text;
            /*CBBNCC.Items.Clear();
            foreach (NCC l in BLL.BLL.Instance.getListNCC_DC(tentinh))
            {
                CBBNCC.Items.Add(new CBBItems
                {
                    Value = l.MaNCC,
                    Text = l.TenNCC,
                });
                
            }*/
            string tenncc = ((CBBItems)CBBNCC.SelectedItem).Text;
            string search = txtSearch.Text;
            Console.WriteLine(tentinh);
            ShowSP(tenncc, tentinh, search);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tentinh = ((CBBItems1)CBBTinh.SelectedItem).Text;
            string tenncc = ((CBBItems)CBBNCC.SelectedItem).Text;
            string search = txtSearch.Text;
            ShowSP(tenncc, tentinh, search);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaSP = "";
            _102190067_DF f = new _102190067_DF(MaSP);
            f.d += new _102190067_DF.MyDel(ShowSP);
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaSP = ((SPView)dataGridView1.SelectedRows[0].DataBoundItem).GetMaSP();
                _102190067_DF f = new _102190067_DF(MaSP);
                f.d += new _102190067_DF.MyDel(ShowSP);
                f.ShowInf(MaSP);
                f.ShowDialog();
            }
        }

        private void bthDel_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection sr = dataGridView1.SelectedRows;
            if(sr.Count >= 1)
            {
                foreach (DataGridViewRow i in sr)
                {
                    BLL.BLL.Instance.DeleteSP_BLL(((SPView)i.DataBoundItem).GetMaSP());
                }
            }
            else
            {
                MessageBox.Show("chon 1 hang");
            }
            string tentinh = ((CBBItems1)CBBTinh.SelectedItem).Text;
            string tenncc = ((CBBItems)CBBNCC.SelectedItem).Text;
            string search = txtSearch.Text;
            ShowSP(tenncc, tentinh, search);
        }

        private void CBBNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string tentinh = ((CBBItems1)CBBTinh.SelectedItem).Text;
            string tenncc = ((CBBItems)CBBNCC.SelectedItem).Text;
            string search = txtSearch.Text;
            ShowSP(tenncc, tentinh, search);*/
        }
    }
}
