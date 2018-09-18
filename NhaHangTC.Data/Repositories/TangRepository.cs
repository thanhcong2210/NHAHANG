using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{

    public interface ITangRepository : IRepository<Tang>
    {
        IEnumerable<Tang> GetListTangTheoNhaHang(string tennhahang, int page, int pageSize, out int totalRow);
    }
    public class TangRepository: RepositoryBase<Tang>, ITangRepository
    {
        public TangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tang> GetListTangTheoNhaHang(string tennhahang, int page, int pageSize, out int totalRow)
        {

            var query = from t in DbContext.Tangs
                        join nh in DbContext.NhaHangs
                        on t.MATANG equals nh.MANHAHANG
                        where nh.TENNHAHANG == tennhahang
                        select t;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MATANG).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
