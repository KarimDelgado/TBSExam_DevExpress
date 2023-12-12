using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IFolioRepository : IGenericRepository<Folio>
    {
        Task<Folio> GetByAvaible(bool disponible);
        Task<Folio> GetByFolio(string? id);
        Task<bool> CreateByList(List<Folio> folios);
    }
}
