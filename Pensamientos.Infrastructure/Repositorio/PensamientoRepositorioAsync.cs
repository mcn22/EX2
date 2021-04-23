using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtsWall.Domain;
using ThoughtsWall.Domain.Models;
using ThoughtsWall.Infrastructure.Data;
using ThoughtsWall.Infrastructure.Repositorio.IRepositorio;

namespace ThoughtsWall.Infrastructure.Repositorio
{
    public class PensamientoRepositorioAsync : PensamientoRepositorio, IPensamientoRepositorio
    {
        public PensamientoRepositorioAsync(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public async Task ActualizarAsync(Pensamiento pensamiento)
        {
            await Task.Run(() => Actualizar(pensamiento));
        }
    }
}