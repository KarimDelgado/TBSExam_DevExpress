using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> Login(string username, string password);
    }
}
