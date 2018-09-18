using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IBanRepository : IRepository<Ban>
    {
            IEnumerable<Ban> GetListBanTheoTang(string tentang, int page, int pageSize, out int totalRow);
    }


    public class BanRepository : RepositoryBase<Ban>, IBanRepository
    {

        public BanRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Ban> GetListBanTheoTang(string tentang, int page, int pageSize, out int totalRow)
        {
            var query = from b in DbContext.Bans
                        join t in DbContext.Tangs
                        on b.MATANG equals t.MATANG
                        where t.TENTANG == tentang
                        select b;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MABAN).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
