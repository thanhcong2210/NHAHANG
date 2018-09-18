using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IHinhAnhRepository : IRepository<HinhAnh>
    {
        IEnumerable<HinhAnh> GetByMaHA(int maha);
    }
    public class HinhAnhRepository: RepositoryBase<HinhAnh>, IHinhAnhRepository
    {
        public HinhAnhRepository (IDbFactory dbFactory ):base(dbFactory)
        {
        }
        public IEnumerable<HinhAnh> GetByMaHA(int maha)
        {
            return this.DbContext.HinhAnhs.Where(x => x.MAHINHANH == maha);
            //throw new NotImplementedException();
        }
    }
}
