using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Pensamientos.Domain;
using Pensamientos.Domain.Models;
using Pensamientos.Domain.Models.ViewModels;
using Pensamientos.Infrastructure.Repositorio.Extension;
using Pensamientos.Infrastructure.Repositorio.IRepositorio;
using Pensamientos.Shared;

namespace Pensamientos.Web.Areas.Comun.Controllers
{
    [Area("Comun")]
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        readonly ILogger<HomeController> _logger;
        readonly IUnitOfWork _unitOfWork;

        public async Task<IActionResult> Index(int pagina = 1)
        {
            PensamientosViewModel modelo = new PensamientosViewModel
            {
                Pensamientos =
                    await _unitOfWork.Pensamientos.ListarAsync
                        (s => s.Fecha.Date >= DateTime.Now.Date.AddDays(-1))
            };

            modelo.Pensamientos = modelo.Pensamientos.DistinctBy(s => s.Autor);

            var total = modelo.Pensamientos.Count();
            modelo.Pensamientos =
                    modelo.Pensamientos
                        .OrderBy(o => o.Fecha)
                        .Skip((pagina - 1) * 2)
                        .Take(2).ToList();
            modelo.Paginador = new Paginador
            {
                PaginaActual = pagina,
                RegistrosPagina = 2,
                TotalRegistros = total,
                Url = "/comun/home/index?pagina=:"
            };

            return View(modelo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
