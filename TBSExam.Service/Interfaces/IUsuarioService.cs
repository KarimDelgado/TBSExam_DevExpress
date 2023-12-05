using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int? id);
        Task<bool> Create(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(int? id);
        Task<bool> LastLogin(Usuario usuario);
        Task<Usuario> Login(string userName, string password);
    }
}
