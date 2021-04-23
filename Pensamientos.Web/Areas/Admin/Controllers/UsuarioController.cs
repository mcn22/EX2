using Pensamientos.Infrastructure.Data;
using Pensamientos.Infrastructure.Repositorio;
using Pensamientos.Infrastructure.Repositorio.IRepositorio;
using Pensamientos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pensamientos.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Pensamientos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Administrador)]
    public class UsuarioController : Controller
    {
        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public IActionResult Index()
        {
            return View();
        }

        #region Api Methods

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
        }

        [HttpGet]
        public IActionResult Listar()
        {
        }

        #endregion
    }
}
