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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            SetcbbSort();
        }
        public void SetCBB()
        {
            cbbDiaChi.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (Khuvuc i in CSDL_OOP.Instance.GetAllKhuvuc())
            {
                cbbDiaChi.Items.Add(new CBBItem
                {
                    Value = i.ID_KV,
                    Text = i.DiaChi
                });
            }
            cbbDiaChi.SelectedIndex = 0;
        }
        public void SetcbbSort()
        {
            cbbSort.Items.AddRange(new string[] { "ID_kho", "Ten", "DienTich" });
        }
        public void Show(int ID_KV, string Ten)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListKho(ID_KV, Ten);
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            int Id_Kho = ((CBBItem)cbbDiaChi.SelectedItem).Value;
            string Ten = tbSearch.Text;
            if (cbbDiaChi.SelectedItem.ToString() == "All")
            {
                dataGridView1.DataSource = CSDL.Instance.DTKho;
            }
            else
            {
                //dataGridView1.DataSource = null;
                //dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(Id_Class, NameSV);
                Show(Id_Kho, Ten);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2(0);
            f1.d += new Form2.MyDel(Show);
            f1.ShowDialog();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int ID_Kho = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Kho"].Value.ToString());
                Form2 f1 = new Form2(ID_Kho);
                f1.d += new Form2.MyDel(Show);
                f1.ShowDialog();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int ID_Kho = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Kho"].Value.ToString());
                CSDL_OOP.Instance.Delete(ID_Kho);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string DiaChi = ((CBBItem)cbbDiaChi.SelectedItem).Value.ToString();
            string Ten = tbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_OOP.Instance.GetKho(DiaChi,Ten);
        }

        private void btSort_Click(object sender, EventArgs e)
        {
                dataGridView1.DataSource = CSDL_OOP.Instance.Sort(cbbSort.SelectedItem.ToString());
        }
    }
}
