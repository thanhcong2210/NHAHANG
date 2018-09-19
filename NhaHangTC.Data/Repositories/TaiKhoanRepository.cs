using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoanUser>
    {
        IEnumerable<TaiKhoanUser> GetListTKTheoNV(string tennv, int page, int pageSize, out int totalRow);
        IEnumerable<TaiKhoanUser> GetListAll(int page, int pageSize, out int totalRow);
    }
    public class TaiKhoanRepository: RepositoryBase<TaiKhoanUser>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<TaiKhoanUser> GetListAll(int page, int pageSize, out int totalRow)
        {
            var query = from tk in DbContext.TaiKhoanUsers
                        select tk;
            totalRow = query.Count();
            return query.OrderByDescending(x => x.MANV).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public IEnumerable<TaiKhoanUser> GetListTKTheoNV(string tennv, int page, int pageSize, out int totalRow)
        {
            var query = from tk in DbContext.TaiKhoanUsers
                        join nv in DbContext.NhanViens
                        on tk.MANV equals nv.MANV
                        where nv.HOTEN_NV == tennv
                        select tk;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MANV).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
