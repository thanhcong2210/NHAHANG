using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IChiTietGioHangRepository : IRepository<ChiTietGioHang>
    {
    }
    public class ChiTietGioHangRepository : RepositoryBase<ChiTietGioHang>, IChiTietGioHangRepository
    {
        public ChiTietGioHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
