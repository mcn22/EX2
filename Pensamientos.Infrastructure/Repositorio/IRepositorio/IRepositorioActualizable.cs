using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtsWall.Domain;
using ThoughtsWall.Domain.Models;

namespace ThoughtsWall.Infrastructure.Repositorio.IRepositorio
{
    public interface IRepositorioActualizable<T> : IRepositorio<T>
        where T : class
    {
        void Actualizar(T entidad);
    }
}
