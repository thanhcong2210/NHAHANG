using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IDuyetGioHangRepository : IRepository<DuyetGioHang>
    {
    }
    public class DuyetGioHangRepository : RepositoryBase<DuyetGioHang>, IDuyetGioHangRepository
    {
        public DuyetGioHangRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
