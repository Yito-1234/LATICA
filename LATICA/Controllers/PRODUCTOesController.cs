using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LATICA.Models;

namespace LATICA.Controllers
{
    public class PRODUCTOesController : Controller
    {
        private BASEDATOS db = new BASEDATOS();

        // GET: PRODUCTOes
        public ActionResult Index()
        {
            return View(db.PRODUCTOS.ToList());
        }

        public ActionResult ConvertirImagen(int id)
        {
            var imagen = db.PRODUCTOS.Where(x => x.id == id).FirstOrDefault();
            return File(imagen.fotografia, "image/jpeg");

        }



        // GET: PRODUCTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUCTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom_producto,descripcion,cantidad")] PRODUCTO pRODUCTO, HttpPostedFileBase fotografia)
        {
            if (fotografia != null && fotografia.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryreader = new BinaryReader(fotografia.InputStream))
                {
                    imageData = binaryreader.ReadBytes(fotografia.ContentLength);

                }
                pRODUCTO.fotografia = imageData;
            }

            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUCTO);
        }





        // GET: PRODUCTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom_producto,descripcion,cantidad")] PRODUCTO pRODUCTO, HttpPostedFileBase fotografia)
        {
            if (fotografia != null && fotografia.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryreader = new BinaryReader(fotografia.InputStream))
                {
                    imageData = binaryreader.ReadBytes(fotografia.ContentLength);

                }
                pRODUCTO.fotografia = imageData;
            }


            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTO);
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
