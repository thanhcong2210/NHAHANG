using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IChucVuRepository : IRepository<ChucVu>
    {
        IEnumerable<ChucVu> GetByChucVu(string tencv);
    }
    public class ChucVuRepository: RepositoryBase<ChucVu> , IChucVuRepository
    {
        public ChucVuRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ChucVu> GetByChucVu(string tencv)
        {
            return this.DbContext.ChucVus.Where(x => x.TENCV == tencv);
            //throw new NotImplementedException();
        }
    }
}
