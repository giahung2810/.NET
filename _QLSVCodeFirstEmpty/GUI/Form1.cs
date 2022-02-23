using _QLSVCodeFirstEmpty.DAO;
using _QLSVCodeFirstEmpty.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _QLSVCodeFirstEmpty.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCBBItem();
        }
        CSDL db = new CSDL();
        public void GetCBBItem()
        {

            cbbLSH.Items.Add(new CBBItem { Text = "All", Value = 0 });
            foreach (var items in db.LSHes)
            {
                cbbLSH.Items.Add(new CBBItem { Text = items.NameLop, Value = items.ID_Lop });
            }
        }
        public void ShowSV(int _id, string _name)
        {
            dataGridView1.DataSource = ModifyDAO.Instance.ListSV(_id, _name);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            int _id = ((CBBItem)cbbLSH.SelectedItem).Value;
            ShowSV(_id, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int _id = ((CBBItem)cbbLSH.SelectedItem).Value;
            ShowSV(_id, txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.d += new Form2.MyDel(ShowSV);
            form2.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                Form2 f = new Form2(MSSV);
                f.d += new Form2.MyDel(ShowSV);
                f.Show();
            }
            ShowSV(0, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridView1.SelectedRows)
            {
                string _mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                SV sv = db.SVs.Where(p => p.MSSV == _mssv).FirstOrDefault();
                db.SVs.Remove(sv);
                db.SaveChanges();
            }
            ShowSV(0, null);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string _property = cbbSort.SelectedItem.ToString();
            
            dataGridView1.DataSource = ModifyDAO.Instance.Sort(_property);
        }
    }
}
