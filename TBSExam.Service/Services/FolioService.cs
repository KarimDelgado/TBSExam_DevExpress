using System;
using System.Linq;
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
			var createFolios = _unitOfWork.FolioRepository.CreateByList(folios);
			_unitOfWork.Save();
			return createFolios;
		}

		public Task<bool> Delete(int id)
		{
			return _unitOfWork.FolioRepository.Delete(id);
		}

		public Task<IEnumerable<Folio>> GetAll()
		{
			return _unitOfWork.FolioRepository.GetAll();
		}

		public Folio GetbyAvaible(bool disponible)
		{
			return _unitOfWork.FolioRepository.GetByAvaible(disponible);
		}

		public Task<Folio?> GetById(string? id)
		{
			return _unitOfWork.FolioRepository.GetByFolio(id);
		}

		public Task<bool> Update(Folio folio, bool disponible)
		{
			folio.disponible = disponible;
			return _unitOfWork.FolioRepository.Update(folio);
		}
	}
}
