using Newtonsoft.Json;
using System;
using System.Linq;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UsuarioService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> Create(string values, string usuarioLogin)
		{
			var newUsuario = new Usuario
			{
				ultimoAcceso = DateTime.Now,
				numAcceso = 0
			};
			JsonConvert.PopulateObject(values, newUsuario);
			var create = await _unitOfWork.UsuarioRepository.Create(newUsuario);
			var newBitacora = new Bitacora
			{
				accion = "Crear",
				usuario_id = int.Parse(usuarioLogin),
				shipment_date = DateTime.Now
			};
			await _unitOfWork.BitacoraRepository.Create(newBitacora);
			await _unitOfWork.Save();
			return create;
		}

		public async Task<bool> Delete(int? id, string usuarioLogin)
		{
			var usuario = await _unitOfWork.UsuarioRepository.FindById(id);
			if (usuario == null)
				return false;
			var delete = await _unitOfWork.UsuarioRepository.Delete(id);
			var newBitacora = new Bitacora
			{
				accion = "Eliminar",
				usuario_id = int.Parse(usuarioLogin),
				shipment_date = DateTime.Now
			};
			await _unitOfWork.BitacoraRepository.Create(newBitacora);
			await _unitOfWork.Save();
			return delete;
		}

		public async Task<bool> Update(int? id, string values, string usuarioLogin)
		{
			var usuario = await _unitOfWork.UsuarioRepository.FindById(id);
			if (usuario == null)
				return false;
			JsonConvert.PopulateObject(values, usuario);
			var newBitacora = new Bitacora
			{
				accion = "Editar",
				usuario_id = int.Parse(usuarioLogin),
				shipment_date = DateTime.Now
			};
			await _unitOfWork.BitacoraRepository.Create(newBitacora);
			await _unitOfWork.Save();
			return true;
		}

		public async Task<IEnumerable<Usuario>> GetAll()
		{
			var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
			return usuarios;
		}

		public Task<Usuario?> GetById(int? id)
		{
			return _unitOfWork.UsuarioRepository.FindById(id);
		}

		public async Task<bool> LastLogin(Usuario usuario)
		{
			usuario.numAcceso += 1;
			usuario.ultimoAcceso = DateTime.Now;
			var update = _unitOfWork.UsuarioRepository.Update(usuario);
			await _unitOfWork.Save();
			return true;
		}

		public async Task<Usuario?> Login(string userName, string password)
		{
			var usuario = _unitOfWork.UsuarioRepository.Login(userName, password);
			usuario.numAcceso += 1;
			usuario.ultimoAcceso = DateTime.Now;
			await _unitOfWork.Save();
			return usuario;
		}

        public async Task<List<Pedido>> ListMDAsync(int id)
        {
			var pedidosUsuario = await _unitOfWork.UsuarioRepository.ListMDAsync(id);
			return pedidosUsuario;
        }

        public async Task<IEnumerable<Usuario>> ListUsuarioMD()
        {
            return await _unitOfWork.UsuarioRepository.ListUsuarioMD();
        }
    }
}
