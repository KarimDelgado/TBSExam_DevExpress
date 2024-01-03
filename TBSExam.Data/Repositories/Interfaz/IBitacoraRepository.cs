using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IBitacoraRepository : IGenericRepository<Bitacora>
    {
        Task<IEnumerable<Bitacora>> GetAllBitacoras();
        Task<Bitacora?> GetSpecificBitacora(int? id);
    }
}
