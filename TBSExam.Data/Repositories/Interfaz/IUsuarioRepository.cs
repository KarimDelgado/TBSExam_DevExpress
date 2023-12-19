using System;
using System.Linq;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> Login(string username, string password);
        Task<IEnumerable<Usuario>> ListMD(int id);
    }
}
