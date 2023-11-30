using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IBitacoraService
    {
        Task<IEnumerable<Bitacora>> GetAll();
        Task<Bitacora> GetById(int id);
        Task<bool> Create(string accion, DateTime date, int usuario);
        Task<bool> Update(Bitacora bitacora);
        Task<bool> Delete(int id);
    }
}
