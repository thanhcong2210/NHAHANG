using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Đánh dấu một thực thể là mới
        T Add(T entity);

        // Đánh dấu một thực thể là đã sửa đổi
        void Update(T entity);

        // Đánh dấu một thực thể cần xóa
        T Delete(T entity);

        T Delete(int id);

        //Xóa nhiều bản ghi
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Nhận thực thể theo id int
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
