using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190067_NgoLeGiaHung.DTO
{
    public class NCC
    {
        public NCC()
        {
            SPs = new HashSet<SP>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string MaTinh { get; set; }

        [ForeignKey("MaTinh")]
        public virtual DiaChi DiaChi { get; set; }
        public virtual ICollection<SP> SPs { get; set; }

    }
}
