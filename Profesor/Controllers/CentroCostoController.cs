using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Profesor.Models;

namespace Profesor.Controllers
{
    public class CentroCostoController : Controller
    {
        private ConexionContext db = new ConexionContext();

        // GET: CentroCosto
        public async Task<ActionResult> Index()
        {
            return View(await db.bdc_centroCosto.ToListAsync());
        }

        // GET: CentroCosto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_centroCosto bdc_centroCosto = await db.bdc_centroCosto.FindAsync(id);
            if (bdc_centroCosto == null)
            {
                return HttpNotFound();
            }
            return View(bdc_centroCosto);
        }

        // GET: CentroCosto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroCosto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,centroCosto")] bdc_centroCosto bdc_centroCosto)
        {
            if (ModelState.IsValid)
            {
                db.bdc_centroCosto.Add(bdc_centroCosto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bdc_centroCosto);
        }

        // GET: CentroCosto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_centroCosto bdc_centroCosto = await db.bdc_centroCosto.FindAsync(id);
            if (bdc_centroCosto == null)
            {
                return HttpNotFound();
            }
            return View(bdc_centroCosto);
        }

        // POST: CentroCosto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,centroCosto")] bdc_centroCosto bdc_centroCosto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdc_centroCosto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bdc_centroCosto);
        }

        // GET: CentroCosto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_centroCosto bdc_centroCosto = await db.bdc_centroCosto.FindAsync(id);
            if (bdc_centroCosto == null)
            {
                return HttpNotFound();
            }
            return View(bdc_centroCosto);
        }

        // POST: CentroCosto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bdc_centroCosto bdc_centroCosto = await db.bdc_centroCosto.FindAsync(id);
            db.bdc_centroCosto.Remove(bdc_centroCosto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Agregar([Bind(Include = "ID,centroCosto")] bdc_centroCosto bdc_centroCosto)  ///BIND especifica que propiedades de un modelo se debe incluir en el enlace de modelo
        {
            if (ModelState.IsValid)
            {
                db.bdc_centroCosto.Add(bdc_centroCosto);
                await db.SaveChangesAsync();
                return RedirectToAction("Agregar");
            }

            return View(bdc_centroCosto);
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
