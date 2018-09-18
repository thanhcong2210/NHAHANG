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
    public interface ILoaiKhachHangRepository : IRepository<LoaiKhachHang>
    {
        IEnumerable<LoaiKhachHang> GetByLoaiKH(string tenloai);
    }
    public class LoaiKhachHangRepository : RepositoryBase<LoaiKhachHang>, ILoaiKhachHangRepository
    {
        public LoaiKhachHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<LoaiKhachHang> GetByLoaiKH(string tenloai)
        {
            return this.DbContext.LoaiKhachHangs.Where(x => x.TENLOAI_KH == tenloai);
            // throw new NotImplementedException();
        }
    }
}
