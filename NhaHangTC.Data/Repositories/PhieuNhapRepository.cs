using NhaHangTC.Common.ViewModels;
using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Repositories
{
    public interface IPhieuNhapRepository : IRepository<PhieuNhap>
    {
        IEnumerable<ThongKeDoanhThuViewModel> GetThongKeDoanhThu(string tuNgay, string denNgay);
    }
    class PhieuNhapRepository : RepositoryBase<PhieuNhap>, IPhieuNhapRepository
    {
        public PhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ThongKeDoanhThuViewModel> GetThongKeDoanhThu(string tuNgay, string denNgay)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@tuNgay",tuNgay),
                new SqlParameter("@denNgay",denNgay)
            };
            return DbContext.Database.SqlQuery<ThongKeDoanhThuViewModel>("GetThongKeDoanhThu @tuNgay,@denNgay", parameters);
            //throw new NotImplementedException();
        }
    }
}
