using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("DONVITINH")]
    public class DonViTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MADVTINH { set; get; }

        [Required]
        [MaxLength(10)]
        public string TENDVTINH { set; get; }

        public virtual IEnumerable<MonAn> MonAns { set; get; }
    }
}
