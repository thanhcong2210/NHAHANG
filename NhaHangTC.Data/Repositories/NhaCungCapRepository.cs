using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface INhaCungCapRepository : IRepository<NhaCungCap>
    {
        IEnumerable<NhaCungCap> GetByNCC(string tenncc);
        IEnumerable<NhaCungCap> GetListAll(int page, int pageSize, out int totalRow);
    }
    public class NhaCungCapRepository : RepositoryBase<NhaCungCap>, INhaCungCapRepository
    {
        public NhaCungCapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<NhaCungCap> GetByNCC(string tenncc)
        {
            return this.DbContext.NhaCungCaps.Where(x => x.TEN_NCC == tenncc);
            // throw new NotImplementedException();
        }

        public IEnumerable<NhaCungCap> GetListAll(int page, int pageSize, out int totalRow)
        {
            var query = from ncc in DbContext.NhaCungCaps
                        select ncc;
            totalRow = query.Count();
            return query.OrderByDescending(x => x.MANCC).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
