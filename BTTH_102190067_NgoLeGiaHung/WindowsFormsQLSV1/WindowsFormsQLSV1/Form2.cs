using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsQLSV1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetCBB();
            SetcbbSort();

        }
        public void SetCBB()
        {
            comboBoxClass1.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach(LSH i in CSDL_OOP.Instance.GetAllLSH()) 
            {
                comboBoxClass1.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
            comboBoxClass1.SelectedIndex = 0;
        }
        public void SetcbbSort()
        {
            comboBox.Items.AddRange(new string[] { "MSSV", "Name", "Lop" });
        }
        public void Show(int ID_Lop , string Name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(ID_Lop, Name);
        }
        private void butShow_Click(object sender, EventArgs e)
        {
            int Id_Class = ((CBBItem)comboBoxClass1.SelectedItem).Value;
            string NameSV = tbSearch.Text;
            if (comboBoxClass1.SelectedItem.ToString() == "All")
            {
                dataGridView1.DataSource = CSDL.Instance.DTSV; 
            }
            else
            {
                //dataGridView1.DataSource = null;
                //dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(Id_Class, NameSV);
                Show(((CBBItem)comboBoxClass1.SelectedItem).Value, tbSearch.Text);
            }    
            
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(null);
            f1.d += new Form1.MyDel(Show);
            f1.ShowDialog();
        }

        private void butUp_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Form1 f1 = new Form1(MSSV);
                f1.d += new Form1.MyDel(Show);
                f1.ShowDialog();
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                CSDL_OOP.Instance.DeleteSV(MSSV);
            }
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.Sort(comboBox.SelectedItem.ToString());
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            string Lop = ((CBBItem)comboBoxClass1.SelectedItem).Value.ToString();
            string Ten = tbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_OOP.Instance.GetSV(Lop, Ten);
        }
    }
}
