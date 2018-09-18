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
    public interface IHoaDonRepository : IRepository<HoaDon>
    {
        IEnumerable<ThongKeDoanhThuViewModel> GetThongKeDoanhThu(string tuNgay, string denNgay);
    }
    public class HoaDonRepository: RepositoryBase<HoaDon>, IHoaDonRepository
    {
        public HoaDonRepository(IDbFactory dbFactory) : base(dbFactory)
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
