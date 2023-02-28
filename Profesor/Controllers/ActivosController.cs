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
    public class ActivosController : Controller
    {
        private ConexionContext db = new ConexionContext();

        // GET: Activos
        public async Task<ActionResult> Index()
        {
            var bdc_infoActivo = db.bdc_infoActivo.Include(b => b.bdc_area).Include(b => b.bdc_centroCosto).Include(b => b.bdc_clase).Include(b => b.bdc_cuenta_activo).Include(b => b.bdc_cuenta_pasivo).Include(b => b.bdc_nom_cuenta_activo).Include(b => b.bdc_nom_cuenta_pasivo).Include(b => b.bdc_subclase);
            return View(await bdc_infoActivo.ToListAsync());
        }

        // GET: Activos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_infoActivo bdc_infoActivo = await db.bdc_infoActivo.FindAsync(id);
            if (bdc_infoActivo == null)
            {
                return HttpNotFound();
            }
            return View(bdc_infoActivo);
        }

        // GET: Activos/Create
        public ActionResult Create()
        {
            ViewBag.fk_area = new SelectList(db.bdc_area, "ID", "fk_area");
            ViewBag.fk_centroCosto = new SelectList(db.bdc_centroCosto, "ID", "centroCosto");
            ViewBag.fk_clase = new SelectList(db.bdc_clase, "ID", "clase");
            ViewBag.fk_cuenta_activo = new SelectList(db.bdc_cuenta_activo, "ID", "cuenta_activo");
            ViewBag.fk_cuenta_pasivo = new SelectList(db.bdc_cuenta_pasivo, "ID", "cuenta_pasivo");
            ViewBag.fk_nom_cuenta_activo = new SelectList(db.bdc_nom_cuenta_activo, "ID", "nom_cuenta_activo");
            ViewBag.fk_nom_cuenta_pasivo = new SelectList(db.bdc_nom_cuenta_pasivo, "ID", "nom_cuenta_pasivo");
            ViewBag.fk_subclase = new SelectList(db.bdc_subclase, "ID", "subclase");
            return View();
        }

        // POST: Activos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,fk_centroCosto,fk_area,fk_cuenta_activo,fk_nom_cuenta_activo,fk_cuenta_pasivo,fk_nom_cuenta_pasivo,fk_clase,fk_subclase,denominacion,subdenominacion,descripcion,marca,modelo,num_serie,ubicación,cod_barras,estado,fk_traspaso,fk_financiamiento,fech_compra,n_factura,obs_general")] bdc_infoActivo bdc_infoActivo)
        {
            if (ModelState.IsValid)
            {
                db.bdc_infoActivo.Add(bdc_infoActivo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.fk_area = new SelectList(db.bdc_area, "ID", "fk_area", bdc_infoActivo.fk_area);
            ViewBag.fk_centroCosto = new SelectList(db.bdc_centroCosto, "ID", "centroCosto", bdc_infoActivo.fk_centroCosto);
            ViewBag.fk_clase = new SelectList(db.bdc_clase, "ID", "clase", bdc_infoActivo.fk_clase);
            ViewBag.fk_cuenta_activo = new SelectList(db.bdc_cuenta_activo, "ID", "cuenta_activo", bdc_infoActivo.fk_cuenta_activo);
            ViewBag.fk_cuenta_pasivo = new SelectList(db.bdc_cuenta_pasivo, "ID", "cuenta_pasivo", bdc_infoActivo.fk_cuenta_pasivo);
            ViewBag.fk_nom_cuenta_activo = new SelectList(db.bdc_nom_cuenta_activo, "ID", "nom_cuenta_activo", bdc_infoActivo.fk_nom_cuenta_activo);
            ViewBag.fk_nom_cuenta_pasivo = new SelectList(db.bdc_nom_cuenta_pasivo, "ID", "nom_cuenta_pasivo", bdc_infoActivo.fk_nom_cuenta_pasivo);
            ViewBag.fk_subclase = new SelectList(db.bdc_subclase, "ID", "subclase", bdc_infoActivo.fk_subclase);
            return View(bdc_infoActivo);
        }

        // GET: Activos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_infoActivo bdc_infoActivo = await db.bdc_infoActivo.FindAsync(id);
            if (bdc_infoActivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_area = new SelectList(db.bdc_area, "ID", "fk_area", bdc_infoActivo.fk_area);
            ViewBag.fk_centroCosto = new SelectList(db.bdc_centroCosto, "ID", "centroCosto", bdc_infoActivo.fk_centroCosto);
            ViewBag.fk_clase = new SelectList(db.bdc_clase, "ID", "clase", bdc_infoActivo.fk_clase);
            ViewBag.fk_cuenta_activo = new SelectList(db.bdc_cuenta_activo, "ID", "cuenta_activo", bdc_infoActivo.fk_cuenta_activo);
            ViewBag.fk_cuenta_pasivo = new SelectList(db.bdc_cuenta_pasivo, "ID", "cuenta_pasivo", bdc_infoActivo.fk_cuenta_pasivo);
            ViewBag.fk_nom_cuenta_activo = new SelectList(db.bdc_nom_cuenta_activo, "ID", "nom_cuenta_activo", bdc_infoActivo.fk_nom_cuenta_activo);
            ViewBag.fk_nom_cuenta_pasivo = new SelectList(db.bdc_nom_cuenta_pasivo, "ID", "nom_cuenta_pasivo", bdc_infoActivo.fk_nom_cuenta_pasivo);
            ViewBag.fk_subclase = new SelectList(db.bdc_subclase, "ID", "subclase", bdc_infoActivo.fk_subclase);
            return View(bdc_infoActivo);
        }

        // POST: Activos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,fk_centroCosto,fk_area,fk_cuenta_activo,fk_nom_cuenta_activo,fk_cuenta_pasivo,fk_nom_cuenta_pasivo,fk_clase,fk_subclase,denominacion,subdenominacion,descripcion,marca,modelo,num_serie,ubicación,cod_barras,estado,fk_traspaso,fk_financiamiento,fech_compra,n_factura,obs_general")] bdc_infoActivo bdc_infoActivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdc_infoActivo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fk_area = new SelectList(db.bdc_area, "ID", "fk_area", bdc_infoActivo.fk_area);
            ViewBag.fk_centroCosto = new SelectList(db.bdc_centroCosto, "ID", "centroCosto", bdc_infoActivo.fk_centroCosto);
            ViewBag.fk_clase = new SelectList(db.bdc_clase, "ID", "clase", bdc_infoActivo.fk_clase);
            ViewBag.fk_cuenta_activo = new SelectList(db.bdc_cuenta_activo, "ID", "cuenta_activo", bdc_infoActivo.fk_cuenta_activo);
            ViewBag.fk_cuenta_pasivo = new SelectList(db.bdc_cuenta_pasivo, "ID", "cuenta_pasivo", bdc_infoActivo.fk_cuenta_pasivo);
            ViewBag.fk_nom_cuenta_activo = new SelectList(db.bdc_nom_cuenta_activo, "ID", "nom_cuenta_activo", bdc_infoActivo.fk_nom_cuenta_activo);
            ViewBag.fk_nom_cuenta_pasivo = new SelectList(db.bdc_nom_cuenta_pasivo, "ID", "nom_cuenta_pasivo", bdc_infoActivo.fk_nom_cuenta_pasivo);
            ViewBag.fk_subclase = new SelectList(db.bdc_subclase, "ID", "subclase", bdc_infoActivo.fk_subclase);
            return View(bdc_infoActivo);
        }

        // GET: Activos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdc_infoActivo bdc_infoActivo = await db.bdc_infoActivo.FindAsync(id);
            if (bdc_infoActivo == null)
            {
                return HttpNotFound();
            }
            return View(bdc_infoActivo);
        }

        // POST: Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bdc_infoActivo bdc_infoActivo = await db.bdc_infoActivo.FindAsync(id);
            db.bdc_infoActivo.Remove(bdc_infoActivo);
            await db.SaveChangesAsync();
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
