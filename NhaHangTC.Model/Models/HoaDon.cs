using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("HOADON")]
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAHD { set; get; }

        [Required]
        public DateTime THOIGIANDEN { set; get; }

        [Required]
        public DateTime THOIGIANDI { set; get; }

        [Required]
        public DateTime NGAYTHANHTOAN { set; get; }

        [Required]
        public DateTime TRANGTHAIHOADON { set; get; }

        [Required]
        [MaxLength(200)]
        public string GHICHU { set; get; }

        [Required]
        public float GIAMGIA { set; get; }

        [Required]
        public int MABAN { set; get; }
        [ForeignKey("MABAN")]
        public virtual Ban Ban { set; get; }

        [Required]
        public int MATAIKHOAN { set; get; }

        [ForeignKey("MATAIKHOAN")]
        public virtual TaiKhoanUser TaiKhoan { set; get; }

        public int MAKH { set; get; }
        [ForeignKey("MAKH")]
        public virtual KhachHang KhachHang { set; get; }

        public virtual IEnumerable<ChiTietHoaDon> ChiTietHoaDons { set; get; }
    }
}
