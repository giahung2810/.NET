using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung_GK
{
    class CSDL
    {
        public DataTable DTKho { get; set; }
        public DataTable DTKhuvuc { get; set; }

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
            DTKho = new DataTable();
            DTKho.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Kho", typeof(int)),
                new DataColumn("Ten", typeof(string)),
                new DataColumn("DienTich", typeof(double)),
                new DataColumn("Trangthai", typeof(string)),
                new DataColumn("ID_KV", typeof(int))
            });
            DataRow row = DTKho.NewRow();
            row["ID_Kho"] = 101;
            row["Ten"] = "KhoA";
            row["DienTich"] = 1000;
            row["TrangThai"] = "Full";
            row["ID_KV"] = 1;
            DTKho.Rows.Add(row);

            DataRow row1 = DTKho.NewRow();
            row1["ID_Kho"] = 102;
            row1["Ten"] = "KhoB";
            row1["DienTich"] = 1900;
            row1["TrangThai"] = "NotFull";
            row1["ID_KV"] = 2;
            DTKho.Rows.Add(row1);

            DataRow row2 = DTKho.NewRow();
            row2["ID_Kho"] = 103;
            row2["Ten"] = "KhoC";
            row2["DienTich"] = 1200;
            row2["TrangThai"] = "KHD";
            row2["ID_KV"] = 3;
            DTKho.Rows.Add(row2);

            DTKhuvuc = new DataTable();

            DTKhuvuc.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID_KV" , typeof(int)),
                new DataColumn("DiaChi",typeof(string))
            });

            DataRow row3 = DTKhuvuc.NewRow();
            row3["ID_KV"] = 1;
            row3["DiaChi"] = "NguyenVanLinh";
            DTKhuvuc.Rows.Add(row3);

            DataRow row4 = DTKhuvuc.NewRow();
            row4["ID_KV"] = 2;
            row4["DiaChi"] = "DienBienPhu";
            DTKhuvuc.Rows.Add(row4);

            DataRow row5 = DTKhuvuc.NewRow();
            row5["ID_KV"] = 3;
            row5["DiaChi"] = "NguyenLuongBang";
            DTKhuvuc.Rows.Add(row5);
        }
        public void AddDataRow(Kho s)
        {
            DataRow data = DTKho.NewRow();
            data["ID_Kho"] = s.ID_Kho;
            data["Ten"] = s.Ten;
            data["DienTich"] = s.DienTich;
            data["TrangThai"] = s.TrangThai;
            data["ID_KV"] = s.ID_KV;
            DTKho.Rows.Add(data);
            DTKho.AcceptChanges();
        }
        public void EditDataRow(Kho s)
        {
            foreach (DataRow i in DTKho.Rows)
            {
                if (Convert.ToInt32(i["ID_Kho"].ToString()) == s.ID_Kho)
                {
                    i["Ten"] = s.Ten;
                    i["DienTich"] = s.DienTich;
                    i["TrangThai"] = s.TrangThai;
                    i["ID_KV"] = s.ID_KV;
                }
            }
            DTKho.AcceptChanges();
        }
        public void DeleteDataRow(int ID_Kho)
        {
            foreach (DataRow i in DTKho.Select())
            {
                if (Convert.ToInt32(i["ID_Kho"].ToString()) == ID_Kho)
                {
                    DTKho.Rows.Remove(i);
                }
            }
            DTKho.AcceptChanges();
        }
        public static bool CompareID(Kho a, Kho b)
        {
            return a.ID_Kho > b.ID_Kho;
        }

        public static bool CompareTen(Kho a, Kho b)
        {
            return string.Compare(a.Ten, b.Ten) > 0;
        }

        public static bool CompareDT(Kho a, Kho b)
        {
            return a.DienTich > b.DienTich;
        }
    }
}
