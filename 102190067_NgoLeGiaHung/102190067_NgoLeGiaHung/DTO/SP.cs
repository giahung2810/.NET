using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DTO
{
    public class SP
    {
        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        public string TenSP { get; set; }
        public float GiaNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuongSP { get; set; }
        public int MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NCC NCC { get; set; }
    }
}
