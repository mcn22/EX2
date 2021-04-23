using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensamientos.Infrastructure.Repositorio.IRepositorio
{
    public interface IUnitOfWork : IDisposable
    {
        IPensamientoRepositorio Pensamientos { get; }

        void Guardar();
    }
}
