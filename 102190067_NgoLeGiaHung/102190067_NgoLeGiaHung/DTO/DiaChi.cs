using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DTO
{
    public class DiaChi
    {
        public DiaChi()
        {
            NCCs = new HashSet<NCC>();
        }
        [Key]
        [StringLength(2)]
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public virtual ICollection<NCC> NCCs { get; set; }
    }
}
