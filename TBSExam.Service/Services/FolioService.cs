using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Business.Scripts;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
    public class FolioService : IFolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GenerarFolios _generarFolios;
        public FolioService(IUnitOfWork unitOfWork, GenerarFolios generarFolios)
        {
            _unitOfWork = unitOfWork;
            _generarFolios = generarFolios;
        }
        public Task<bool> Create(string folioInicial, string folioFinal)
        {
            var folios = _generarFolios.GeneradordeFolios(folioInicial, folioFinal);
            return _unitOfWork.FolioRepository.CreateByList(folios);
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
