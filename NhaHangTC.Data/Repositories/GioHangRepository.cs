using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Model.Models;
using NhaHangTC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NhaHangTC.Data.Repositories
{
    public interface IGioHangRepository : IRepository<GioHang>
    {
        IEnumerable<ThongKeDoanhThuViewModel> GetThongKeDoanhThu(string tuNgay, string denNgay);
    }
    public class GioHangRepository : RepositoryBase<GioHang>, IGioHangRepository
    {
        public GioHangRepository(IDbFactory dbFactory) : base(dbFactory)
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
