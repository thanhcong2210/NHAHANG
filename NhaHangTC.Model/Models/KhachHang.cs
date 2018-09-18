using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("KHACHHANG")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAKH { set; get; }

        public int MALOAI_KH { set; get; }

        [ForeignKey("MALOAI_KH")]
        public virtual LoaiKhachHang LoaiKhachHang { set; get; }

        public int MADATBAN { set; get; }

        [ForeignKey("MADATBAN")]
        public virtual DonDatBan DonDatBan { set; get; }

        //[InverseProperty("MADATBAN")] // <- Navigation property name in EntityA
        //public virtual ICollection<DonDatBan> DonDatBans { set; get; }

        [Required]
        [MaxLength(100)]
        public string HOTEN_KH { set; get; }

        [Required]
        [MaxLength(200)]
        public string DIACHI_KH { set; get; }

        [Required]
        [MaxLength(100)]
        public string EMAIL_KH { set; get; }

        [Required]
        [MaxLength(11)]
        public string SDT_KH { set; get; }

        [Required]
        public DateTime NGAYSINH_KH { set; get; }

        [Required]
        public bool GIOITINH_KH { set; get; }

        [MaxLength(20)]
        public string TENDANGNHAP_KH { set; get; }

        [MaxLength(50)]
        public string MATKHAU_KH { set; get; }

        public virtual IEnumerable<DonDatBan> DonDatBans { set; get; }
    }
}
