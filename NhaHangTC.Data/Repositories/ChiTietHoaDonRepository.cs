using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IChiTietHoaDonRepository : IRepository<ChiTietHoaDon>
    {
    }
    public class ChiTietHoaDonRepository : RepositoryBase<ChiTietHoaDon>, IChiTietHoaDonRepository
    {
        public ChiTietHoaDonRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
