using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        IEnumerable<KhachHang> GetByKHTheoLoaiKH(string loaikh, int page, int pageSize, out int totalRow);
        IEnumerable<KhachHang> GetListAll(int page, int pageSize, out int totalRow);
    }
    public class KhachHangRepository : RepositoryBase<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<KhachHang> GetByKHTheoLoaiKH(string loaikh, int page, int pageSize, out int totalRow)
        {
            var query = from kh in DbContext.KhachHangs
                        join l in DbContext.LoaiKhachHangs
                        on kh.MALOAI_KH equals l.MALOAI_KH
                        where l.TENLOAI_KH == loaikh
                        select kh;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MAKH).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public IEnumerable<KhachHang> GetListAll(int page, int pageSize, out int totalRow)
        {
            var query = from kh in DbContext.KhachHangs
                        select kh;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MAKH).Skip((page - 1) * pageSize).Take(pageSize);
            throw new NotImplementedException();
        }
    }
}
