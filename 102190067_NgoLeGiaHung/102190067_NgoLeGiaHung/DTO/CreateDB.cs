using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DTO
{
    class CreateDB : CreateDatabaseIfNotExists<CSDL>
    {
        protected override void Seed(CSDL context)
        {
            context.DiaChis.AddRange(new DiaChi[]
            {
                new DiaChi{MaTinh = "DN", TenTinh = "Da Nang"},
                new DiaChi{MaTinh = "QN", TenTinh = "Quang Nam"}
            });
            context.NCCs.AddRange(new NCC[]
            {
                new NCC{MaNCC = 1, TenNCC = "ABC", MaTinh = "DN"},
                new NCC{MaNCC = 2, TenNCC = "GHK", MaTinh = "QN"},
                new NCC{MaNCC = 3, TenNCC = "NLG", MaTinh = "DN"}

            });
            context.SPs.AddRange(new SP[]
            {
                new SP{MaSP = "ABCD1", TenSP = "Ban", GiaNhap = 100000, NgayNhap = DateTime.Now, SoLuongSP = 9,MaNCC = 1},
                new SP{MaSP = "ABCD3", TenSP = "Ghe", GiaNhap = 50000, NgayNhap = DateTime.Now, SoLuongSP = 0,MaNCC = 2},
                new SP{MaSP = "ABCD5", TenSP = "Ghe Dai", GiaNhap = 150000, NgayNhap = DateTime.Now, SoLuongSP = 5,MaNCC = 3}
            });
        }
    }
}
