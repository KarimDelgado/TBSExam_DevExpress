using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario? Login(string username, string password);
        Task<List<Pedido>> ListMDAsync(int id);
        Task<IEnumerable<Usuario>> ListUsuarioMD();
    }
}
