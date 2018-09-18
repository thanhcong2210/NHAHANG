using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("PHIEUNHAP")]
    public class PhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPHIEUNHAP { set; get; }

        [Required]
        public DateTime NGAYNHAP { set; get; }


        [Required]
        public int MANCC { set; get; }

        [ForeignKey("MANCC")]
        public virtual NhaCungCap NhaCungCap { set; get; }

        public virtual IEnumerable<PhieuNhap> PhieuNhaps { set; get; }
    }
}
