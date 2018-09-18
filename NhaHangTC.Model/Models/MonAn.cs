using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("MONAN")]
    public class MonAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAMON { set; get; }

        [Required]
        [MaxLength(50)]
        public string TENGOI { set; get; }

        [Required]
        public float DONGIA { set; get; }

        [Required]
        [MaxLength(1500)]
        public string MOTA { set; get; }

        [Required]
        [MaxLength(1500)]
        public string CACHLAM { set; get; }

        [Required]
        public DateTime NGAYTAOMOI { set; get; }

        [Required]
        public int MADVTINH { set; get; }

        [ForeignKey("MADVTINH")]
        public virtual DonViTinh DonViTinh { set; get; }

        [Required]
        public int MALOAI { set; get; }

        [ForeignKey("MALOAI")]
        public virtual Ban LoaiMonAn { set; get; }

        [Required]
        public int MAHINHANH { set; get; }

        [ForeignKey("MAHINHANH")]
        public virtual HinhAnh HinhAnh { set; get; }

        public virtual IEnumerable<MonAn> MonAns { set; get; }
    }
}
