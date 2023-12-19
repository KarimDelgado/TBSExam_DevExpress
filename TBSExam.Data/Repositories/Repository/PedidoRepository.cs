using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ExamContextConnection examContextConnection) : base(examContextConnection)
        {
        }

        public async Task<IEnumerable<Pedido>> GetAllPedidos()
        {
            return await _examContextConnection.Pedidos.Include(p => p.usuario).Include(p => p.folio).ToListAsync();
        }

        public async Task<Pedido> GetSpecificPedido(int? id)
        {
            return await _examContextConnection.Pedidos.Include(p => p.usuario).Include(p => p.folio).FirstOrDefaultAsync(p => p.pedido_id == id);
        }
    }
}
