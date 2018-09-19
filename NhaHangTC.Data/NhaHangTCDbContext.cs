using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NhaHangTC.Data
{
    public class NhaHangTCDbContext : IdentityDbContext<TaiKhoanUser>
    {
        public NhaHangTCDbContext() : base("QLNHAHANGTHANHCONG")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Ban> Bans { set; get; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { set; get; }
        public DbSet<ChiTietGioHang> ChiTietGioHangs { set; get; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { set; get; }
        public DbSet<ChucVu> ChucVus { set; get; }
        public DbSet<DonDatBan> DonDatBans { set; get; }
        public DbSet<DonViTinh> DonViTinhs { set; get; }
        public DbSet<DuyetGioHang> DuyetGioHangs { set; get; }
        public DbSet<GioHang> GioHangs { set; get; }
        public DbSet<HinhAnh> HinhAnhs { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<HoaDon> HoaDons { set; get; }
        public DbSet<KhachHang> KhachHangs { set; get; }
        public DbSet<LoaiKhachHang> LoaiKhachHangs { set; get; }
        public DbSet<LoaiMonAn> LoaiMonAns { set; get; }
        public DbSet<MonAn> MonAns { set; get; }
        public DbSet<NhaCungCap> NhaCungCaps { set; get; }
        public DbSet<NhaHang> NhaHangs { set; get; }
        public DbSet<NhanVien> NhanViens { set; get; }
        public DbSet<PhieuNhap> PhieuNhaps { set; get; }
        public DbSet<TaiKhoanUser> TaiKhoanUsers { set; get; }
        //public IDbSet<TaiKhoan> users { set; get; }
        //public virtual IDbSet<IUser> Users { get; set; }
        //public DbSet<TaiKhoan> IdentityUsers { get; set; }

        public DbSet<Tang> Tangs { set; get; }
        public DbSet<ThucPham> ThucPhams { set; get; }

        public static NhaHangTCDbContext Create()
        {
            return new NhaHangTCDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonDatBan>().HasRequired(d => d.KhachHang).WithOptional(k => k.DonDatBan).Map(l => l.MapKey("MAKH"));
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
