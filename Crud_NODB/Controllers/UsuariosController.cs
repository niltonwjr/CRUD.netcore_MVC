using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crud_NODB.DAO;
using Crud_NODB.Models;

namespace Crud_NODB.Controllers
{
	public class UsuariosController : Controller
	{
        private readonly IUsuarioDAO _usuarios;
        public UsuariosController(IUsuarioDAO usuarios)
        {
            _usuarios = usuarios;
        }
        public IActionResult Index()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = _usuarios.GetAll().ToList();
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
          
            Usuario Usuario = _usuarios.GetByID(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarios.Add(Usuario);
                return RedirectToAction("Index");
            }
            return View(Usuario);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Usuario Usuario = _usuarios.GetByID(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Usuario Usuario)
        {           
            if (ModelState.IsValid)
            {
                _usuarios.Update(id, Usuario);
                return RedirectToAction("Index");
            }
            return View(Usuario);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {           
            Usuario Usuario = _usuarios.GetByID(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _usuarios.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
