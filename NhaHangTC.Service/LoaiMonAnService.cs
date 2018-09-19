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
    public interface ILoaiMonAnService
    {
        LoaiMonAn Add(LoaiMonAn LoaiMonAn);

        void Update(LoaiMonAn LoaiMonAn);

        LoaiMonAn Delete(int id);

        IEnumerable<LoaiMonAn> GetAll();

        IEnumerable<LoaiMonAn> GetAll(string keyword);

        IEnumerable<LoaiMonAn> GetAllByParentId(int parentId);

        LoaiMonAn GetById(int id);

        void Save();
    }

    public class LoaiMonAnService : ILoaiMonAnService
    {
        private ILoaiMonAnRepository _LoaiMonAnRepository;
        private IUnitOfWork _unitOfWork;
        public LoaiMonAnService(ILoaiMonAnRepository LoaiMonAnRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiMonAnRepository = LoaiMonAnRepository;
            this._unitOfWork = unitOfWork;
        }
        public LoaiMonAn Add(LoaiMonAn LoaiMonAn)
        {
            return _LoaiMonAnRepository.Add(LoaiMonAn);
   
        }

        public LoaiMonAn Delete(int id)
        {
            return _LoaiMonAnRepository.Delete(id);
        }

        public IEnumerable<LoaiMonAn> GetAll()
        {
            return _LoaiMonAnRepository.GetAll();
        }

        public IEnumerable<LoaiMonAn> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _LoaiMonAnRepository.GetMulti(x => x.TENLOAI.Contains(keyword));
            else
                return _LoaiMonAnRepository.GetAll();

        }

        public IEnumerable<LoaiMonAn> GetAllByParentId(int parentId)
        {
            return _LoaiMonAnRepository.GetMulti(x => x.MALOAI == parentId);
        }

        public LoaiMonAn GetById(int id)
        {
            return _LoaiMonAnRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiMonAn LoaiMonAn)
        {
            _LoaiMonAnRepository.Update(LoaiMonAn);
        }
    }
}
