using MeninasArteiras.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeninasArteiras.Controllers
{
    public class FormaDePagamentoController : Controller
    {

        Contexto db = new Contexto();

        //
        // GET: /FormaDePagamento/

        public ActionResult Index()
        {
            return View("Index", db.FormasDePagamento.ToList());
        }

        public ActionResult Details(int id)
        {
            FormaDePagamento FP = db.FormasDePagamento.Find(id);
            return View("Details", FP);
        }

        public ActionResult Create()
        {
            FormaDePagamento FP = new FormaDePagamento();
            return View("Create", FP);
        }

        [HttpPost]
        public ActionResult Create(FormaDePagamento FP)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", FP);
            }
            db.FormasDePagamento.Add(FP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            FormaDePagamento FP = db.FormasDePagamento.Find(id);
            if (FP !=null)
            {
                return View("Edit", FP);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(FormaDePagamento FP)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", FP);
            }
            db.Entry(FP).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            FormaDePagamento FP = db.FormasDePagamento.Find(id);
            if (FP != null)
            {
                return View("Delete", FP);
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
            FormaDePagamento FP = db.FormasDePagamento.Find(id);
            db.FormasDePagamento.Remove(FP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
