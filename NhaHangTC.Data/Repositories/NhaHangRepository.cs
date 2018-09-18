using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;

namespace NhaHangTC.Data.Repositories
{
    public interface INhaHangRepository : IRepository<NhaHang>
    {
        IEnumerable<NhaHang> GetByTenNhaHang(string tennhahang);
    }

    public class NhaHangRepository : RepositoryBase<NhaHang>, INhaHangRepository
    {
        public NhaHangRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<NhaHang> GetByTenNhaHang(string tennhahang)
        {
            return this.DbContext.NhaHangs.Where(x => x.TENNHAHANG == tennhahang);
            //throw new NotImplementedException();
        }
    }
}
