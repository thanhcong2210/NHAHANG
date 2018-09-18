using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Model.Models
{
    [Table("TAIKHOANUSER")]
    public class TaiKhoanUser 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MATAIKHOAN { set; get; }

        [Required]
        [MaxLength(20)]
        public string TENDANGNHAP { set; get; }

        [Required]
        [MaxLength(50)]
        public string MATKHAU { set; get; }

        [Required]
        [MaxLength(10)]
        public string QUYENSD { set; get; }

        [Required]
        public bool TRANGTHAIKICHHOAT { set; get; }

        [Required]
        public int MANV { set; get; }

        [ForeignKey("MANV")]
        public virtual NhanVien NhanVien { set; get; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TaiKhoan> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var taikhoanIdentity = await manager.CreateIdentityAsync(this, authenticationType);
        //    // Add custom user claims here
        //    return taikhoanIdentity;
        //}
        public virtual IEnumerable<DuyetGioHang> DuyetGioHangs { set; get; }
        //public virtual ICollection<DuyetGioHang> DuyetGioHangs { get; set; }
    }
}
