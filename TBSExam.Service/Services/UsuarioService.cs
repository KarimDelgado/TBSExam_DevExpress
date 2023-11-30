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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Create(Usuario usuario)
        {
            usuario.ultimoAcceso = DateTime.Now;
            usuario.numAcceso = 0;
            return _unitOfWork.UsuarioRepository.Create(usuario);
        }

        public Task<bool> Delete(int? id)
        {
            return _unitOfWork.UsuarioRepository.Delete(id);
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            return _unitOfWork.UsuarioRepository.GetAll();
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

        public Task<bool> Update(Usuario usuario)
        {
            return _unitOfWork.UsuarioRepository.Update(usuario);
        }
    }
}
