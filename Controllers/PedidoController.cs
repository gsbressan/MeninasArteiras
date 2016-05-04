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
    public class PedidoController : Controller
    {
        private Contexto db = new Contexto();

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Cliente).Include(p => p.FormaDePagamento).Include(p => p.FormaDeEntrega);
            return View(pedidos.ToList());
        }

        //
        // GET: /Pedido/Details/5

        public ActionResult Details(int id = 0)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            pedido.CalculaValorTotal();
            return View(pedido);
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            Pedido Pedido = new Pedido();
            ViewBag.PedidoID = Pedido.PedidoID;
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.FormaDePagamentoID = new SelectList(db.FormasDePagamento, "FormaDePagamentoID", "Nome");
            ViewBag.FormaDeEntregaID = new SelectList(db.FormasDeEntrega, "FormaDeEntregaID", "Nome");
            return View();
        }

        //
        // POST: /Pedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.CalculaValorTotal();
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoID = pedido.PedidoID;
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
            ViewBag.FormaDePagamentoID = new SelectList(db.FormasDePagamento, "FormaDePagamentoID", "Nome", pedido.FormaDePagamentoID);
            ViewBag.FormaDeEntregaID = new SelectList(db.FormasDeEntrega, "FormaDeEntregaID", "Nome", pedido.FormaDeEntregaID);
            return View(pedido);
        }

        //
        // GET: /Pedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoID = pedido.PedidoID;
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
            ViewBag.FormaDePagamentoID = new SelectList(db.FormasDePagamento, "FormaDePagamentoID", "Nome", pedido.FormaDePagamentoID);
            ViewBag.FormaDeEntregaID = new SelectList(db.FormasDeEntrega, "FormaDeEntregaID", "Nome", pedido.FormaDeEntregaID);
            return View(pedido);
        }

        //
        // POST: /Pedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PedidoID = pedido.PedidoID;
                ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
                ViewBag.FormaDePagamentoID = new SelectList(db.FormasDePagamento, "FormaDePagamentoID", "Nome", pedido.FormaDePagamentoID);
                ViewBag.FormaDeEntregaID = new SelectList(db.FormasDeEntrega, "FormaDeEntregaID", "Nome", pedido.FormaDeEntregaID);
                return View(pedido); 
            }
            pedido.CalculaValorTotal();
            db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Pedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        //
        // POST: /Pedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public ActionResult _ListaDeItens(int PedidoID)
        {
            var Itens = db.ItensDoPedido.Include(I => I.Produto).Where(I => I.PedidoID == PedidoID);
            if (Itens != null)
            {
                return PartialView("_ListaDeItens", Itens);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}