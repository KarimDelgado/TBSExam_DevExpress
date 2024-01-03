using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int? id);
        Task<bool> Create(string values, string usuarioLogin);
        Task<bool> Update(int? id, string values, string usuarioLogin);
        Task<bool> Delete(int? id, string usuarioLogin);
        Task<bool> LastLogin(Usuario usuario);
        Task<Usuario?> Login(string userName, string password);
        Task<List<Pedido>> ListMDAsync(int id);
        Task<IEnumerable<Usuario>> ListUsuarioMD();
    }
}
