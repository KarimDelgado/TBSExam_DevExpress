using Azure;
using Newtonsoft.Json;
using System;
using System.Linq;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
	public class PedidoService : IPedidoService
	{
		private readonly IUnitOfWork _unitOfWork;
		private static readonly object _locker = new object();
		public PedidoService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> Create(string values, string usuarioLogin)
		{
			Folio folioDisponible;
			lock (_locker)
			{
                folioDisponible =  _unitOfWork.FolioRepository.GetByAvaible(true);
                folioDisponible.disponible = false;
				_unitOfWork.SaveFolio();
            }
            var newPedido = new Pedido
            {
                folio_id = folioDisponible.folio_id,
                usuario_id = int.Parse(usuarioLogin)
            };
            JsonConvert.PopulateObject(values, newPedido);
            var create = await _unitOfWork.PedidoRepository.Create(newPedido);
            await _unitOfWork.Save();
            return create;
        }

		public async Task<bool> Delete(int id)
		{
			var pedido = await _unitOfWork.PedidoRepository.FindById(id);
			if (pedido == null)
				return false;
			var folio = await _unitOfWork.FolioRepository.GetByFolio(pedido.folio_id);
			folio.disponible = true;
			await _unitOfWork.FolioRepository.Update(folio);
			var eliminar = await _unitOfWork.PedidoRepository.Delete(id);
			await _unitOfWork.Save();
			return eliminar;
		}

		public Task<IEnumerable<Pedido>> GetAll()
		{
			return _unitOfWork.PedidoRepository.GetAllPedidos();
		}

		public Task<Pedido> GetById(int id)
		{
			return _unitOfWork.PedidoRepository.GetSpecificPedido(id);
		}

		public async Task<bool> Update(int id, string values)
		{
			var pedido = await _unitOfWork.PedidoRepository.FindById(id);
			if (pedido == null)
				return false;
			JsonConvert.PopulateObject(values, pedido);
			await _unitOfWork.Save();
			return true;
		}
	}
}
