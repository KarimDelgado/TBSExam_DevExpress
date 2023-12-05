using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IFolioService
    {
        Task<IEnumerable<Folio>> GetAll();
        Task<Folio> GetById(int id);
        Task<bool> Create(string folioInicial, string folioFinal);
        Task<bool> Update(Folio folio, bool disponible);
        Task<bool> Delete(int id);
        Task<Folio> GetbyAvaible(bool disponible);
    }
}
