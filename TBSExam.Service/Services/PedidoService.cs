using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PedidoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Create(Pedido pedido)
        {
            return _unitOfWork.PedidoRepository.Create(pedido);
        }

        public Task<bool> Delete(int id)
        {
            return _unitOfWork.PedidoRepository.Delete(id);
        }

        public Task<IEnumerable<Pedido>> GetAll()
        {
            return _unitOfWork.PedidoRepository.GetAllPedidos();
        }

        public Task<Pedido> GetById(int id)
        {
            return _unitOfWork.PedidoRepository.GetSpecificPedido(id);
        }

        public Task<bool> Update(Pedido pedido)
        {
            return _unitOfWork.PedidoRepository.Update(pedido);
        }
    }
}
