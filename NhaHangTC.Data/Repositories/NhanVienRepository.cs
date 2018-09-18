using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface INhanVienRepository : IRepository<NhanVien>
    {
        IEnumerable<NhanVien> GetListNhanVienByCV(string tencv, int page, int pageSize, out int totalRow);
    }
    public class NhanVienRepository : RepositoryBase<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<NhanVien> GetListNhanVienByCV(string tencv, int page, int pageSize, out int totalRow)
        {
            var query = from nv in DbContext.NhanViens
                        join cv in DbContext.ChucVus
                        on nv.MACV equals cv.MACV
                        where cv.TENCV == tencv
                        select nv;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MANV).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
