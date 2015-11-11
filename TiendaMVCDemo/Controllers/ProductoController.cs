using System;
using System.Web.Mvc;
using TiendaMVCDemo.Models;

namespace TiendaMVCDemo.Controllers
{
    public class ProductoController : Controller , IDisposable
    {
        readonly Tienda05Entities _db = new Tienda05Entities();

        public ActionResult Index()
        {
            var data = _db.Producto;

            return View(data);
        }

        public ActionResult Detalle(int id)
        {
            var data = _db.Producto.Find(id);
            return View(data);
        }

        // GET: Producto
        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid)
            {
                _db.Producto.Add(model);
                _db.SaveChanges();
                return View(new Producto());
            }
            return View(model);
        }

        void IDisposable.Dispose() 
        {
            _db?.Dispose();
        }
    }
}