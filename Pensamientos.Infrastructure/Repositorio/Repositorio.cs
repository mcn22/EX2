using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pensamientos.Infrastructure.Data;
using Pensamientos.Infrastructure.Repositorio.IRepositorio;

namespace Pensamientos.Infrastructure.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
    }
}
