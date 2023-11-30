using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;

namespace TBSExam.Data.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamContextConnection _examContextConnection;
        public UnitOfWork(ExamContextConnection examContextConnection)
        {
            _examContextConnection = examContextConnection;
            BitacoraRepository = new BitacoraRepository(_examContextConnection);
            FolioRepository = new FolioRepository(_examContextConnection);
            PedidoRepository = new PedidoRepository(_examContextConnection);
            UsuarioRepository = new UsuarioRepository(_examContextConnection);
        }

        public IBitacoraRepository BitacoraRepository { get; private set; }
        public IFolioRepository FolioRepository { get; private set;}
        public IPedidoRepository PedidoRepository { get; private set;}
        public IUsuarioRepository UsuarioRepository { get; private set;}

        public async Task Save()
        {
            await _examContextConnection.SaveChangesAsync();
        }

        public void Dispose()
        {
            _examContextConnection.Dispose();
        }

        
    }
}
