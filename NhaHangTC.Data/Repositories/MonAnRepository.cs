using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IMonAnRepository : IRepository<MonAn>
    {
        IEnumerable<MonAn> GetListMonAnTheoLoai(string tenloai, int page, int pageSize, out int totalRow);
        IEnumerable<MonAn> GetListAll(int page, int pageSize, out int totalRow);
    }

    public class MonAnRepository : RepositoryBase<MonAn>, IMonAnRepository
    {
        public MonAnRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<MonAn> GetListAll(int page, int pageSize, out int totalRow)
        {
            var query = from mon in DbContext.MonAns
                        select mon;
            totalRow = query.Count();
            return query.OrderByDescending(x => x.NGAYTAOMOI).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public IEnumerable<MonAn> GetListMonAnTheoLoai(string tenloai, int page, int pageSize, out int totalRow)
        {
            var query = from m in DbContext.MonAns
                        join l in DbContext.LoaiMonAns
                        on m.MALOAI equals l.MALOAI
                        where l.TENLOAI == tenloai
                        select m;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.NGAYTAOMOI).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
