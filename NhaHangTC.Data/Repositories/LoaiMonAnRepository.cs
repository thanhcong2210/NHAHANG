using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface ILoaiMonAnRepository : IRepository<LoaiMonAn>
    {
        IEnumerable<LoaiMonAn> GetByLoaiMonAn(string tenloai);
    }
    public class LoaiMonAnRepository : RepositoryBase<LoaiMonAn>, ILoaiMonAnRepository
    {
        public LoaiMonAnRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<LoaiMonAn> GetByLoaiMonAn(string tenloai)
        {
            return this.DbContext.LoaiMonAns.Where(x => x.TENLOAI == tenloai);
            //throw new NotImplementedException();
        }
    }
}
