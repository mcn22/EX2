using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtsWall.Domain;
using ThoughtsWall.Domain.Models;

namespace ThoughtsWall.Infrastructure.Repositorio.IRepositorio
{
    public interface IIUnitOfWorkAsync : IUnitOfWork
    {
        Task GuardarAsync(Pensamiento pensamiento);
    }
}
