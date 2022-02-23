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
    public partial class Form1 : Form
    {
        public delegate void MyDel(int id, string name);
        public MyDel d { get; set; }
        public string MSSV { get; set; }

        public Form1(string m)
        {
            InitializeComponent();
            MSSV = m;
            SetGUI();
            SetCBB();
        }
        public void SetCBB()
        {
            foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                comboBoxClass.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
        }

        public void SetGUI()
        {
            if(MSSV != null)
            {   
                //lay thong tin len giao dien
                tbMSSV.Text = CSDL_OOP.Instance.GetSVbyMSSV(MSSV).MSSV;
                tbName.Text = CSDL_OOP.Instance.GetSVbyMSSV(MSSV).NameSV;
                comboBoxClass.Text = Convert.ToString(CSDL_OOP.Instance.GetSVbyMSSV(MSSV).ID_Lop);
                date.Value = CSDL_OOP.Instance.GetSVbyMSSV(MSSV).NS;
                if (CSDL_OOP.Instance.GetSVbyMSSV(MSSV).Gender)
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFeMale.Checked = true;
                }
            }
            else
            {
                tbMSSV.Text = "";
                tbName.Text = "";
                comboBoxClass.SelectedIndex = CSDL_OOP.Instance.GetSVbyMSSV(MSSV).ID_Lop - 1;
                date.Value = DateTime.Now;
                rbMale.Checked = false;
                rbFeMale.Checked = false;
            }
        }

        

        private void butOk_Click(object sender, EventArgs e)
        {
            if (tbMSSV.Text == "" || tbName.Text == "" || comboBoxClass.SelectedItem.ToString() == "" || (rbFeMale.Checked == false && rbMale.Checked == false)) MessageBox.Show("ERROR");

            else
            {
                SV s = new SV();
                s.MSSV = tbMSSV.Text;
                s.NameSV = tbName.Text;
                LSH data = new LSH();
                data.NameLop = comboBoxClass.SelectedItem.ToString();
                foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
                {
                    if (i.NameLop == data.NameLop)
                    {
                        s.ID_Lop = i.ID_Lop;
                    }
                }
                s.NS = date.Value;
                if (Convert.ToBoolean(rbMale.Checked))
                {
                    s.Gender = true;
                }
                else
                {
                    s.Gender = false;
                }

                CSDL_OOP.Instance.ExecuteDB(s);
                d(0, null);
                this.Dispose();
            }
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
