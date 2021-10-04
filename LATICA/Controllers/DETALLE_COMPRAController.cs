using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LATICA.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LATICA.Controllers
{
    public class DETALLE_COMPRAController : Controller
    {
        private BASEDATOS db = new BASEDATOS();

        // GET: DETALLE_COMPRA
        public ActionResult Index()
        {
            var dETALLE_COMPRA = db.DETALLE_COMPRA.Include(d => d.PRODUCTO);
            return View(dETALLE_COMPRA.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Borrar()
        {
            try
            {
                await db.DETALLE_COMPRA.ForEachAsync(x => { db.DETALLE_COMPRA.Remove(x); });
                await db.SaveChangesAsync();
                return Json(new { result="Ok" });
            }
            catch (Exception ex)
            {

                return Json(new { result = ex.Message });
            }
        }




        // GET: DETALLE_COMPRA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.PRODUCTOS, "id", "nom_producto");
            return View();
        }

        // POST: DETALLE_COMPRA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fecha,id_producto,cantidad")] DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_COMPRA.Add(dETALLE_COMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.PRODUCTOS, "id", "nom_producto", dETALLE_COMPRA.id_producto);
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.PRODUCTOS, "id", "nom_producto", dETALLE_COMPRA.id_producto);
            return View(dETALLE_COMPRA);
        }

        // POST: DETALLE_COMPRA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fecha,id_producto,cantidad")] DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_COMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.PRODUCTOS, "id", "nom_producto", dETALLE_COMPRA.id_producto);
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_COMPRA);
        }

        // POST: DETALLE_COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            db.DETALLE_COMPRA.Remove(dETALLE_COMPRA);
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
