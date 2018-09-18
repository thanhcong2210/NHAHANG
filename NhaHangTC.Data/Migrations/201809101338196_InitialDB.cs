namespace NhaHangTC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BAN",
                c => new
                    {
                        MABAN = c.Int(nullable: false, identity: true),
                        TENTANG = c.String(maxLength: 50),
                        TRANGTHAIBAN = c.Boolean(nullable: false),
                        MATANG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MABAN)
                .ForeignKey("dbo.TANG", t => t.MATANG, cascadeDelete: true)
                .Index(t => t.MATANG);
            
            CreateTable(
                "dbo.TANG",
                c => new
                    {
                        MATANG = c.Int(nullable: false, identity: true),
                        TENTANG = c.String(maxLength: 20),
                        MANHAHANG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MATANG)
                .ForeignKey("dbo.NHAHANG", t => t.MANHAHANG, cascadeDelete: true)
                .Index(t => t.MANHAHANG);
            
            CreateTable(
                "dbo.NHAHANG",
                c => new
                    {
                        MANHAHANG = c.Int(nullable: false, identity: true),
                        TENNHAHANG = c.String(maxLength: 100),
                        SDT = c.String(maxLength: 10),
                        GIOITHIEU = c.String(maxLength: 200),
                        DIACHI = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MANHAHANG);
            
            CreateTable(
                "dbo.CHITIETGIOHANG",
                c => new
                    {
                        MAMON = c.Int(nullable: false),
                        MAGH = c.Int(nullable: false),
                        SLUONG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MAMON, t.MAGH })
                .ForeignKey("dbo.GIOHANG", t => t.MAGH, cascadeDelete: true)
                .ForeignKey("dbo.MONAN", t => t.MAMON, cascadeDelete: true)
                .Index(t => t.MAMON)
                .Index(t => t.MAGH);
            
            CreateTable(
                "dbo.GIOHANG",
                c => new
                    {
                        MAGH = c.Int(nullable: false, identity: true),
                        MAKH = c.Int(nullable: false),
                        NGAYDAT = c.DateTime(nullable: false),
                        TRANGTHAI = c.Boolean(nullable: false),
                        DIACHINHAN = c.String(nullable: false, maxLength: 350),
                    })
                .PrimaryKey(t => t.MAGH)
                .ForeignKey("dbo.KHACHHANG", t => t.MAKH, cascadeDelete: true)
                .Index(t => t.MAKH);
            
            CreateTable(
                "dbo.KHACHHANG",
                c => new
                    {
                        MAKH = c.Int(nullable: false, identity: true),
                        MALOAI_KH = c.Int(nullable: false),
                        MADATBAN = c.Int(nullable: false),
                        HOTEN_KH = c.String(nullable: false, maxLength: 100),
                        DIACHI_KH = c.String(nullable: false, maxLength: 200),
                        EMAIL_KH = c.String(nullable: false, maxLength: 100),
                        SDT_KH = c.String(nullable: false, maxLength: 11),
                        NGAYSINH_KH = c.DateTime(nullable: false),
                        GIOITINH_KH = c.Boolean(nullable: false),
                        TENDANGNHAP_KH = c.String(maxLength: 20),
                        MATKHAU_KH = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MAKH)
                .ForeignKey("dbo.DONDATBAN", t => t.MADATBAN, cascadeDelete: true)
                .ForeignKey("dbo.LOAIKHACHHANG", t => t.MALOAI_KH, cascadeDelete: true)
                .Index(t => t.MALOAI_KH)
                .Index(t => t.MADATBAN);
            
            CreateTable(
                "dbo.DONDATBAN",
                c => new
                    {
                        MADATBAN = c.Int(nullable: false, identity: true),
                        MATAIKHOAN = c.Int(nullable: false),
                        MAKH = c.Int(nullable: false),
                        SOLUONGNGUOI = c.Int(nullable: false),
                        NGAYDEN = c.DateTime(nullable: false),
                        GIODEN = c.DateTime(nullable: false),
                        TRANGTHAIDONDAT = c.Boolean(nullable: false),
                        KhachHang_MAKH = c.Int(),
                    })
                .PrimaryKey(t => t.MADATBAN)
                .ForeignKey("dbo.KHACHHANG", t => t.MAKH, cascadeDelete: false)
                .ForeignKey("dbo.TAIKHOANUSER", t => t.MATAIKHOAN, cascadeDelete: false)
                .ForeignKey("dbo.KHACHHANG", t => t.KhachHang_MAKH)
                .Index(t => t.MATAIKHOAN)
                .Index(t => t.MAKH)
                .Index(t => t.KhachHang_MAKH);
            
            CreateTable(
                "dbo.TAIKHOANUSER",
                c => new
                    {
                        MATAIKHOAN = c.Int(nullable: false, identity: true),
                        TENDANGNHAP = c.String(nullable: false, maxLength: 20),
                        MATKHAU = c.String(nullable: false, maxLength: 50),
                        QUYENSD = c.String(nullable: false, maxLength: 10),
                        TRANGTHAIKICHHOAT = c.Boolean(nullable: false),
                        MANV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MATAIKHOAN)
                .ForeignKey("dbo.NHANVIEN", t => t.MANV, cascadeDelete: true)
                .Index(t => t.MANV);
            
            CreateTable(
                "dbo.NHANVIEN",
                c => new
                    {
                        MANV = c.Int(nullable: false, identity: true),
                        HOTEN_NV = c.String(nullable: false, maxLength: 100),
                        SDT_NV = c.String(nullable: false, maxLength: 10),
                        DIACHI_NV = c.String(nullable: false, maxLength: 200),
                        EMAIL_NV = c.String(nullable: false, maxLength: 200),
                        NGAYSINH_NV = c.DateTime(nullable: false),
                        GIOITINH_NV = c.Boolean(nullable: false),
                        MANHAHANG = c.Int(nullable: false),
                        MACV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MANV)
                .ForeignKey("dbo.CHUCVU", t => t.MACV, cascadeDelete: true)
                .ForeignKey("dbo.NHAHANG", t => t.MANHAHANG, cascadeDelete: true)
                .Index(t => t.MANHAHANG)
                .Index(t => t.MACV);
            
            CreateTable(
                "dbo.CHUCVU",
                c => new
                    {
                        MACV = c.Int(nullable: false, identity: true),
                        TENCV = c.String(maxLength: 20),
                        MOTACV = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MACV);
            
            CreateTable(
                "dbo.LOAIKHACHHANG",
                c => new
                    {
                        MALOAI_KH = c.Int(nullable: false, identity: true),
                        TENLOAI_KH = c.String(maxLength: 20),
                        MOTALOAI_KH = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MALOAI_KH);
            
            CreateTable(
                "dbo.MONAN",
                c => new
                    {
                        MAMON = c.Int(nullable: false, identity: true),
                        TENGOI = c.String(nullable: false, maxLength: 50),
                        DONGIA = c.Single(nullable: false),
                        MOTA = c.String(nullable: false, maxLength: 1500),
                        CACHLAM = c.String(nullable: false, maxLength: 1500),
                        NGAYTAOMOI = c.DateTime(nullable: false),
                        MADVTINH = c.Int(nullable: false),
                        MALOAI = c.Int(nullable: false),
                        MAHINHANH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MAMON)
                .ForeignKey("dbo.DONVITINH", t => t.MADVTINH, cascadeDelete: true)
                .ForeignKey("dbo.HINHANH", t => t.MAHINHANH, cascadeDelete: true)
                .ForeignKey("dbo.BAN", t => t.MALOAI, cascadeDelete: true)
                .Index(t => t.MADVTINH)
                .Index(t => t.MALOAI)
                .Index(t => t.MAHINHANH);
            
            CreateTable(
                "dbo.DONVITINH",
                c => new
                    {
                        MADVTINH = c.Int(nullable: false, identity: true),
                        TENDVTINH = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.MADVTINH);
            
            CreateTable(
                "dbo.HINHANH",
                c => new
                    {
                        MAHINHANH = c.Int(nullable: false, identity: true),
                        DUONGDAN1 = c.String(nullable: false, maxLength: 350),
                        DUONGDAN2 = c.String(nullable: false, maxLength: 350),
                        DUONGDAN3 = c.String(nullable: false, maxLength: 350),
                    })
                .PrimaryKey(t => t.MAHINHANH);
            
            CreateTable(
                "dbo.CHITIETHOADON",
                c => new
                    {
                        MAHD = c.Int(nullable: false),
                        MAMON = c.Int(nullable: false),
                        SOLUONG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MAHD, t.MAMON })
                .ForeignKey("dbo.HOADON", t => t.MAHD, cascadeDelete: true)
                .ForeignKey("dbo.MONAN", t => t.MAMON, cascadeDelete: true)
                .Index(t => t.MAHD)
                .Index(t => t.MAMON);
            
            CreateTable(
                "dbo.HOADON",
                c => new
                    {
                        MAHD = c.Int(nullable: false, identity: true),
                        THOIGIANDEN = c.DateTime(nullable: false),
                        THOIGIANDI = c.DateTime(nullable: false),
                        NGAYTHANHTOAN = c.DateTime(nullable: false),
                        TRANGTHAIHOADON = c.DateTime(nullable: false),
                        GHICHU = c.String(nullable: false, maxLength: 200),
                        GIAMGIA = c.Single(nullable: false),
                        MABAN = c.Int(nullable: true),
                        MATAIKHOAN = c.Int(nullable: false),
                        MAKH = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.MAHD)
                .ForeignKey("dbo.BAN", t => t.MABAN, cascadeDelete: false)
                .ForeignKey("dbo.KHACHHANG", t => t.MAKH, cascadeDelete: false)
                .ForeignKey("dbo.TAIKHOANUSER", t => t.MATAIKHOAN, cascadeDelete: false)
                .Index(t => t.MABAN)
                .Index(t => t.MATAIKHOAN)
                .Index(t => t.MAKH);
            
            CreateTable(
                "dbo.CHITIETPHIEUNHAP",
                c => new
                    {
                        MATHUCPHAM = c.Int(nullable: false),
                        MAPHIEUNHAP = c.Int(nullable: false),
                        MATAIKHOAN = c.Int(nullable: false),
                        SOLUONGNHAP = c.Int(nullable: false),
                        DONGIANHAP = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.MATHUCPHAM, t.MAPHIEUNHAP, t.MATAIKHOAN })
                .ForeignKey("dbo.PHIEUNHAP", t => t.MAPHIEUNHAP, cascadeDelete: true)
                .ForeignKey("dbo.TAIKHOANUSER", t => t.MATAIKHOAN, cascadeDelete: true)
                .ForeignKey("dbo.THUCPHAM", t => t.MATHUCPHAM, cascadeDelete: true)
                .Index(t => t.MATHUCPHAM)
                .Index(t => t.MAPHIEUNHAP)
                .Index(t => t.MATAIKHOAN);
            
            CreateTable(
                "dbo.PHIEUNHAP",
                c => new
                    {
                        MAPHIEUNHAP = c.Int(nullable: false, identity: true),
                        NGAYNHAP = c.DateTime(nullable: false),
                        MANCC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MAPHIEUNHAP)
                .ForeignKey("dbo.NHACUNGCAP", t => t.MANCC, cascadeDelete: true)
                .Index(t => t.MANCC);
            
            CreateTable(
                "dbo.NHACUNGCAP",
                c => new
                    {
                        MANCC = c.Int(nullable: false, identity: true),
                        TEN_NCC = c.String(nullable: false, maxLength: 100),
                        DIACHI_NCC = c.String(nullable: false, maxLength: 200),
                        SDT_NCC = c.String(nullable: false, maxLength: 11),
                        GHICHUTHEM = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.MANCC);
            
            CreateTable(
                "dbo.THUCPHAM",
                c => new
                    {
                        MATHUCPHAM = c.Int(nullable: false, identity: true),
                        TENTHUCPHAM = c.String(nullable: false, maxLength: 50),
                        DVTINH = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MATHUCPHAM);
            
            CreateTable(
                "dbo.DUYETGIOHANG",
                c => new
                    {
                        MADUYET = c.Int(nullable: false, identity: true),
                        MATAIKHOAN = c.Int(nullable: false),
                        MAGH = c.Int(nullable: false),
                        NGAYDUYET = c.DateTime(nullable: false),
                        TRANGTHAIDUYET = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MADUYET)
                .ForeignKey("dbo.GIOHANG", t => t.MAGH, cascadeDelete: true)
                .ForeignKey("dbo.TAIKHOANUSER", t => t.MATAIKHOAN, cascadeDelete: true)
                .Index(t => t.MATAIKHOAN)
                .Index(t => t.MAGH);
            
            CreateTable(
                "dbo.LOAIMONAN",
                c => new
                    {
                        MALOAI = c.Int(nullable: false, identity: true),
                        TENLOAI = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.MALOAI);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DUYETGIOHANG", "MATAIKHOAN", "dbo.TAIKHOANUSER");
            DropForeignKey("dbo.DUYETGIOHANG", "MAGH", "dbo.GIOHANG");
            DropForeignKey("dbo.CHITIETPHIEUNHAP", "MATHUCPHAM", "dbo.THUCPHAM");
            DropForeignKey("dbo.CHITIETPHIEUNHAP", "MATAIKHOAN", "dbo.TAIKHOANUSER");
            DropForeignKey("dbo.CHITIETPHIEUNHAP", "MAPHIEUNHAP", "dbo.PHIEUNHAP");
            DropForeignKey("dbo.PHIEUNHAP", "MANCC", "dbo.NHACUNGCAP");
            DropForeignKey("dbo.CHITIETHOADON", "MAMON", "dbo.MONAN");
            DropForeignKey("dbo.CHITIETHOADON", "MAHD", "dbo.HOADON");
            DropForeignKey("dbo.HOADON", "MATAIKHOAN", "dbo.TAIKHOANUSER");
            DropForeignKey("dbo.HOADON", "MAKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.HOADON", "MABAN", "dbo.BAN");
            DropForeignKey("dbo.CHITIETGIOHANG", "MAMON", "dbo.MONAN");
            DropForeignKey("dbo.MONAN", "MALOAI", "dbo.BAN");
            DropForeignKey("dbo.MONAN", "MAHINHANH", "dbo.HINHANH");
            DropForeignKey("dbo.MONAN", "MADVTINH", "dbo.DONVITINH");
            DropForeignKey("dbo.CHITIETGIOHANG", "MAGH", "dbo.GIOHANG");
            DropForeignKey("dbo.GIOHANG", "MAKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.KHACHHANG", "MALOAI_KH", "dbo.LOAIKHACHHANG");
            DropForeignKey("dbo.DONDATBAN", "KhachHang_MAKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.KHACHHANG", "MADATBAN", "dbo.DONDATBAN");
            DropForeignKey("dbo.DONDATBAN", "MATAIKHOAN", "dbo.TAIKHOANUSER");
            DropForeignKey("dbo.TAIKHOANUSER", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.NHANVIEN", "MANHAHANG", "dbo.NHAHANG");
            DropForeignKey("dbo.NHANVIEN", "MACV", "dbo.CHUCVU");
            DropForeignKey("dbo.DONDATBAN", "MAKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.BAN", "MATANG", "dbo.TANG");
            DropForeignKey("dbo.TANG", "MANHAHANG", "dbo.NHAHANG");
            DropIndex("dbo.DUYETGIOHANG", new[] { "MAGH" });
            DropIndex("dbo.DUYETGIOHANG", new[] { "MATAIKHOAN" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANCC" });
            DropIndex("dbo.CHITIETPHIEUNHAP", new[] { "MATAIKHOAN" });
            DropIndex("dbo.CHITIETPHIEUNHAP", new[] { "MAPHIEUNHAP" });
            DropIndex("dbo.CHITIETPHIEUNHAP", new[] { "MATHUCPHAM" });
            DropIndex("dbo.HOADON", new[] { "MAKH" });
            DropIndex("dbo.HOADON", new[] { "MATAIKHOAN" });
            DropIndex("dbo.HOADON", new[] { "MABAN" });
            DropIndex("dbo.CHITIETHOADON", new[] { "MAMON" });
            DropIndex("dbo.CHITIETHOADON", new[] { "MAHD" });
            DropIndex("dbo.MONAN", new[] { "MAHINHANH" });
            DropIndex("dbo.MONAN", new[] { "MALOAI" });
            DropIndex("dbo.MONAN", new[] { "MADVTINH" });
            DropIndex("dbo.NHANVIEN", new[] { "MACV" });
            DropIndex("dbo.NHANVIEN", new[] { "MANHAHANG" });
            DropIndex("dbo.TAIKHOANUSER", new[] { "MANV" });
            DropIndex("dbo.DONDATBAN", new[] { "KhachHang_MAKH" });
            DropIndex("dbo.DONDATBAN", new[] { "MAKH" });
            DropIndex("dbo.DONDATBAN", new[] { "MATAIKHOAN" });
            DropIndex("dbo.KHACHHANG", new[] { "MADATBAN" });
            DropIndex("dbo.KHACHHANG", new[] { "MALOAI_KH" });
            DropIndex("dbo.GIOHANG", new[] { "MAKH" });
            DropIndex("dbo.CHITIETGIOHANG", new[] { "MAGH" });
            DropIndex("dbo.CHITIETGIOHANG", new[] { "MAMON" });
            DropIndex("dbo.TANG", new[] { "MANHAHANG" });
            DropIndex("dbo.BAN", new[] { "MATANG" });
            DropTable("dbo.LOAIMONAN");
            DropTable("dbo.DUYETGIOHANG");
            DropTable("dbo.THUCPHAM");
            DropTable("dbo.NHACUNGCAP");
            DropTable("dbo.PHIEUNHAP");
            DropTable("dbo.CHITIETPHIEUNHAP");
            DropTable("dbo.HOADON");
            DropTable("dbo.CHITIETHOADON");
            DropTable("dbo.HINHANH");
            DropTable("dbo.DONVITINH");
            DropTable("dbo.MONAN");
            DropTable("dbo.LOAIKHACHHANG");
            DropTable("dbo.CHUCVU");
            DropTable("dbo.NHANVIEN");
            DropTable("dbo.TAIKHOANUSER");
            DropTable("dbo.DONDATBAN");
            DropTable("dbo.KHACHHANG");
            DropTable("dbo.GIOHANG");
            DropTable("dbo.CHITIETGIOHANG");
            DropTable("dbo.NHAHANG");
            DropTable("dbo.TANG");
            DropTable("dbo.BAN");
        }
    }
}
