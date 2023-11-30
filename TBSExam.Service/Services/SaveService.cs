using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Service.Interfaces;

namespace TBSExam.Service.Services
{
    public class SaveService : ISaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Save()
        {
            await _unitOfWork.Save();
        }
    }
}
