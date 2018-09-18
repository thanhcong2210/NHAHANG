using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("NHAHANG")]
    public class NhaHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MANHAHANG { set; get; }


        [MaxLength(100)]
        public string TENNHAHANG { set; get; }


        [MaxLength(10)]
        public string SDT { set; get; }


        [MaxLength(200)]
        public string GIOITHIEU { set; get; }


        [MaxLength(200)]
        public string DIACHI { set; get; }

        public virtual IEnumerable<NhaHang> NhaHangs { set; get; }
    }
}
