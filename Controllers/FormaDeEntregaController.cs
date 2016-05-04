using MeninasArteiras.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeninasArteiras.Controllers
{
    public class FormaDeEntregaController : Controller
    {

        Contexto db = new Contexto();

        //
        // GET: /FormaDeEntrega/

        public ActionResult Index()
        {
            return View("Index", db.FormasDeEntrega.ToList());
        }

        public ActionResult Details(int id)
        {
            FormaDeEntrega FE = db.FormasDeEntrega.Find(id);
            if (FE != null)
            {
                return View("Details", FE);
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Create()
        {
            FormaDeEntrega FE = new FormaDeEntrega();
            return View("Create", FE);
        }

        [HttpPost]
        public ActionResult Create(FormaDeEntrega FE)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", FE);    
            }
            db.FormasDeEntrega.Add(FE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            FormaDeEntrega FE = db.FormasDeEntrega.Find(id);
            if (FE != null)
            {
                return View("Edit", FE);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Edit(FormaDeEntrega FE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(FE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", FE);
        }

        public ActionResult Delete(int id)
        {
            FormaDeEntrega FE = db.FormasDeEntrega.Find(id);
            if (FE != null)
            {
                return View("Delete", FE);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaDeEntrega FE = db.FormasDeEntrega.Find(id);
            db.FormasDeEntrega.Remove(FE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
