using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IDonViTinhRepository : IRepository<DonViTinh>
    {
        IEnumerable<DonViTinh> GetByTenDVT(string tendvt);
    }
    public class DonViTinhRepository: RepositoryBase<DonViTinh>, IDonViTinhRepository
    {
        public DonViTinhRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<DonViTinh> GetByTenDVT(string tendvt)
        {
            return this.DbContext.DonViTinhs.Where(x => x.TENDVTINH == tendvt);
            //throw new NotImplementedException();
        }
    }
}
