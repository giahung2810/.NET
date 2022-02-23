using _102190067_NgoLeGiaHung.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.BLL
{
    class BLL
    {
        public static BLL _Instance;
        public delegate bool SortDelegate(SP o1, SP o2);
        public static BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL()
        {

        }
        public List<SP> GetAllSP_BLL()
        {
            return DAL.DAL.Instance.getAllSPDAL();
        }
        public List<NCC> GetAllNCC_BLL()
        {
            return DAL.DAL.Instance.getAllNCCDAL();
        }
        public List<DiaChi> GetAllDiaChi_BLL()
        {
            return DAL.DAL.Instance.getAllDiaChiDAL();
        }
        public List<SP> GetListSP_BLL(string ncc, string dc, string name)
        {
            List<SP> data = new List<SP>();
            foreach(SP i in GetAllSP_BLL())
            {
                if(name == null)
                {
                    if(ncc == "ALL")
                    {
                        if(dc == "ALL")
                        {
                            return GetAllSP_BLL();
                        }
                        else if(i.NCC.DiaChi.TenTinh == dc)
                        {
                            data.Add(i);
                        }
                    }
                    else if(i.NCC.TenNCC == ncc)
                    {
                        data.Add(i);
                    }
                }
                else if(name != null)
                {
                    if(ncc == "ALL")
                    {
                        if(dc == "ALL")
                        {
                            if(i.TenSP.Contains(name))
                            {
                                data.Add(i);
                            }
                        }
                        else if(i.NCC.DiaChi.TenTinh == dc && i.TenSP.Contains(name))
                        {
                            data.Add(i);
                        }
                    }
                    else if(i.NCC.TenNCC == ncc && i.NCC.DiaChi.TenTinh == dc && i.TenSP.Contains(name))
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public SP GetSPbyMPP(string MSP)
        {
            SP s = new SP();
            foreach (SP i in GetAllSP_BLL())
            {
                if (i.MaSP == MSP)
                {
                    s = i;
                }
            }
            return s;
        }
        public NCC GetNCCbyMaNCC(int mancc)
        {
            NCC l = new NCC();
            foreach (NCC k in GetAllNCC_BLL())
            {
                if (k.MaNCC == mancc)
                {
                    l = k;
                }
            }
            return l;
        }
        public DiaChi GetDCbyMaTinh(string matinh)
        {
            DiaChi l = new DiaChi();
            foreach (DiaChi k in GetAllDiaChi_BLL())
            {
                if (k.MaTinh == matinh)
                {
                    l = k;
                }
            }
            return l;
        }
        public SPView SPtoSPGridView(SP s)
        {
            SPView data = new SPView();
            data.MaSP = s.MaSP;
            data.TenSP = s.TenSP;
            data.GiaNhap = s.GiaNhap;
            data.NgayNhap = s.NgayNhap;
            if(s.SoLuongSP > 0)
            {
                data.Tinhtrang = true;
            }
            else
            {
                data.Tinhtrang = false;
            }
            data.TenNCC = s.NCC.TenNCC;
            data.TenTinh = s.NCC.DiaChi.TenTinh;
            return data;
        }
        public List<SPView> ShowSPGridView(List<SP> sv)
        {
            List<SPView> data = new List<SPView>();
            SPView d = new SPView();
            foreach (SP s in sv)
            {
                data.Add(SPtoSPGridView(s));
            }
            return data;
        }
        public void AddSP_BLL(SP s)
        {
            DAL.DAL.Instance.AddSPDAL(s);
        }
        public void Update_BLL(SP s)
        {
            DAL.DAL.Instance.UpdateSPDAL(s);
        }
        public void ExecuteDB(SP s)
        {
            bool check = false;
            foreach (SP i in GetAllSP_BLL())
            {
                if (i.MaSP == s.MaSP)
                {
                    check = true;
                }
            }
            if (check)
            {
                Update_BLL(s);
            }
            else
            {
                AddSP_BLL(s);
            }
        }
        public List<SP> GetListSPbyMaSP(List<string> MaSP)
        {
            List<SP> data = new List<SP>();
            foreach (string i in MaSP)
            {
                foreach (SP j in GetAllSP_BLL())
                {
                    if (j.MaSP == i)
                    {
                        data.Add(j);
                    }
                }
            }
            return data;
        }
        public SP GetSPbyMaSP(string MaSP)
        {
            SP s = new SP();
            foreach (SP i in GetAllSP_BLL())
            {
                if (i.MaSP == MaSP)
                {
                    s = i;
                }
            }
            return s;
        }
        public void DeleteSP_BLL(string MaSP)
        {
            DAL.DAL.Instance.DeleteSPDAL(MaSP);
        }
        public List<NCC> getListNCC_DC(string DC)
        {
            return DAL.DAL.Instance.getListNCC_DC(DC);
        }
    }
}
