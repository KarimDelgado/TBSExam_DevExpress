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
			var usuarios = await _unitOfWork.UsuarioRepository.GetAll(); // <-----
			return usuarios;
		}

		public Task<Usuario> GetById(int? id)
		{
			return _unitOfWork.UsuarioRepository.FindById(id);
		}

		public Task<bool> LastLogin(Usuario usuario)
		{
			usuario.numAcceso += 1;
			usuario.ultimoAcceso = DateTime.Now;
			return _unitOfWork.UsuarioRepository.Update(usuario);
		}

		public Task<Usuario> Login(string userName, string password)
		{
			return _unitOfWork.UsuarioRepository.Login(userName, password);
		}

        public Task<IEnumerable<Usuario>> ListMD(int id)
        {
			return _unitOfWork.UsuarioRepository.ListMD(id);
        }
    }
}
