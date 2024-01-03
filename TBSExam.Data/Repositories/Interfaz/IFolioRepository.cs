using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
	public interface IFolioRepository : IGenericRepository<Folio>
	{
		Folio GetByAvaible(bool disponible);
		Task<Folio?> GetByFolio(string? id);
		Task<bool> CreateByList(List<Folio> folios);
    }
}
