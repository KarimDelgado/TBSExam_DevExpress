using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSExam.Models.Models;

namespace TBSExam.Data.ExamContext
{
    public class ExamContextConnection : DbContext
    {
        public ExamContextConnection()
        {
            
        }

        public ExamContextConnection(DbContextOptions<ExamContextConnection> options) : base(options) { }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Folio> Folios { get; set;}
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("SQLConnection=app.db");
    }
}
