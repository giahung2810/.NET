using _102190067_NgoLeGiaHung.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DAL
{
    class DAL
    {
        public static DAL _Instance;
        public static DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private DAL()
        {

        }
        public List<SP> getAllSPDAL()
        {
            CSDL db = new CSDL();
            return db.SPs.ToList();
        }
        public SP getSPbyMSPDAL(string _MSP)
        {
            CSDL db = new CSDL();
            SP sp = db.SPs.Where(x => x.MaSP.Contains(_MSP)).SingleOrDefault();
            //var sinhVien = (from s in db.SVs where s.MSSV.Contains(_MSSV) select s).SingleOrDefault();
            return sp;
        }
        public List<NCC> getAllNCCDAL()
        {
            CSDL db = new CSDL();
            return db.NCCs.ToList();
        }
        public List<DiaChi> getAllDiaChiDAL()
        {
            CSDL db = new CSDL();
            return db.DiaChis.ToList();
        }
        public List<NCC> getListNCC_DC(string DC)
        {
            CSDL db = new CSDL();
            List<NCC> lncc = new List<NCC>();
            lncc = db.NCCs.Where(x => x.DiaChi.TenTinh == DC).ToList();
            return lncc;
        }
        public void AddSPDAL(SP sp)
        {
            CSDL db = new CSDL();
            db.SPs.Add(sp);
            db.SaveChanges();
        }
        public void UpdateSPDAL(SP sp)
        {
            CSDL db = new CSDL();
            SP spFind = db.SPs.Find(sp.MaSP);
            spFind.TenSP = sp.TenSP;
            spFind.GiaNhap = sp.GiaNhap;
            spFind.NgayNhap = sp.NgayNhap;
            spFind.SoLuongSP = sp.SoLuongSP;
            spFind.MaNCC = sp.MaNCC;
            db.SaveChanges();

        }
        public void DeleteSPDAL(string _MSP)
        {
            CSDL db = new CSDL();
            SP spFind = db.SPs.Where(x => x.MaSP.Equals(_MSP)).SingleOrDefault();
            db.SPs.Remove(spFind);
            db.SaveChanges();
        }
    }
}
