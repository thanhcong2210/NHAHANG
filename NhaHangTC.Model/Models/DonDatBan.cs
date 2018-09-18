using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("DONDATBAN")]
    public class DonDatBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MADATBAN { set; get; }

        public int MATAIKHOAN { set; get; }

        [ForeignKey("MATAIKHOAN")]
        public virtual TaiKhoanUser TaiKhoan { set; get; }

        public int MAKH { set; get; }

        [ForeignKey("MAKH")]
        public virtual KhachHang KhachHang { set; get; }

        [InverseProperty("MAKH")] // <- Navigation property name in EntityA
        //public virtual ICollection<KhachHang> KhachHangs { set; get; }

        [Required]
        public int SOLUONGNGUOI { set; get; }

        [Required]
        public DateTime NGAYDEN { set; get; }

        [Required]
        public DateTime GIODEN { set; get; }

        [Required]
        public bool TRANGTHAIDONDAT { set; get; }



        public virtual IEnumerable<KhachHang> KhachHangs { set; get; }
    }
}
