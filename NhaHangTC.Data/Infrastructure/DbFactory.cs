using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NhaHangTCDbContext dbContext;

        public NhaHangTCDbContext Init()
        {
            return dbContext ?? (dbContext = new NhaHangTCDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
