using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("NHACUNGCAP")]
    public class NhaCungCap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MANCC { set; get; }

        [Required]
        [MaxLength(100)]
        public string TEN_NCC { set; get; }

        [Required]
        [MaxLength(200)]
        public string DIACHI_NCC { set; get; }

        [Required]
        [MaxLength(11)]
        public string SDT_NCC { set; get; }

        [Required]
        [MaxLength(200)]
        public string GHICHUTHEM { set; get; }

        public virtual IEnumerable<NhaCungCap> NhaCungCaps { set; get; }
    }
}
