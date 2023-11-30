using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
    public class FolioService : IFolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Create(Folio folio)
        {
            return _unitOfWork.FolioRepository.Create(folio);
        }

        public Task<bool> Delete(int id)
        {
            return _unitOfWork.FolioRepository.Delete(id);
        }

        public Task<IEnumerable<Folio>> GetAll()
        {
            return _unitOfWork.FolioRepository.GetAll();
        }

        public Task<Folio> GetbyAvaible(bool disponible)
        {
            return _unitOfWork.FolioRepository.GetByAvaible(disponible);
        }

        public Task<Folio> GetById(int id)
        {
            return _unitOfWork.FolioRepository.FindById(id);
        }

        public Task<bool> Update(Folio folio, bool disponible)
        {
            folio.disponible = disponible;
            return _unitOfWork.FolioRepository.Update(folio);
        }
    }
}
