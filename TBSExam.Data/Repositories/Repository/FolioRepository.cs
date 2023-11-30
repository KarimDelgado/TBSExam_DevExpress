﻿using Microsoft.EntityFrameworkCore;
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
    public class FolioRepository : GenericRepository<Folio>, IFolioRepository
    {
        public FolioRepository(ExamContextConnection examContextConnection) : base(examContextConnection)
        {
        }

        public async Task<Folio> GetByAvaible(bool disponible)
        {
            return await _examContextConnection.Folios.FirstAsync(f => f.disponible == disponible);
        }
    }
}