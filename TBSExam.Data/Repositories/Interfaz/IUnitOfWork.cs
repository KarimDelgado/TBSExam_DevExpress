using System;
using System.Linq;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IUnitOfWork : IDisposable
    {
        IBitacoraRepository BitacoraRepository { get; }
        IFolioRepository FolioRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        Task Save();
    }
}
