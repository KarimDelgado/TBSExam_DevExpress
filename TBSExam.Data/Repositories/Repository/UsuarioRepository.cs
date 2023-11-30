using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Usuario> Login(string username, string password)
        {
            return await _examContextConnection.Usuarios.SingleOrDefaultAsync(c => c.nombreUsuario == username && c.usuPwd == password);
        }
    }
}
