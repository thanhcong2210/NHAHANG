using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("THUCPHAM")]
    public class ThucPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MATHUCPHAM { set; get; }

        [Required]
        [MaxLength(50)]
        public string TENTHUCPHAM { set; get; }

        [Required]
        [MaxLength(20)]
        public string DVTINH { set; get; }

        public virtual IEnumerable<ThucPham> ThucPhams { set; get; }
    }
}
