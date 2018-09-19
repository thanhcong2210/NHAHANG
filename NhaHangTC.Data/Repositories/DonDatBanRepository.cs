using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IDonDatBanRepository : IRepository<DonDatBan>
    {
        IEnumerable<DonDatBan> GetListDonDatTheoTK(string tk, int page, int pageSize, out int totalRow);
        IEnumerable<DonDatBan> GetListDonDatTheoKH(string kh, int page, int pageSize, out int totalRow);
    }
    public class DonDatBanRepository : RepositoryBase<DonDatBan>, IDonDatBanRepository
    {
        public DonDatBanRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<DonDatBan> GetListDonDatTheoKH(string kh, int page, int pageSize, out int totalRow)
        {
            var query = from d in DbContext.DonDatBans
                        join k in DbContext.KhachHangs
                        on d.MAKH equals k.MAKH
                        where k.HOTEN_KH == kh
                        select d;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MADATBAN).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public IEnumerable<DonDatBan> GetListDonDatTheoTK(string tk, int page, int pageSize, out int totalRow)
        {
            var query = from d in DbContext.DonDatBans
                        join t in DbContext.TaiKhoanUsers
                        on d.MATAIKHOAN equals t.MATAIKHOAN
                        join n in DbContext.NhanViens
                        on t.MANV equals n.MANV
                        where t.TENDANGNHAP == tk
                        select d;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.MADATBAN).Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }
    }
}
