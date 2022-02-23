using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsQLSV1
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }

        private static CSDL _Instance;
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });
            DataRow row = DTSV.NewRow();
            row["MSSV"] = "109";
            row["NameSV"] = "NVA";
            row["Gender"] = true;
            row["NS"] = DateTime.Now;
            row["ID_Lop"] = 2;
            DTSV.Rows.Add(row);

            DataRow row1 = DTSV.NewRow();
            row1["MSSV"] = "101";
            row1["NameSV"] = "NVB";
            row1["Gender"] = true;
            row1["NS"] = DateTime.Now;
            row1["ID_Lop"] = 1;
            DTSV.Rows.Add(row1);

            DataRow row2 = DTSV.NewRow();
            row2["MSSV"] = "108";
            row2["NameSV"] = "NTC";
            row2["Gender"] = false;
            row2["NS"] = DateTime.Now;
            row2["ID_Lop"] = 2;
            DTSV.Rows.Add(row2);

            DataRow row3 = DTSV.NewRow();
            row3["MSSV"] = "103";
            row3["NameSV"] = "NTD";
            row3["Gender"] = false;
            row3["NS"] = DateTime.Now;
            row3["ID_Lop"] = 1;
            DTSV.Rows.Add(row3);

            DTLSH = new DataTable();

            DTLSH.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID_Lop" , typeof(int)),
                new DataColumn("NameLop",typeof(string))
            });

            DataRow row4 = DTLSH.NewRow();
            row4["ID_Lop"] = 1;
            row4["NameLop"] = "SH1";
            DTLSH.Rows.Add(row4);

            DataRow row5 = DTLSH.NewRow();
            row5["ID_Lop"] = 2;
            row5["NameLop"] = "SH2";
            DTLSH.Rows.Add(row5);
        }
        public void AddDataRowSV(SV s)
        {
            DataRow data = DTSV.NewRow();
            data["MSSV"] = s.MSSV;
            data["NameSV"] = s.NameSV;
            data["Gender"] = s.Gender;
            data["NS"] = s.NS;
            data["ID_Lop"] = s.ID_Lop;
            DTSV.Rows.Add(data);
            DTSV.AcceptChanges();
        }
        public void EditDataRowSV(SV s)
        {
            foreach(DataRow i in DTSV.Rows)
            {
                if(i["MSSV"].ToString() == s.MSSV)
                {
                    i["NameSV"] = s.NameSV;
                    i["Gender"] = s.Gender;
                    i["NS"] = s.NS;
                    i["ID_Lop"] = s.ID_Lop;
                }    
            }
            DTSV.AcceptChanges();
        }
        public void DeleteDataRowSV(string MSSV)
        {
            foreach (DataRow i in DTSV.Select())
            {
                if (i["MSSV"].ToString() == MSSV)
                {
                    DTSV.Rows.Remove(i);     
                }
            }
            DTSV.AcceptChanges();
        }
        public static bool CompareMSSV(SV a, SV b)
        {
            return string.Compare(a.MSSV, b.MSSV) > 0;
        }

        public static bool CompareName(SV a, SV b)
        {
            return string.Compare(a.NameSV, b.NameSV) > 0;
        }

        public static bool CompareLop(SV a, SV b)
        {
            return a.ID_Lop > b.ID_Lop;
        }
    }
}

