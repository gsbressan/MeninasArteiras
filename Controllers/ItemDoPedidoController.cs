using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeninasArteiras.Models;

namespace MeninasArteiras.Controllers
{
    public class ItemDoPedidoController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /ItemDoPedido/

        public ActionResult Index()
        {
            var IP = db.ItensDoPedido.Include(I => I.Produto);
            return View("Index", IP.ToList());
        }

        public ActionResult Details(int id)
        {
            ItemDoPedido IP = db.ItensDoPedido.Find(id);
            if (IP != null)
            {
                return View("Details", IP);
            }
            return HttpNotFound();
        }

        public ActionResult Create(int PedidoID)
        {
            ItemDoPedido IP = new ItemDoPedido();
            IP.PedidoID = PedidoID;
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome");
            return View("Create", IP);
        }

        [HttpPost]
        public ActionResult Create(ItemDoPedido IP)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", IP.ProdutoID);
                return View("Create", IP);
            }
            db.ItensDoPedido.Add(IP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ItemDoPedido IP = db.ItensDoPedido.Find(id);
            if (IP == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", IP.ProdutoID);
            return View("Edit", IP);
        }

        [HttpPost]
        public ActionResult Edit(ItemDoPedido IP)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Nome", IP.ProdutoID);
                return View("Edit", IP);
            }
            db.Entry(IP).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ItemDoPedido IP = db.ItensDoPedido.Find(id);
            if (IP == null)
            {
                return HttpNotFound();
            }
            return View("Delete", IP);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemDoPedido IP = db.ItensDoPedido.Find(id);
            db.ItensDoPedido.Remove(IP);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
