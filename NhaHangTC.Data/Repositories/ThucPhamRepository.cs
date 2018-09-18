using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IThucPhamRepository : IRepository<ThucPham>
    {
        IEnumerable<ThucPham> GetByTenThucPham(string tentp);
    }
    public class ThucPhamRepository : RepositoryBase<ThucPham>, IThucPhamRepository
    {
        public ThucPhamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ThucPham> GetByTenThucPham(string tentp)
        {
            return this.DbContext.ThucPhams.Where(x => x.TENTHUCPHAM == tentp);
            //throw new NotImplementedException();
        }
    }
}
