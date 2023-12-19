using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;

namespace TBSExam.Data.Repositories.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ExamContextConnection examContextConnection) : base(examContextConnection)
        {
        }

        public async Task<IEnumerable<Usuario>> ListMD(int id)
        {
            return (IEnumerable<Usuario>)await _examContextConnection.Usuarios.Where(e => e.usuario_id == id).Select(e => e.pedido).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Login(string username, string password)
        {
            return await _examContextConnection.Usuarios.SingleOrDefaultAsync(c => c.nombreUsuario == username && c.usuPwd == password);
        }
    }
}
