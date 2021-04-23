using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pensamientos.Domain;
using Pensamientos.Domain.Models;
using Pensamientos.Infrastructure.Data;
using Pensamientos.Infrastructure.Repositorio.IRepositorio;

namespace Pensamientos.Infrastructure.Repositorio
{
    public class PensamientoRepositorio : Repositorio<Pensamiento>, IPensamientoRepositorio
    {
    }
}