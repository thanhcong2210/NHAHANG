using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("TANG")]
    public class Tang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MATANG { set; get; }


        [MaxLength(20)]
        public string TENTANG { set; get; }

        [Required]
        public int MANHAHANG { set; get; }

        [ForeignKey("MANHAHANG")]
        public virtual NhaHang NhaHang { set; get; }

        public virtual IEnumerable<Tang> Tangs { set; get; }

    }
}
