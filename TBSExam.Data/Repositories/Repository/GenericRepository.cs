﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;

namespace TBSExam.Data.Repositories.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ExamContextConnection _examContextConnection;
        public GenericRepository(ExamContextConnection examContextConnection)
        {
            _examContextConnection = examContextConnection;
        }
        public async Task<bool> Create(T entity)
        {
            await _examContextConnection.Set<T>().AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var entity = await _examContextConnection.Set<T>().FindAsync(id);
            _examContextConnection.Set<T>().Remove(entity);
            return true;
        }

        public async Task<T?> FindById(int? id)
        {
            return await _examContextConnection.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _examContextConnection.Set<T>().ToListAsync();
        }

        public Task<bool> Update(T entity)
        {
            _examContextConnection.Set<T>().Update(entity);
            return Task.FromResult(true);
        }
    }
}
