using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("CHITIETGIOHANG")]
    public class ChiTietGioHang
    {
        [Key]
        [Column(Order = 1)]
        public int MAMON { set; get; }

        [Key]
        [Column(Order = 2)]
        public int MAGH { set; get; }

        public int SLUONG { set; get; }

        [ForeignKey("MAMON")]
        public virtual MonAn MonAn { set; get; }

        [ForeignKey("MAGH")]
        public virtual GioHang GioHang { set; get; }
    }
}
