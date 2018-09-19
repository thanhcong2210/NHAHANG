using NhaHangTC.Data.Infrastructure;
using NhaHangTC.Data.Repositories;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHangTC.Service
{
    public interface IMonAnService
    {
        MonAn Add(MonAn MonAn);

        void Update(MonAn MonAn);

        MonAn Delete(int id);

        IEnumerable<MonAn> GetAll();

        IEnumerable<MonAn> GetAll(string keyword);

        //IEnumerable<MonAn> GetLastest(int top);

        IEnumerable<MonAn> GetHotProduct(int top);

        IEnumerable<MonAn> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<MonAn> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        //IEnumerable<MonAn> GetReatedProducts(int id, int top);
        IEnumerable<MonAn> GetListMonAn(string keyword);

        IEnumerable<string> GetListProductByName(string name);

        MonAn GetById(int id);

        void Save();

        //IEnumerable<Tag> GetListTagByProductId(int id);

        //Tag GetTag(string tagId);

        //void IncreaseView(int id);

        //IEnumerable<Product> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);

        //bool SellProduct(int productId, int quantity);
    }

    public class MonAnService : IMonAnService
    {

        private IMonAnRepository _monAnRepository;
        //private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;
        public MonAnService(IMonAnRepository monAnRepository
             , IUnitOfWork unitOfWork)
        {
            this._monAnRepository = monAnRepository;
            this._unitOfWork = unitOfWork;
        }

        public MonAn Add(MonAn MonAn)
        {
            var monan = _monAnRepository.Add(MonAn);
            _unitOfWork.Commit();
            return monan;

        }

        public MonAn Delete(int id)
        {
            return _monAnRepository.Delete(id);
        }

        public IEnumerable<MonAn> GetAll()
        {
            return _monAnRepository.GetAll();
        }

        public IEnumerable<MonAn> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _monAnRepository.GetMulti(x => x.TENGOI.Contains(keyword) || x.MOTA.Contains(keyword));
            else
                return _monAnRepository.GetAll();
        }

        public MonAn GetById(int id)
        {
            return _monAnRepository.GetSingleById(id);
        }

        public IEnumerable<MonAn> GetHotProduct(int top)
        {
            return _monAnRepository.GetMulti(x => x.MAMON > 0).OrderByDescending(x => x.NGAYTAOMOI).Take(top);
        }

        public IEnumerable<MonAn> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _monAnRepository.GetMulti(x => x.MALOAI == categoryId);

            switch (sort)
            {
                case "khaivi":
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
                case "monchinh":
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
                case "trangmieng":
                    query = query.OrderBy(x => x.NGAYTAOMOI);
                    break;
                default:
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _monAnRepository.GetMulti(x => x.TENGOI.Contains(name)).Select(y => y.TENGOI);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<MonAn> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _monAnRepository.GetMulti(x => x.TENGOI.Contains(keyword));

            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
                case "discount":
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
                case "price":
                    query = query.OrderBy(x => x.DONGIA);
                    break;
                default:
                    query = query.OrderByDescending(x => x.NGAYTAOMOI);
                    break;
            }

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
            //throw new NotImplementedException();
        }

        public void Update(MonAn MonAn)
        {
            _monAnRepository.Update(MonAn);
        }
        public IEnumerable<MonAn> GetListMonAn(string keyword)
        {
            IEnumerable<MonAn> query;
            if (!string.IsNullOrEmpty(keyword))
                query = _monAnRepository.GetMulti(x => x.TENGOI.Contains(keyword));
            else
                query = _monAnRepository.GetAll();
            return query;
        }
    }
}
