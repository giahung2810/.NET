using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace _QLSVCodeFirstEmpty.DTO
{
    public class CreateDB : CreateDatabaseIfNotExists<CSDL>
    {
        protected override void Seed(CSDL context)
        {
            context.LSHes.AddRange(new LSH[]
            {
                new LSH{ID_Lop = 1, NameLop = "19t2"},
                new LSH{ID_Lop = 2, NameLop = "19t3"}
            });
            context.SVs.AddRange(new SV[]
            {
                new SV{MSSV = "101" ,NameSV = "NVA", Gender = true, NS = DateTime.Now , ID_Lop =1 },
                new SV{MSSV = "102" ,NameSV = "NVB", Gender = true, NS = DateTime.Now , ID_Lop =2 },
                new SV{MSSV = "103" ,NameSV = "NVC", Gender = true, NS = DateTime.Now , ID_Lop =1 }
            });
            
        }
    }
}
