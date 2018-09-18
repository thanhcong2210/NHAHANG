using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("LOAIKHACHHANG")]
    public class LoaiKhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MALOAI_KH { set; get; }


        [MaxLength(20)]
        public string TENLOAI_KH { set; get; }


        [MaxLength(200)]
        public string MOTALOAI_KH { set; get; }

        public virtual IEnumerable<LoaiKhachHang> LoaiKhachHangs { set; get; }
    }
}
