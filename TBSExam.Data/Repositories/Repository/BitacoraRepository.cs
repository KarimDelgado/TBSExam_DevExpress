using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Repository
{
    public class BitacoraRepository : GenericRepository<Bitacora>, IBitacoraRepository
    {
        public BitacoraRepository(ExamContextConnection examContextConnection) : base(examContextConnection)
        {
        }

        public async Task<IEnumerable<Bitacora>> GetAllBitacoras()
        {
            return await _examContextConnection.Bitacoras.Include(p => p.usuario).ToListAsync();
        }

        public Task<Bitacora?> GetSpecificBitacora(int? id)
        {
            return _examContextConnection.Bitacoras.Include(p => p.usuario).FirstOrDefaultAsync(p => p.shipment_id == id);
        }
    }
}
