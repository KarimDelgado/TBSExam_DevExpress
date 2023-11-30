using System;
using System.Linq;

namespace TBSExam.Data.Repositories.Interfaz
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int? id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int? id);
    }
}
