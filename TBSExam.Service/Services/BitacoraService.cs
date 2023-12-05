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
    public class BitacoraService : IBitacoraService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BitacoraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Create(string accion, string usuario)
        {
            var registro = new Bitacora
            {
                accion = accion,
                shipment_date = DateTime.Now,
                usuario_id = int.Parse(usuario)
            };
            return _unitOfWork.BitacoraRepository.Create(registro);
        }

        public Task<bool> Delete(int id)
        {
            return _unitOfWork.BitacoraRepository.Delete(id);
        }

        public Task<IEnumerable<Bitacora>> GetAll()
        {
            return _unitOfWork.BitacoraRepository.GetAllBitacoras();
        }

        public Task<Bitacora> GetById(int id)
        {
            return _unitOfWork.BitacoraRepository.GetSpecificBitacora(id);
        }

        public Task<bool> Update(Bitacora bitacora)
        {
            return _unitOfWork.BitacoraRepository.Update(bitacora);
        }
    }
}
