using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<bool> Create(Pedido pedido);
        Task<bool> Update(Pedido pedido);
        Task<bool> Delete(int id);
    }
}
