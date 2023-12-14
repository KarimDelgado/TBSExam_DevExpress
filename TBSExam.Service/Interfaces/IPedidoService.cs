using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<bool> Create(string values, string usuarioLogin);
        Task<bool> Update(int id, string values);
        Task<bool> Delete(int id);
    }
}
