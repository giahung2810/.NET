using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsQLSV1
{
    class CSDL_OOP
    {
        public delegate bool Compare(SV s1, SV s2);
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if(_Instance == null)
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
        public List<SV> GetAllSV()
        {
            List<SV> data = new List<SV>();
            foreach(DataRow i  in CSDL.Instance.DTSV.Rows)
            {
                data.Add(GetSV(i));
            }
            return data;
        }
        public SV GetSV(DataRow i)
        {
            return new SV
            {
                MSSV = i["MSSV"].ToString(),
                NameSV = i["NameSV"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NS = Convert.ToDateTime(i["NS"].ToString()),
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString())
            };
        }
        public List<SV> GetSV(string Lop, string Ten)
        {
            SV data = new SV();
            foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                if (i.NameLop == Lop)
                {
                    data.ID_Lop = i.ID_Lop;
                }
            }
            List<SV> k = new List<SV>();
            foreach (DataRow i in CSDL.Instance.DTSV.Rows)
            {
                if (data.ID_Lop == 0)
                {
                    if (Ten != "")
                    {
                        if (i["NameSV"].ToString().Contains(Ten))
                            k.Add(GetSV(i));
                    }
                    else
                        k.Add(GetSV(i));
                }
                else
                {
                    if (Ten != "")
                    {
                        if (i["NameSV"].ToString().Contains(Ten) && Convert.ToInt32(i["ID_Lop"]) == data.ID_Lop)
                        {
                            k.Add(GetSV(i));
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(i["ID_Lop"]) == data.ID_Lop)
                            k.Add(GetSV(i));
                    }
                }
            }
            return k;
        }
        public List<LSH> GetAllLSH()
        {
            List<LSH> data = new List<LSH>();
            foreach(DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                data.Add(GetLSH(i));
            }
            return data;
        }
        public LSH GetLSH(DataRow i)
        {
            return new LSH
            {
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString()),
                NameLop = i["NameLop"].ToString()
            };
        }
        public List<SV> GetListSV(int ID_Lop , string Name)
        {
            List<SV> data = new List<SV>();
            foreach (SV i in GetAllSV())
            {
                if(i.ID_Lop == ID_Lop && i.NameSV.Contains(Name))
                {
                    data.Add(new SV
                    {
                        NameSV = i.NameSV,
                        MSSV = i.MSSV,
                        Gender = i.Gender,
                        NS = i.NS,
                        ID_Lop = i.ID_Lop
                    });
                    
                }
            }
            return data;
        }

        

        public void ExecuteDB(SV s)
        {
            bool check = false;
            foreach(SV i in GetAllSV())
            {
                if(i.MSSV == s.MSSV)
                {
                    check = true;
                }
            }
            if(check)
            {
                CSDL.Instance.EditDataRowSV(s);
            }
            else
            {
                CSDL.Instance.AddDataRowSV(s);
            }
        }
        public SV GetSVbyMSSV(string MSSV)
        {
            SV s = new SV();
            foreach(SV i in GetAllSV())
            {
                if(i.MSSV == MSSV)
                {
                    s = i;
                }
            }
            return s;
        }
        public void DeleteSV(string MSSV)
        {
            CSDL.Instance.DeleteDataRowSV(MSSV);
        }
        public List<SV> Sort(string sortof)
        {
            List<SV> list = CSDL_OOP.Instance.GetAllSV();
            Compare cp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    switch (sortof)
                    {
                        case "MSSV":
                            {
                                cp = new Compare(CSDL.CompareMSSV);
                                if (cp(list[i], list[j]))
                                {
                                    SV temp = list[i];
                                    list[i] = list[j];
                                    list[j] = temp;
                                }
                                break;
                            }
                        case "Name":
                            {
                                cp = new Compare(CSDL.CompareName);
                                if (cp(list[i], list[j]))
                                {
                                    SV temp = list[i];
                                    list[i] = list[j];
                                    list[j] = temp;
                                }
                                break;
                            }
                        case "Lop":
                            {
                                cp = new Compare(CSDL.CompareLop);
                                if (cp(list[i], list[j]))
                                {
                                    SV temp = list[i];
                                    list[i] = list[j];
                                    list[j] = temp;
                                }
                                break;
                            }
                    }
                }
            }
            return list;
        }
    }
}
