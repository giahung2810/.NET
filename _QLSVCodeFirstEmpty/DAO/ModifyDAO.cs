using _QLSVCodeFirstEmpty.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _QLSVCodeFirstEmpty.DAO
{
    public class ModifyDAO
    {
        
        public static ModifyDAO _Instance;
        public static ModifyDAO Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ModifyDAO();
                }
                return _Instance;
            }
            private set { }
        }
        private ModifyDAO()
        {

        }
        public List<SV> ListSV(int _id, string _name)
        {
            CSDL db = new CSDL();
            if (_id == 0)
            {
                if (_name != null)
                {
                    return db.SVs.Where(p => p.NameSV.Contains(_name)).ToList();
                }
                else
                {
                    return db.SVs.ToList();
                }
            }
            else
            {
                if (_name != null)
                {
                    return db.SVs.Where(p => p.ID_Lop == _id && p.NameSV.Contains(_name)).ToList();
                }
                else
                {
                    return db.SVs.Where(p => p.ID_Lop == _id).ToList();
                }
            }
        }
        public List<CBBItem> GetCBBItem()
        {
            CSDL db = new CSDL();
            List<CBBItem> data = new List<CBBItem>();
            foreach (var items in db.LSHes)
            {
                data.Add(new CBBItem { Text = items.NameLop, Value = items.ID_Lop });

            }
            return data;
        }
        public void Add(SV sv)
        {
            using (CSDL csdl = new CSDL())
            {
                csdl.SVs.Add(sv);
                csdl.SaveChanges();
            }
        }
        public List<SV> Sort(string _property =null)
        {
            CSDL db = new CSDL();
            switch (_property)
            {
                case "MSSV":
                    return db.SVs.OrderBy(p => p.MSSV).ToList();
                case "NameSV":
                    return db.SVs.OrderBy(p => p.NameSV).ToList();
                case "Gender":
                    return db.SVs.OrderBy(p => p.Gender).ToList();
                case "NS":
                    return db.SVs.OrderBy(p => p.NS).ToList();
                case "ID_Lop":
                    return db.SVs.OrderBy(p => p.ID_Lop).ToList();         
            }
            return db.SVs.ToList();
        }
       
    }
}
