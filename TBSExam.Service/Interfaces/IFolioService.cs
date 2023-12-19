using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
	public interface IFolioService
	{
		Task<IEnumerable<Folio>> GetAll();
		Task<Folio> GetById(string? id);
		Task<bool> Create(string folioInicial, string folioFinal);
		Task<bool> Update(Folio folio, bool disponible);
		Task<bool> Delete(int id);
		Folio GetbyAvaible(bool disponible);
	}
}
