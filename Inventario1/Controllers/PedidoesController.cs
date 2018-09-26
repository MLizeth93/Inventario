using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario1.Models;

namespace Inventario1.Controllers
{
    public class PedidoesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Cliente).Include(p => p.Proveedor);
            return View(pedido.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.id_Cliente = new SelectList(db.Cliente, "id_cliente", "nombre");
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "id_proveedor", "nombre");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pedido,fecha_pedido,fecha_envio,estado_pedido,id_Cliente,id_Proveedor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Cliente = new SelectList(db.Cliente, "id_cliente", "nombre", pedido.id_Cliente);
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "id_proveedor", "nombre", pedido.id_Proveedor);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Cliente = new SelectList(db.Cliente, "id_cliente", "nombre", pedido.id_Cliente);
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "id_proveedor", "nombre", pedido.id_Proveedor);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pedido,fecha_pedido,fecha_envio,estado_pedido,id_Cliente,id_Proveedor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Cliente = new SelectList(db.Cliente, "id_cliente", "nombre", pedido.id_Cliente);
            ViewBag.id_Proveedor = new SelectList(db.Proveedor, "id_proveedor", "nombre", pedido.id_Proveedor);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
