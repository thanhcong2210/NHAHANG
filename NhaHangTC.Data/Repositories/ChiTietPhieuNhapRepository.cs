using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IChiTietPhieuNhapRepository : IRepository<ChiTietPhieuNhap>
    {
    }
    public class ChiTietPhieuNhapRepository : RepositoryBase<ChiTietPhieuNhap>, IChiTietPhieuNhapRepository
    {
        public ChiTietPhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
