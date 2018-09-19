using NhaHangTC.Model.Models;
using NhaHangTC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaHangTC.Web.Infrastructure.Core
{
    public static class EntityExtensions
    {
        public static void UpdateLoaiMonAn(this LoaiMonAn loaiMonAn, LoaiMonAnViewModel loaiMonAnVm)
        {
            loaiMonAn.MALOAI = loaiMonAnVm.MALOAI;
            loaiMonAn.TENLOAI = loaiMonAn.TENLOAI;
        }

        public static void UpdateMonAn(this MonAn product, MonAnViewModel productVm)
        {
            product.MAMON = productVm.MAMON;
            product.MADVTINH = productVm.MADVTINH;
            product.MALOAI = productVm.MALOAI;
            product.MAHINHANH = productVm.MAHINHANH;
            product.TENGOI = productVm.TENGOI;
            product.DONGIA = productVm.DONGIA;
            product.MOTA = productVm.MOTA;
            product.CACHLAM = productVm.CACHLAM;
            product.NGAYTAOMOI = productVm.NGAYTAOMOI;
    }
    }
}