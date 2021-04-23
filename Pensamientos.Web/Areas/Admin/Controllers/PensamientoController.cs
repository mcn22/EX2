using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pensamientos.Domain;
using Pensamientos.Domain.Models;
using Pensamientos.Domain.Models.ViewModels;
using Pensamientos.Infrastructure.Repositorio.Extension;
using Pensamientos.Infrastructure.Repositorio.IRepositorio;
using Pensamientos.Shared;

namespace Pensamientos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Administrador + "," + SD.Roles.Facebook)]
    public class PensamientoController : Controller
    {
        public PensamientoController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        readonly IUnitOfWork _unitOfWork;
        readonly UserManager<IdentityUser> _userManager;
        readonly IWebHostEnvironment _webHostEnvironment;

        [HttpGet]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            bool currentUser = !User.IsInRole(SD.Roles.Administrador);

            PensamientosViewModel modelo = new PensamientosViewModel
            {
            };

            modelo.Paginador = new Paginador
            {
                Url = "/admin/pensamiento/index?pagina=:"
            };

            return View(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int id = 0)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Pensamiento pensamiento)
        {
            var identityUser = await _userManager.GetUserAsync(User);
            pensamiento.Fecha = DateTime.Now;
            pensamiento.Autor = ((Usuario)identityUser).NombreCompleto;

            if (ModelState.IsValid)
            {
                if (pensamiento.Id == 0)
                {
                    await _unitOfWork.Pensamientos.AgregarAsync(pensamiento);
                }
                else
                {
                    await _unitOfWork.Pensamientos.ActualizarAsync(pensamiento);
                }

                await _unitOfWork.GuardarAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(pensamiento);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int id)
        {
        }
    }
}
