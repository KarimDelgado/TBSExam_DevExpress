using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetAllPedidos();
        Task<Pedido?> GetSpecificPedido(int? id);
    }
}
