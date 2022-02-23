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
    public partial class Form2 : Form
    {
        public delegate void MyDel(int _id , string _name);
        public MyDel d { get; set; }
        public string MSSV;
        CSDL db = new CSDL();
        public Form2(string _mssv = null)
        {
            MSSV = _mssv;
            InitializeComponent();
            SetCBBLSH();
            SetGUI();
        }
        

        private void butOK_Click(object sender, EventArgs e)
        {
            if(MSSV == null)
            {
                ModifyDAO.Instance.Add(AddNewSV());
                d(0, null);
            }
            else
            {
                SV sv = db.SVs.FirstOrDefault(s => s.MSSV == MSSV);
                sv.NameSV = txtNameSV.Text;
                if (rFM.Checked) sv.Gender = false;
                else sv.Gender = true;
                sv.NS = Convert.ToDateTime(dateTimePicker1.Value);
                sv.ID_Lop = ((CBBItem)cbbLSH_CT.SelectedItem).Value;
                db.SaveChanges();
                MessageBox.Show("Update Success");
            }
            d(0, null);
            
            this.Dispose();
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //---------------------------------------CAC HAM CO BAN--------------------------------------------------//
        public void SetCBBLSH()
        {
            cbbLSH_CT.Items.AddRange(ModifyDAO.Instance.GetCBBItem().ToArray());
        }
        public SV AddNewSV()
        {
            SV sv = new SV();
            sv.MSSV = txtMSSV.Text;
            sv.NameSV = txtNameSV.Text;
            if (rFM.Checked) sv.Gender = false;
            else sv.Gender = true;
            sv.NS = Convert.ToDateTime(dateTimePicker1.Value);
            sv.ID_Lop = ((CBBItem)cbbLSH_CT.SelectedItem).Value;

            return sv;
        }
        public void SetGUI()
        {
            if (db.SVs.Find(MSSV) != null)
            {
                SV sv = new SV();
                sv = db.SVs.Find(MSSV);
                txtMSSV.Text = sv.MSSV;
                txtNameSV.Text = sv.NameSV;
                if ((bool)sv.Gender) rM.Checked = true;
                else rFM.Checked = true;
                dateTimePicker1.Value = (DateTime)sv.NS;
                cbbLSH_CT.SelectedIndex = (int)(sv.ID_Lop - 1);
                txtMSSV.Enabled = false;

            }
        }

        //-----------------------------------------------------------------------------------------//
    }
}
