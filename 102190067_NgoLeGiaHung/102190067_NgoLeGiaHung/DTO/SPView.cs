using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DTO
{
    class SPView
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public float GiaNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool Tinhtrang { get; set; }
        public string TenNCC { get; set; }
        public string TenTinh { get; set; }

        public string GetMaSP()
        {
            return this.MaSP;
        }
    }
}
