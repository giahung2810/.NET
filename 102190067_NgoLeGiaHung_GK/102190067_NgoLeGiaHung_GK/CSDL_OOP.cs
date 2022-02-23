using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung_GK
{
    class CSDL_OOP
    {
        public delegate bool Compare(Kho s1, Kho s2);
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }
            private set { }
        }
        private CSDL_OOP()
        {

        }
        public List<Kho> GetAllKho()
        {
            List<Kho> data = new List<Kho>();
            foreach (DataRow i in CSDL.Instance.DTKho.Rows)
            {
                data.Add(GetKho(i));
            }
            return data;
        }
        public Kho GetKho(DataRow i)
        {
            return new Kho
            {
                ID_Kho = Convert.ToInt32(i["ID_Kho"]),
                Ten = i["Ten"].ToString(),
                DienTich = Convert.ToDouble(i["DienTich"]),
                TrangThai = i["TrangThai"].ToString(),
                ID_KV = Convert.ToInt32(i["ID_KV"])
            };
        }
        public List<Kho> GetKho(string DiaChi, string Ten)
        {
            Kho data = new Kho();
            foreach (Khuvuc i in CSDL_OOP.Instance.GetAllKhuvuc())
            {
                if (i.DiaChi == DiaChi)
                {
                    data.ID_KV = i.ID_KV;
                }
            }
            List<Kho> k = new List<Kho>();
            foreach (DataRow i in CSDL.Instance.DTKho.Rows)
            {
                if (data.ID_KV == 0)
                {
                    if (Ten != "")
                    {
                        if (i["Ten"].ToString().Contains(Ten))
                            k.Add(GetKho(i));
                    }
                    else
                    k.Add(GetKho(i));
                }
                else
                {
                    if (Ten != "")
                    {
                        if (i["Ten"].ToString().Contains(Ten)  && Convert.ToInt32(i["ID_KV"]) == data.ID_KV)
                        {
                            k.Add(GetKho(i));
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(i["ID_KV"]) == data.ID_KV)
                            k.Add(GetKho(i));
                    }
                }
            }
            return k;
        }
        public List<Khuvuc> GetAllKhuvuc()
        {
            List<Khuvuc> data = new List<Khuvuc>();
            foreach (DataRow i in CSDL.Instance.DTKhuvuc.Rows)
            {
                data.Add(GetKhuvuc(i));
            }
            return data;
        }
        public Khuvuc GetKhuvuc(DataRow i)
        {
            return new Khuvuc
            {
                ID_KV = Convert.ToInt32(i["ID_KV"].ToString()),
                DiaChi = i["DiaChi"].ToString()
            };
        }
        public List<Kho> GetListKho(int ID_KV, string Ten)
        {
            List<Kho> data = new List<Kho>();
            foreach (Kho i in GetAllKho())
            {
                if (i.ID_KV == ID_KV && i.Ten.Contains(Ten))
                {
                    data.Add(new Kho
                    {
                        ID_Kho = i.ID_Kho,
                        Ten = i.Ten,
                        DienTich = i.DienTich,
                        TrangThai = i.TrangThai,
                        ID_KV = i.ID_KV
                    });

                }
            }
            return data;
        }
        public void ExecuteDB(Kho s)
        {
            bool check = false;
            foreach (Kho i in GetAllKho())
            {
                if (i.ID_Kho == s.ID_Kho)
                {
                    check = true;
                }
            }
            if (check)
            {
                CSDL.Instance.EditDataRow(s);
            }
            else
            {
                CSDL.Instance.AddDataRow(s);
            }
        }
        public Kho GetKhobyID_Kho(int ID_Kho)
        {
            Kho s = new Kho();
            foreach (Kho i in GetAllKho())
            {
                if (i.ID_Kho == ID_Kho)
                {
                    s = i;
                }
            }
            return s;
        }

        

        public void Delete(int ID_Kho)
        {
            CSDL.Instance.DeleteDataRow(ID_Kho);
        }
        public List<Kho> Sort(string sortof)
        {
            List<Kho> listKho = CSDL_OOP.Instance.GetAllKho();
            Compare cp;
            for(int i = 0; i <listKho.Count -1; i++)
            {
                for(int j = i+1;j < listKho.Count; j++)
                {
                    switch(sortof)
                    {
                        case "ID_Kho":
                            {
                                cp = new Compare(CSDL.CompareID);
                                if (cp(listKho[i], listKho[j]))
                                {
                                    Kho temp = listKho[i];
                                    listKho[i] = listKho[j];
                                    listKho[j] = temp;
                                }
                                break;
                            }
                        case "Ten":
                            {
                                cp = new Compare(CSDL.CompareTen);
                                if (cp(listKho[i], listKho[j]))
                                {
                                    Kho temp = listKho[i];
                                    listKho[i] = listKho[j];
                                    listKho[j] = temp;
                                }
                                break;
                            }
                        case "DienTich":
                            {
                                cp = new Compare(CSDL.CompareDT);
                                if (cp(listKho[i], listKho[j]))
                                {
                                    Kho temp = listKho[i];
                                    listKho[i] = listKho[j];
                                    listKho[j] = temp;
                                }
                                break;
                            }
                    }
                }
            }
            return listKho;
        }
    }
}
