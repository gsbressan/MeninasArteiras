using MeninasArteiras.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeninasArteiras.Controllers
{
    public class ProdutoController : Controller
    {
        Contexto db = new Contexto();

        public ActionResult Index()
        {
            return View("Index", db.Produtos.ToList());
        }

        public ActionResult Details(int id)
        {
            Produto produto = db.Produtos.Find(id);
            return View("Details", produto);
        }

        public ActionResult Create()
        {
            Produto Produto = new Produto();
            return View("Create", Produto);
        }

        [HttpPost]
        public ActionResult Create(Produto produto, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", produto);
            }
            else
            {
                if (image != null)
                {
                    produto.ImageMimeType = image.ContentType;
                    produto.FotoDoProduto = new byte[image.ContentLength];
                    image.InputStream.Read(produto.FotoDoProduto, 0, image.ContentLength);
                }
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View("Edit", produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", produto);
            }
        }

        public ActionResult Delete(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View("Delete", produto);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto != null)
            {
                return File(produto.FotoDoProduto, produto.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
