using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NhaHangTCDbContext Init();
    }
}
